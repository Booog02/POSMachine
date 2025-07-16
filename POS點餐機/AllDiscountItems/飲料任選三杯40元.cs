using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 飲料任選三杯40元 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            List<MenuItem> Drinks = orders.Where(x => x.Name == "紅茶" || x.Name == "綠茶" || x.Name == "奶茶").OrderBy(x => x.Price).ToList();
            int totalDrinksCount = Drinks.Sum(x => x.Amount); //5

            int groupCount = totalDrinksCount / 3; // 1 可湊折扣組數
            int discountQty = groupCount * 3; // 3 計算折扣的總杯數

            int totalPrice = Drinks.Sum(x => x.Subtotal); // 275 目前所有飲料的總價

            List<MenuItem> nonDiscountGroup = Drinks.Skip(discountQty).ToList();

            int originalSum = nonDiscountGroup.Sum(x => x.Subtotal);
            int discountedPrice = groupCount * 40;
            int afterDiscounted = originalSum + discountedPrice;
            int discount = afterDiscounted - totalPrice;
            orders.Add(new MenuItem("(打折)飲料任選3杯40元", discount, 1));
        }
    }
}
