using AIAgentPractice.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AI.Tools
{
    internal class DiscountDeclaration : BaseDeclaration
    {
        public override string name => "AI.Tools.DiscountTool";

        public override string description => "根據訂單資料自動推薦適合的折扣方案。";

        public override BaseParameters parameters => new DiscountParameters();
    }
}
