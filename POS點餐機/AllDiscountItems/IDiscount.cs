using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    interface IDiscount
    {
        public void Discount(List<MenuItem> orders);
    }
}
