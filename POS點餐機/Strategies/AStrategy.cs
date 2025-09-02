using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Strategies
{
    internal abstract class AStrategy
    {
        protected MenuModel.Discount strategyType;
        protected List<MenuItem> items;
        protected AStrategy(MenuModel.Discount strategyType, List<MenuItem> items)
        {
            this.strategyType = strategyType;
            this.items = items;
        }

        public abstract void DiscountOrder();
    }
}
