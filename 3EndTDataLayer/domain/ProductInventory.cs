using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    class ProductInventory : BaseDomain
    {
        public int? ProductInventoryId { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityInStock { get; set; }
        public DateTime ProductAddedDate { get; set; }
        public bool IsStockCleared { get; set; }    

    }
}
