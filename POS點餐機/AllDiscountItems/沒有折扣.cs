using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 沒有折扣 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            throw new NotImplementedException();
        }
    }
}
