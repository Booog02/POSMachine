using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Strategies
{
    internal class ComboPercentageStrategy : AStrategy
    {
        public ComboPercentageStrategy(MenuModel.Discount strategyType, List<MenuItem> items) : base(strategyType, items)
        {
        }

        public override void DiscountOrder()
        {
            //1.攤平條件清單，每項代表條件中可匹配的品項
            var conditions = strategyType.Conditions.SelectMany((condidion, conditionID) =>
            {
                return condidion.BuyItem.Split('|').Select(x => new
                {
                    Name = x,
                    Price = condidion.Price,
                    ConditionCount = condidion.BuyQuantity,
                    ConditionID = conditionID
                });
            }).ToList();
            // 0829 HW Debug
            //2.比對實際購買的品項(items)與我的條件品項(conditions)做比對，new一包條件符合的Mapping列表，依照ID/Price 排序
            var itemsCondition = items.Select(x =>
            {
                var itemCondition = conditions.FirstOrDefault(y => y.Name == x.Name);
                if (itemCondition == null)
                    return null;

                return new ConditionMapping
                {
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    ConditionCount = itemCondition.ConditionCount,
                    ConditionID = itemCondition.ConditionID
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
                    TotalAmount = x.Sum(y => y.Amount)
                }).Where(x => x.TotalAmount >= x.ConditionCount).ToList();

            //4.檢查折扣條件是否符合
            if (grouped.Count != strategyType.Conditions.Length)
                return;

            int finalTimes = grouped.Select(x => x.TotalAmount / x.ConditionCount).Min();
            if (finalTimes <= 0)
                return;

            var conditionGroup = itemsCondition.GroupBy(x => new { x.ConditionID, x.ConditionCount });

            int originalSelectedTotal = conditionGroup.Select(x =>
            {
                int reguired = x.Key.ConditionCount * finalTimes;
                var expanded = x.SelectMany(y => Enumerable.Repeat(y, y.Amount));
                var picked = expanded.OrderBy(y => y.Price).Take(reguired);
                return picked.Sum(y => y.Price);
            }).Sum();

            var percentageRewards = strategyType.Rewards.First(x => x.DiscountRate > 0);

            int discountedTotal = (int)(originalSelectedTotal * percentageRewards.DiscountRate);

            int diff = originalSelectedTotal - discountedTotal;
            if (diff > 0)
            {
                items.Add(new MenuItem($"(折扣){strategyType.Name}x{finalTimes}", -diff, 1));
            }
        }
    }
}
