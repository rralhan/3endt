using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Filter : BaseDomain
    {
        public int? FilterId { get; set; }
        public int FilterTypeId { get; set; }
        public string FilterValue { get; set; }
    }
    public class FilterType : BaseDomain
    {
        public int? FilterTypeId { get; set; }

        public string FilterTypeName { get; set; }
    }
}
