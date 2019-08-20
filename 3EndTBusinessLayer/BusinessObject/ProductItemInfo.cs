using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer.BusinessObject
{
    [Serializable]
    public class ProductItemInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ItemId { get; set; }

        public string ProductSKU { get; set; }

        public int PrimaryFilterTypeId { get; set; }
        public string PrimaryFilterType { get; set; }
        public int PrimaryFilterId { get; set; }
        public string PrimaryFilterValue { get; set; }
        public int SecondaryFilterTypeId { get; set; }
        public string SecondaryFilterType { get; set; }
        public int SecondaryFilterId { get; set; }
        public string SecondaryFilterValue { get; set; }
        public string ProductUnit { get; set; }
        
        public int TierId { get; set; }
        public decimal? Price { get; set; }
      }

    //[Serializable]
    //public class ProductItemPrices
    //{
    //    public ProductItemInfo ItemInfo { get; set; }
    //    public decimal? RegularTierPrice { get; set; }
    //    public int TierId { get; set; }
    //    public decimal? TierPrice { get; set; }
    //}
}
