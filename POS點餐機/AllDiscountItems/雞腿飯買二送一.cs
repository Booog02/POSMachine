using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 雞腿飯買二送一 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem ChickenLeg = orders.FirstOrDefault(x => x.Name == "雞腿飯");
            if (ChickenLeg != null && ChickenLeg.Amount >= 2)
            {
                int sendCount = ChickenLeg.Amount / 2;

                orders.Add(new MenuItem("(贈送)雞腿飯", 0, sendCount));

            }
        }
    }
}
