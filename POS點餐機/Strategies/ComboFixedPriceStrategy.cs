using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static POS點餐機.Models.MenuModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace POS點餐機.Strategies
{
    internal class ComboFixedPriceStrategy : AStrategy
    {
        public ComboFixedPriceStrategy(MenuModel.Discount strategyType, List<MenuItem> items) : base(strategyType, items)
        {
        }

        public override void DiscountOrder()
        {


            List<int> groupCounts = new List<int>();

            //攤平條件清單，每項代表條件中可匹配的品項
            var conditions = strategyType.Conditions.SelectMany((condition, conditionID) =>
                {
                    string[] itemNames = condition.BuyItem.Split('|');
                    var groupItems = itemNames.Select(x => new
                    {
                        Name = x,
                        Price = condition.Price,
                        ConditionCount = condition.BuyQuantity,
                        ConditionID = conditionID
                    });

                    return groupItems;
                }).ToList();
            //比對實際購買的品項(items)與我的條件品項(conditions)做比對，new一包條件符合的Mapping列表，依照ID/Price 排序
            var itemsCondition = items.Select(x =>
            {
                var itemCondition = conditions.FirstOrDefault(condition => condition.Name == x.Name);
                if (itemCondition == null)
                    return null;

                return new ConditionMapping()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    ConditionCount = itemCondition.ConditionCount,
                    ConditionID = itemCondition.ConditionID,
                };
            }).Where(x => x != null).OrderBy(x => x.ConditionID).ThenBy(x => x.Price).ToList();

            //3.條件分組驗證
            //  針對ConditionID分組 統計該組的總購買數量
            //  TotalAmount 不得小於 ConditionCount,否則條件不成立
            var grouped = itemsCondition.GroupBy(x => new { x.ConditionID, x.ConditionCount })
                                         .Select(x => new
                                         {
                                             ConditionID = x.Key.ConditionID,
                                             ConditionCount = x.Key.ConditionCount,
                                             TotalAmount = x.Sum(x => x.Amount)

                                         })
                                         .Where(x => x.TotalAmount >= x.ConditionCount).ToList();

            //4.檢查折扣條件是否符合
            if (grouped.Count != strategyType.Conditions.Length)
                return;

            //5.計算可以折扣條件的最小次數 
            int finalTimes = grouped.Select(x => x.TotalAmount / x.ConditionCount).Min();
            if (finalTimes <= 0)
                return;



            // 針對條件分組統計原價與要折抵的金額
            var conditionGroup = itemsCondition.GroupBy(x => new { x.ConditionID, x.ConditionCount });

            // 原價總金額
            //var originalTotalPrice = conditionGroup.Select(x => x.Sum(y => y.Price * y.Amount)).Sum();
            var originalSelectedTotal = conditionGroup.Select(x =>
            {
                int reguired = x.Key.ConditionCount * finalTimes;//有符合條件的餐點
                var expanded = x.SelectMany(y => Enumerable.Repeat(y, y.Amount));
                var picked = expanded.OrderBy(y => y.Price).Take(reguired);//價格由小到大取便宜的
                return picked.Sum(y => y.Price);
            }).Sum();


            var discounts = strategyType.Rewards.Select(reward =>
            {
                if (reward.PackagePrice > 0)
                {
                    int packagePriceTotal = reward.PackagePrice * finalTimes;
                    int diff = originalSelectedTotal - packagePriceTotal;

                    if (diff > 0)
                    {
                        return new MenuItem($"(折扣){strategyType.Name}x{finalTimes}", -diff, 1);
                    }

                }
                else if (reward.DiscountPrice > 0)
                {
                    int off = reward.DiscountPrice * finalTimes;
                    if (off > 0)
                    {
                        return new MenuItem($"(折扣){strategyType.Name}x{finalTimes}", -off, 1);
                    }
                }

                return null;

            }).Where(x => x != null).ToList();

            if (discounts.Count == 0)
            {
                return;
            }

            items.AddRange(discounts);



        }
    }
}
