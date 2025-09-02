using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 全品項不限金額打9折 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            int originalTotal = orders.Sum(x => x.Subtotal);

            if (originalTotal >= 399)
            {
                int discountAmount = (int)(originalTotal * 0.2) * -1;
                orders.Add(new MenuItem("(折扣)全品項滿399打8折", discountAmount, 1));
            }
        }
    }
}
