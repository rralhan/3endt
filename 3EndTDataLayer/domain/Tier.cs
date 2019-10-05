using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Tier : BaseDomain
    {
        public int? TierId { get; set; }

        public string TierName { get; set; }    

        public bool? IsDefault { get; set; }

    }

}
