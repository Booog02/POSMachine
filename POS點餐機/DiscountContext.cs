using AIAgentPractice;
using POS點餐機.Models;
using POS點餐機.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    /// <summary>
    /// 折扣策略的橋樑，
    /// 建構元負責根據<see cref="OrderRequest"/>設定
    /// 動態決定要使用"手動" or "AI"模式
    /// </summary>

    internal class DiscountContext
    {
        OrderRequest orderRequest;
        MenuModel.Discount discountType;
        List<MenuItem> orders;

        public DiscountContext(OrderRequest orderRequest)
        {
            this.orders = OrderRequest.Orders;
            this.orderRequest = orderRequest;

        }

        private async Task<AIResult> GetStrategy()
        {
            if (!orderRequest.EnabledAIRecommend)
            {
                this.discountType = orderRequest.discount;

                return null;
            }
            else
            {
                //呼叫 AI模組
                //1.創建 AIAgent
                AIAgent aIAgent = new AIAgent();

                //2.告訴AI你的菜單/折扣  (prompt)
                aIAgent.AddPrompt(UserType.Model, "這是我的POS點餐機所有的菜單和可以折扣的項目與策略:\r\n" + AppDataModel.MenuJson);
                //3.撰寫AITool (DiscountTool)

                //4.啟用AIAgent 開始聊天 告訴他這次你點了那些餐點

                string orderString = string.Join("\r\n", this.orders.Select(x => $"{x.Name}:{x.Amount}份").ToList());

                //5.拿回 AIResult 去執行 RunTool (取回DiscountType)
                AIResult result = await aIAgent.SendCommand($"這次是我點的餐點:{orderString}");

                //6.接回來執行 ApplyStrategy
                return result;
            }
        }


        /// <summary>
        /// 根據當前訂單的折扣類型執行對應的折扣策略。
        /// </summary>
        public async Task<AIResponse.Args> ApplyStrategy()
        {
            AIResult result = await GetStrategy();

            if (result == null)
            {
                orders.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("打折") || x.Name.Contains("折扣"));

                Type type = Type.GetType(discountType.Strategy);
                AStrategy strategy = (AStrategy)Activator.CreateInstance(type, new object[] { discountType, orders });

                strategy.DiscountOrder();
                return null;
            }
            else
            {
                if (result.CanRunTool)
                {
                    var args = result.RunTool();

                    orders.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("打折") || x.Name.Contains("折扣"));
                    discountType = AppDataModel.Discounts.First(x => x.Strategy == args.strategyName);
                    Type type = Type.GetType(args.strategyName);
                    AStrategy strategy = (AStrategy)Activator.CreateInstance(type, new object[] { discountType, orders });

                    strategy.DiscountOrder();

                    return args;
                }

                return null;
            }


        }

    }
}
