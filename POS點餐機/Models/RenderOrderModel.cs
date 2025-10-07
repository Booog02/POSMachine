using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Models
{
    //Model 專門放資料的地方
    internal class RenderOrderModel
    {
        public FlowLayoutPanel Panel { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountName { get; set; }
        public string Reason { get; set; }
    }
}
