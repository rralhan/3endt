using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Product : BaseDomain
    {
        public int? ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public string ImageUrl { get; set; }

         public int CategoryId { get; set; }

    }
}
