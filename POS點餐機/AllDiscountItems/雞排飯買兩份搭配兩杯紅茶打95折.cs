using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 雞排飯買兩份搭配兩杯紅茶打95折 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem ChickenSteak = orders.FirstOrDefault(x => x.Name == "雞排飯");
            MenuItem BlackTea = orders.FirstOrDefault(x => x.Name == "紅茶");

            if (ChickenSteak != null && BlackTea != null && ChickenSteak.Amount >= 2 && BlackTea.Amount >= 2)
            {
                int groupCount = Math.Min(ChickenSteak.Amount / 2, BlackTea.Amount / 2);

                int oringinGroupPrice = ChickenSteak.Price * 2 + BlackTea.Price * 2;

                int groupDiscountPrice = (int)(oringinGroupPrice * 0.95);

                int totalDiscount = (groupDiscountPrice - oringinGroupPrice) * groupCount;

                orders.Add(new MenuItem("(打折)雞排飯買兩份搭配兩杯紅茶打95折", totalDiscount, 1));
            }
        }
    }
}
