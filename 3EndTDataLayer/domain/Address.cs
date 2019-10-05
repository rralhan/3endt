using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Address : BaseDomain
    {
        public int? AddressId { get; set; }
        public int? CompanyId { get; set; }
        public string AddressName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }   
        public bool IsPrimary { get; set; }
        public bool Type { get; set; }
    }
}
