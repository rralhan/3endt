using _3EndTBusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.MasterPages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (SessionManager.UserRole != Enums.UserRole.Administrator)
                Response.Redirect("/login.aspx");
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}