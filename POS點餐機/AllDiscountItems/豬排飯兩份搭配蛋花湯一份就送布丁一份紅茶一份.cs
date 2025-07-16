using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.AllDiscountItems
{
    internal class 豬排飯兩份搭配蛋花湯一份就送布丁一份紅茶一份 : IDiscount
    {
        public void Discount(List<MenuItem> orders)
        {
            MenuItem Pork = orders.FirstOrDefault(x => x.Name == "豬排飯");
            MenuItem EggsSoup = orders.FirstOrDefault(x => x.Name == "蛋花湯");

            if (Pork != null && EggsSoup != null && Pork.Amount >= 2 && EggsSoup.Amount >= 1)
            {
                int groupCount = Math.Min(Pork.Amount / 2, EggsSoup.Amount / 1);

                orders.Add(new MenuItem("(贈送)布丁", 0, groupCount));
                orders.Add(new MenuItem("(贈送)紅茶", 0, groupCount));
            }
        }
    }
}