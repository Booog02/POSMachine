using AIAgentPractice;
using AIAgentPractice.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AI.Tools
{
    internal class DiscountTool : ATool
    {
        public DiscountTool(AIResponse.Args args) : base(args)
        {
        }

        public override AIResponse.Args RunTool()
        {
            Debug.WriteLine($"AI已經完成推薦折扣方案:{args.strategyName}");
            Debug.WriteLine($"折扣方案的名稱:{args.name}");
            Debug.WriteLine($"推薦此折扣方案的原因:{args.reason}");

            return args;
        }
    }
}
