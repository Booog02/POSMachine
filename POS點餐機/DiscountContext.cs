using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class DiscountContext
    {
        string discountType;
        List<MenuItem> orders;

        public DiscountContext(string discountType, List<MenuItem> orders)
        {
            this.discountType = discountType;
            this.orders = orders;

        }

        public void ApplyStrategy()
        {
            orders.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("打折") || x.Name.Contains("折扣"));

            Type type = Type.GetType("POS點餐機.AllDiscountItems." + discountType);
            IDiscount Items = (IDiscount)Activator.CreateInstance(type);
            Items.Discount(orders);

        }

    }
}
