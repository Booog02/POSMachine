using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    interface IDiscount
    {
        public void Discount(List<MenuItem> orders);
    }
}
