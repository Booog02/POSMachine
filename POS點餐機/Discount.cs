using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class Discount
    {
        public static void DiscountOrder(MenuModel.Discount discountType, List<MenuItem> orders)
        {

            DiscountContext discountContext = new DiscountContext(discountType, orders);
            discountContext.ApplyStrategy();


            ShowPanel.Render(orders);
        }
    }
}
