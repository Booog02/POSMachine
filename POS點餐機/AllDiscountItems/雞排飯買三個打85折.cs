using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 雞排飯買三個打85折 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem ChickenSteak = orders.FirstOrDefault(x => x.Name == "雞排飯");

            if (ChickenSteak != null && ChickenSteak.Amount >= 3)
            {
                int discountGroupQty = ChickenSteak.Amount / 3;
                int discountQty = discountGroupQty * 3;

                int discountPrice = (int)(ChickenSteak.Price * discountQty * 0.85);
                int originPrice = ChickenSteak.Price * discountQty;
                orders.Add(new MenuItem("(打折)雞排飯", discountPrice - originPrice, 1));

            }
        }
    }
}
