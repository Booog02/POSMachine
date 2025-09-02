using POS點餐機.Models;
using POS點餐機.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class DiscountContext
    {
        MenuModel.Discount discountType;
        List<MenuItem> orders;

        public DiscountContext(MenuModel.Discount discountType, List<MenuItem> orders)
        {
            this.discountType = discountType;
            this.orders = orders;

        }

        public void ApplyStrategy()
        {
            orders.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("打折") || x.Name.Contains("折扣"));

            Type type = Type.GetType(discountType.Strategy);
            AStrategy strategy = (AStrategy)Activator.CreateInstance(type, new object[] { discountType, orders });

            strategy.DiscountOrder();

        }

    }
}
