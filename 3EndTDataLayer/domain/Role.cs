using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    class Role : BaseDomain
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
