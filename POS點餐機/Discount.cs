using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class Discount
    {
        public static void DiscountOrder(string discountType, List<MenuItem> orders)
        {

            orders.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("打折") || x.Name.Contains("折扣"));
            //IDiscount Items = DiscountFactory.GetDiscount(discountType);
            //Items.Discount(orders);

            Type type = Type.GetType("POS點餐機.AllDiscountItems." + discountType);
            IDiscount Items = (IDiscount)Activator.CreateInstance(type);
            Items.Discount(orders);
            ShowPanel.Render(orders);
        }
    }
}
