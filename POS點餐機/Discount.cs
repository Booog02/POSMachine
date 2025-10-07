using AIAgentPractice;
using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    /// <summary>
    /// 負責執行整體折扣流程的入口方法，
    /// 建立<see cref="DiscountContext"/>，呼叫<see cref="DiscountContext.ApplyStrategy"/>執行折扣邏輯
    /// </summary>
    internal class Discount
    {
        public static async Task DiscountOrder(OrderRequest orderRequest)
        {

            DiscountContext discountContext = new DiscountContext(orderRequest);
            AIResponse.Args agentResponse = await discountContext.ApplyStrategy();


            ShowPanel.Render(OrderRequest.Orders, agentResponse);
        }
    }
}
