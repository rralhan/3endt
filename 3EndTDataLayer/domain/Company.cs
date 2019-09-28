using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Company : BaseDomain
    {
        public int? CompanyId { get; set; }
        public int TierId { get; set; }
        public string CompanyName { get; set; }
        public string FederalId { get; set; }
        public bool IsSpecial { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public int? ParentCompanyId { get; set; }

    }
}
