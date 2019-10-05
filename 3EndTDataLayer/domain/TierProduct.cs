using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
   public class TierProduct : BaseDomain
    {
        public int? TierProductId { get; set; }

        public int TierId { get; set; }

        public int ProductItemId { get; set; }

    }
}
