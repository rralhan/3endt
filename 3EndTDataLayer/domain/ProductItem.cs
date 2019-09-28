using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class ProductItem : BaseDomain
    {
        public int? ProductItemId { get; set; }

        public string ProductSKU { get; set; }

        public int ProductFilterId { get; set; }

        public int ProductId { get; set; }

    }

}
