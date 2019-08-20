using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer.BusinessObject
{
    public class CompanyAddress
    {
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsCompanyActive { get; set; }
        public bool IsAddressPrimary { get; set; }
        public bool AddressType { get; set; }
    }
}
