using AIAgentPractice;
using AIAgentPractice.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS點餐機.Models.MenuModel;

namespace POS點餐機.AI.Tools
{
    internal class DiscountParameters : BaseParameters
    {
        public override List<string> required => new List<string> { "strategyName", "name", "reason" };

        public override object properties => new
        {
            strategyName = new AIRequest.PropertyField
            {
                type = "string",
                description = "折扣完整類別名稱，例如:POS點餐機.Strategies.ComboFreeItemStrategy"
            },
            name = new AIRequest.PropertyField
            {
                type = "string",
                description = "折扣方案的名稱，例如:烤牛五花買二送一"
            },
            reason = new AIRequest.PropertyField
            {
                type = "string",
                description = "AI 推薦這個折扣方案的原因"
            }

        };


    }
}
