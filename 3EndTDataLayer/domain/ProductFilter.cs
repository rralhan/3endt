using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class ProductFilter : BaseDomain
    {
        public int? ProductFilterId { get; set; }

        public int PrimaryFilterId { get; set; }

        public int SecondaryFilterId { get; set; }
    }
}
