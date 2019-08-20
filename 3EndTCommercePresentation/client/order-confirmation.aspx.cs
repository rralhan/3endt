using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.client
{
    public partial class order_confirmation : System.Web.UI.Page
    {
        private string _confNum;
        public string ConfirmationNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["conf"]))
                {
                    _confNum = Request.QueryString["conf"];
                }
                return _confNum;
            }
        }

        private string _poNum;
        public string PurchaseOrderNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["po"]))
                {
                    _poNum = Request.QueryString["po"];
                }
                return _poNum;
            }
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}