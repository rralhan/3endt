using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _3EndTDataLayer;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System.Web.Security;

namespace _3EndTCommercePresentation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = this.Login1.UserName.Trim();
            string password = this.Login1.Password.Trim();
            var customer = UserManager.ValidateUser(userName, password);
            if (customer != null)
            {
                Enums.UserRole userRole;
                if (customer.UserRole.RoleName.Equals("Administrator"))
                    userRole = Enums.UserRole.Administrator;
                else
                    userRole = Enums.UserRole.Customer;
                
                SessionManager.__doInitializeSession(customer.UserId.Value, customer.CompanyId, customer.FirstName, customer.LastName, customer.UserName, userRole);
                e.Authenticated = true;
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            switch (SessionManager.UserRole)
            {
                case Enums.UserRole.Administrator:
                    HttpContext.Current.Response.Redirect("~/admin/default.aspx");
                    break;
                case Enums.UserRole.Customer:
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                    break;
                default: break;
               
            }
        }
        
        
    }
}