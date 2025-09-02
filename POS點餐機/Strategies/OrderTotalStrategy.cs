using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Strategies
{
    internal class OrderTotalStrategy : AStrategy
    {
        // 0829 HW
        // 訂單金額多少？
        // 有沒有超過條件金額？有，就折扣

        public OrderTotalStrategy(MenuModel.Discount strategyType, List<MenuItem> items) : base(strategyType, items)
        {
        }

        public override void DiscountOrder()
        {
            //1.攤平條件
            var conditions = strategyType.Conditions.SelectMany((condition, conditionID) =>
            {
                string str = ""; //empty,str.Length => 0
                string str2 = null; // null,str3.Length => error 並未將物件參考設定為執行個體
                string str3 = " "; //space , str3.Length => 1
                //string[] itemNames;
                //if (string.IsNullOrEmpty(condition.BuyItem))
                //{
                //    itemNames = new string[] { "" };
                //}
                //else
                //{
                //    itemNames = condition.BuyItem.Split('|');
                //}
                string[] itemNames = string.IsNullOrEmpty(condition.BuyItem) ? new string[] { "" } : condition.BuyItem.Split('|');
                return itemNames.Select(x => new
                {
                    Name = x,
                    MinPrice = condition.Price,
                    ConditionID = conditionID,

                });
            }).ToList();

            //2.計算訂單符合條件的金額

            //int orderTotal = 0;
            //foreach (var condition in strategyType.Conditions)
            //{
            //    if (string.IsNullOrEmpty(condition.BuyItem))
            //    {
            //        orderTotal += items.Sum(i => i.Price * i.Amount);
            //    }
            //    else
            //    {
            //        var itemNames = condition.BuyItem.Split('|');
            //        orderTotal += items.Where(i => itemNames.Contains(i.Name)).Sum(i => i.Price * i.Amount);
            //    }
            //}
            int orderTotal = strategyType.Conditions.Sum(condition =>
                string.IsNullOrEmpty(condition.BuyItem) ? items.Sum(x => x.Price * x.Amount)
                : items.Where(x => condition.BuyItem.Split('|').Contains(x.Name)).Sum(x => x.Price * x.Amount)
            );

            //3.是否符合條件？
            var priceCondition = strategyType.Conditions.FirstOrDefault(x => x.Price > 0);
            if (priceCondition != null && orderTotal < priceCondition.Price)
                return;

            var percentageReward = strategyType.Rewards.FirstOrDefault(y => y.DiscountRate > 0);
            if (percentageReward == null)
                return;



            int discountedTotal = (int)(orderTotal * percentageReward.DiscountRate);

            int diff = orderTotal - discountedTotal;
            if (diff > 0)
            {
                items.Add(new MenuItem($"(折扣){strategyType.Name}", -diff, 1));
            }
        }
    }
}
