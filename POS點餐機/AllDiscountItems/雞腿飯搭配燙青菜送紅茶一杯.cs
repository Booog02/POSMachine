using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 雞腿飯搭配燙青菜送紅茶一杯 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem ChickenLeg = orders.FirstOrDefault(x => x.Name == "雞腿飯");
            MenuItem Vegetable = orders.FirstOrDefault(x => x.Name == "燙青菜");
            if (ChickenLeg != null && Vegetable != null)
            {
                int groupCount = Math.Min(ChickenLeg.Amount, Vegetable.Amount);
                orders.Add(new MenuItem("(贈送)紅茶", 0, groupCount));

            }
        }
    }
}
