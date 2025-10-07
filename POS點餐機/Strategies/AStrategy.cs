using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Strategies
{
    /// <summary>
    /// 折扣策略的抽象基底類別 (Abstract Discount Strategy)。  
    /// <para>所有具體的折扣策略（如買一送一、滿額折扣、組合固定價等）  
    /// 都必須繼承此類別並實作 <see cref="DiscountOrder()"/> 方法。</para>
    /// <para>此類別主要負責:</para>
    /// <para>1️. 儲存折扣設定（<see cref="MenuModel.Discount"/>）。 </para> 
    /// <para>2️. 維護目前訂單項目清單（<see cref="List{MenuItem}"/>）。 </para> 
    /// <para>3️. 提供統一的抽象方法給子類別進行折扣計算。</para>
    /// </summary>
    internal abstract class AStrategy
    {
        protected MenuModel.Discount strategyType;
        protected List<MenuItem> items;

        /// <summary>
        /// 建構元 :初始化策略基本的屬性。  
        /// <para>將傳入的折扣設定與訂單項目綁定至策略物件，  
        /// 以便後續在 <see cref="DiscountOrder()"/> 中運算使用。</para>
        /// </summary>
        /// <param name="strategyType">折扣設定資料，定義策略行為。</param>
        /// <param name="items">目前訂單中所有餐點項目。</param>
        protected AStrategy(MenuModel.Discount strategyType, List<MenuItem> items)
        {
            this.strategyType = strategyType;
            this.items = items;
        }

        /// <summary>
        /// 抽象方法 — 所有子類別都必須實作此方法以定義折扣邏輯。  
        /// <para>各策略需在此方法中根據條件套用對應優惠計算，  
        /// 並可能直接修改 <see cref="items"/> 清單內容。</para>
        /// </summary>
        public abstract void DiscountOrder();
    }
}
