using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer.BusinessObject
{
    [Serializable]
    public struct AddressType
    {
       
        public const bool Shipping = false;
        public const bool Billing = true;

    }
}
