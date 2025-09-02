using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static POS點餐機.Models.MenuModel;

namespace POS點餐機.Strategies
{
    internal class ComboFreeItemStrategy : AStrategy
    {
        public ComboFreeItemStrategy(MenuModel.Discount strategyType, List<MenuItem> items) : base(strategyType, items)
        {

        }

        public override void DiscountOrder()
        {


            //1.將Conditions中的每一筆商品品項，攤平後，並賦予一個ConditionID 作為編號
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

            //2.將有購買的items的品項去對應步驟1 的Conditions 要進行分組 並將每一筆資料轉換成ConditionMapping
            var itemsCondition = items.Select(x =>
            {
                var itemConditon = conditions.FirstOrDefault(condition => condition.Name == x.Name);
                if (itemConditon == null)
                    return null;

                return new ConditionMapping()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    ConditionCount = itemConditon.ConditionCount,
                    ConditionID = itemConditon.ConditionID,
                };
            }).Where(x => x != null).ToList();


            //3.分組並篩選並剔除該組條件的項目
            var grouped = itemsCondition.GroupBy(x => new { x.ConditionID, x.ConditionCount })
                                        .Select(x => new
                                        {
                                            ConditionID = x.Key.ConditionID,
                                            ConditionCount = x.Key.ConditionCount,
                                            TotalAmount = x.Sum(x => x.Amount)

                                        })
                                        .Where(x => x.TotalAmount >= x.ConditionCount).ToList();


            //4. 分組後的組數應該要與原來Conditions長度相等，如果不相等則代表條件不成立
            if (grouped.Count != strategyType.Conditions.Length)
                return;


            //5.從 groupd中取出最少符合條件的贈送次數
            int times = grouped.Min(x => x.TotalAmount / x.ConditionCount);

            if (times == 0)
            {
                return;

            }
            //紅茶|綠茶|奶茶|烏龍茶|布丁|乳酪蛋糕
            var rewardItems = strategyType.Rewards.SelectMany((Reward, RewardMapID) =>
            {
                string[] rewardItems = Reward.FreeItem.Split('|'); // [紅茶,綠茶,奶茶,烏龍茶,布丁,乳酪蛋糕]

                var rewardGroupItems = rewardItems.Select(r => new
                {
                    Name = r,
                    FreeQuantity = Reward.FreeQuantity,
                    RewardType = Reward.RewardType,
                    RewardID = RewardMapID
                });
                return rewardGroupItems;
            }).ToList();

            //按 RewardType 分組處理(min / max / random / free-random)
            //var groupedRewards = strategyType.Rewards.GroupBy(r => r.RewardType.ToLower()).ToList();
            var groupedRewards = rewardItems.GroupBy(r => new { r.RewardID, r.FreeQuantity, r.RewardType }).ToList();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            foreach (var group in groupedRewards)
            {
                string type = group.Key.RewardType; // min / max / random / free-random
                if (type == "free-random" || type == "")
                {
                    var groupItems = group.ToList();
                    var selectedItem = groupItems[random.Next(group.Count())];
                    int quantity = selectedItem.FreeQuantity * times;
                    items.Add(new MenuItem($"(贈送){selectedItem.Name}", 0, quantity));

                }

                else if (type == "min")
                {
                    var groupItems = group.ToList();

                    var selectedItem = items.Where(i => groupItems.Any(g => g.Name == i.Name)).OrderBy(i => i.Price).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        //int quantity = groupItems.First(g => g.Name == selectedItem.Name)
                        int quantity = selectedItem.Amount * times;
                        items.Add(new MenuItem($"(贈送){selectedItem.Name}", 0, quantity));
                    }


                }

                else if (type == "max")
                {
                    var groupItems = group.ToList();

                    var selectedItem = items.Where(i => groupItems.Any(g => g.Name == i.Name)).OrderByDescending(i => i.Price).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        int quantity = selectedItem.Amount * times;
                        items.Add(new MenuItem($"(贈送){selectedItem.Name}", 0, quantity));
                    }

                }
                else if (type == "random")
                {
                    var groupItems = group.ToList();


                    var selectedItem = items.Where(i => groupItems.Any(g => g.Name == i.Name)).OrderBy(x => random.Next()).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        int quantity = selectedItem.Amount * times;
                        items.Add(new MenuItem($"(贈送){selectedItem.Name}", 0, quantity));
                    }

                }

            }




        }
    }
}



