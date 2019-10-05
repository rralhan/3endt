using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Inventory : BaseDomain
    {
        public int? InventoryId { get; set; }

        public int ProductId { get; set; }

        public decimal QuantityInStock { get; set; }

        public DateTime ProductAddedDate { get; set; }

        public bool IsStockCleared { get; set; }

    }
}
