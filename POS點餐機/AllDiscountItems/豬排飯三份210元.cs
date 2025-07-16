using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 豬排飯三份210元 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem PorkCutlet = orders.FirstOrDefault(x => x.Name == "豬排飯");
            int groupCount = PorkCutlet.Amount / 3;
            int discountQty = groupCount * 3;
            int discountPrice = 210 * groupCount;
            int originPrice = PorkCutlet.Price * discountQty;

            orders.Add(new MenuItem("(打折)豬排飯三份210元", discountPrice - originPrice, 1));
        }
    }
}
