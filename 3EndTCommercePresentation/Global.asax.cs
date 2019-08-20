using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace _3EndTCommercePresentation
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            ErrorLog(ex.ToString());
        }
        public void ErrorLog(string sErrMsg)
        {
            string errortime = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            bool exists = System.IO.Directory.Exists(Server.MapPath("/Error"));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("/Error"));

            StreamWriter sw = new StreamWriter(Server.MapPath("/Error/Error_" + errortime+".txt"), true);
            sw.WriteLine(sErrMsg);
            sw.WriteLine("======================================================================");
            sw.Flush();
            sw.Close();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}