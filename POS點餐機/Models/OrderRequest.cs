using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Models
{
    /// <summary>
    /// 負責封裝單次訂單的所有請求資料。
    /// 包含目前折扣設定、AI、全域的訂單池。
    /// <para>1. <see cref="Orders"/>: 訂單池，儲存所有餐點品項。</para>
    /// <para>2. <see cref="discount"/>: 目前所選的折扣類型。</para>
    /// <para>3. <see cref="EnabledAIRecommend"/>: 是否啟用AI推薦功能。</para>
    /// <para>4. <see cref="Item"/>: 使用者UI勾選的餐點品項。</para>
    /// </summary>
    internal class OrderRequest
    {
        /// <summary>
        /// 全域唯一的訂單池，負責儲存所有選取的餐點項目。  
        /// 此集合由各種表單事件（CheckBox、NumericUpDown）共同維護。
        /// </summary>
        public static List<MenuItem> Orders { get; set; } = new List<MenuItem>();
        /// <summary>
        /// 當前所選擇的折扣類型（Discount），
        /// 由 ComboBox 選擇後傳入，用於折扣策略判斷。
        /// </summary>
        public MenuModel.Discount discount { get; set; }
        /// <summary>
        /// 是否啟用 AI 推薦模式。
        /// 當 true 時，折扣邏輯會轉交給 AIRecommend 自動決策。
        /// </summary>
        public bool EnabledAIRecommend { get; set; }
        /// <summary>
        /// 當前選取的餐點項目，
        /// 用於新增、刪除或更新指定菜單的操作。
        /// </summary>
        public MenuItem Item { get; set; }

        public OrderRequest(MenuModel.Discount discount, MenuItem item, bool enabledAIRecommend)
        {
            this.EnabledAIRecommend = enabledAIRecommend;
            this.discount = discount;
            this.Item = item;
        }

        public OrderRequest(bool enabledAIRecommend, MenuItem item)
        {
            this.EnabledAIRecommend = enabledAIRecommend;
            this.discount = null;
            this.Item = item;


        }
        public OrderRequest(MenuModel.Discount type)
        {
            this.EnabledAIRecommend = false;
            this.discount = type;
        }
    }
}
