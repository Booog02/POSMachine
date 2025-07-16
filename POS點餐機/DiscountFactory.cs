using POS點餐機.AllDiscountItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class DiscountFactory
    {
        public static IDiscount GetDiscount(string discountType)
        {
            switch (discountType)
            {
                case "雞腿飯買二送一":
                    return new 雞腿飯買二送一();

                case "雞排飯買三個打85折":
                    return new 雞排飯買三個打85折();

                case "排骨飯搭配燙青菜120元":
                    return new 排骨飯搭配燙青菜120元();

                case "豬排飯三份210元":
                    return new 豬排飯三份210元();

                case "雞腿飯搭配燙青菜送紅茶一杯":
                    return new 雞腿飯搭配燙青菜送紅茶一杯();

                case "雞排飯買兩份搭配兩杯紅茶打95折":
                    return new 雞排飯買兩份搭配兩杯紅茶打95折();

                case "飲料任選三杯40元":
                    return new 飲料任選三杯40元();

                case "飲料任選5杯打8折_用最低價":
                    return new 飲料任選5杯打8折_用最低價();

                case "豬排飯兩份搭配蛋花湯一份就送布丁一份紅茶一份":
                    return new 豬排飯兩份搭配蛋花湯一份就送布丁一份紅茶一份();

                case "全品項購買滿399打8折":
                    return new 全品項購買滿399打8折();

                case "全品項不限金額打9折":
                    return new 全品項不限金額打9折();

                default:
                    return new 沒有折扣();
            }
        }
    }
}
