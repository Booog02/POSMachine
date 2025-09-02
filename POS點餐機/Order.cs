using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class Order
    {
        private static List<MenuItem> orders = new List<MenuItem>();

        /// <summary>
        /// 前端會傳入一包 MenuItem物件，該方法會根據品項內容自行管理(如果資料存在則調整數量，資料不存在則添加資料)
        /// </summary>
        /// <param name="menuItem"></param>
        public static void AddOrder(MenuModel.Discount discountType, MenuItem menuItem)
        {
            // 根據前端傳進來的 menuItem 物件 去查找orders 的 List
            MenuItem product = orders.FirstOrDefault(x => x.Name == menuItem.Name);
            if (product == null)  // 如果找不到該筆資料 => 將menuITem物件進行新增
            {
                if (menuItem.Amount > 0)
                {
                    orders.Add(menuItem);
                }
            }
            else
            {
                // 如果有找到該筆資料 => 檢查 menuItem裡面的數量是否為0,如果是0 就進行刪除 如果不為0 則將當前查到的該筆資料，數量變更為 menuItem傳進來的數量
                if (menuItem.Amount == 0)
                {
                    orders.Remove(product);
                }
                else
                {
                    product.Amount = menuItem.Amount;
                }
            }

            Discount.DiscountOrder(discountType, orders);




        }


        public static void ChangeDiscountType(MenuModel.Discount discountType)
        {
            Discount.DiscountOrder(discountType, orders);

        }

    }
}
