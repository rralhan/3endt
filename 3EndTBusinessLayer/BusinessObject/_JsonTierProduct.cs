using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer.BusinessObject
{

    public class _tierProductsObj
    {
        public _tierProductList productLists { get; set; }
    }

    public class _tierProductList
    {
        public List<_JsonTierProduct> tierProduct { get; set; }
    }
    public class _JsonTierProduct
    {
        public int TierId { get; set; }
        public int ProductId { get; set; }
    }
}
