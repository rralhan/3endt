using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer.BusinessObject
{

    public class Enums
    {
        public enum UserRole
        {
            Administrator = 1,
            Customer            
        }
        public enum EmailSentStatus
        {
            Fail,
            Success
        }
        public enum FormMode
        {
            Save,
            Update
        }

        public enum Category
        {
            ParentId = 0
        }

        public enum PurchaseOrderStatus
        {
            Accepted = 1,
            Verified,
            Shipped,
            Payment_Error
        }
       
    }
}
