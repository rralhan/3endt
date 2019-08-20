using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace _3EndTBusinessLayer.BusinessObject
{
    public class SessionManager
    {
        public static int CustomerId
        {
            get
            {
                if (HttpContext.Current.Session["CustomerId"] == null)
                    return 0;
                return int.Parse(HttpContext.Current.Session["CustomerId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["CustomerId"] = value;
            }
        }

        public static int CompanyId
        {
            get
            {
                if (HttpContext.Current.Session["CompanyId"] == null)
                    return -1;
                return int.Parse(HttpContext.Current.Session["CompanyId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["CompanyId"] = value;
            }
        }

        public static String CustomerFirstName
        {
            get
            {
                return HttpContext.Current.Session["CustomerFirstName"].ToString();                
            }
            set
            {
                HttpContext.Current.Session["CustomerFirstName"] = value ;
            }
        }
        public static String CustomerLastName
        {
            get
            {
                return HttpContext.Current.Session["CustomerLastName"].ToString();
            }
            set
            {
                HttpContext.Current.Session["CustomerLastName"] = value;
            }
        }
        public static String UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                    return HttpContext.Current.Session["UserName"].ToString();
                return null;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        public static Enums.UserRole UserRole
        {
            get
            {
                if (HttpContext.Current.Session["UserRole"] == null)
                    return Enums.UserRole.Customer;
                return (Enums.UserRole)HttpContext.Current.Session["UserRole"];
            }
            set
            {
                HttpContext.Current.Session["UserRole"] = value;
            }
        }       
            

        public SessionManager(string customerFirstName, string customerLastName, string userName, Enums.UserRole userRole)
        {
            //CustomerFirstName = customerFirstName;
            //CustomerLastName = customerLastName;
            //UserName = userName;
            //UserRole = userRole;
        }

        public static void __doInitializeSession(int pCustomerId, int companyId, string customerFirstName, string customerLastName, string userName, Enums.UserRole userRole)
        {
            CustomerId = pCustomerId;
            CompanyId = companyId;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            UserName = userName;
            UserRole = userRole;
        }
    }
}
