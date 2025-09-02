using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 排骨飯搭配燙青菜120元 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem PorkRice = orders.FirstOrDefault(x => x.Name == "排骨飯");
            MenuItem Vegetable = orders.FirstOrDefault(x => x.Name == "燙青菜");

            if (PorkRice != null && Vegetable != null)
            {
                int minCount = Math.Min(PorkRice.Amount, Vegetable.Amount);

                orders.Add(new MenuItem("(打折)排骨飯+燙青菜", -5, minCount));
            }
        }
    }
}
