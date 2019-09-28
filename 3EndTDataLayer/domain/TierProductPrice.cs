using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class TierProductPrice : BaseDomain
    {
        public int TierProductPriceId { get; set; }

        public int? TierProductId { get; set; }

        public decimal? Price { get; set; }

        public int? SpecialCompanyId { get; set; }

        public decimal? SpecialDiscountPercent { get; set; }

        public decimal? SpecialDiscountPrice { get; set; }
    }
}
