using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.client
{
    public partial class contact_us : System.Web.UI.Page
    {
        private UrlReferred _urlreferred = UrlReferred.ContactUs;
        public UrlReferred UrlReferred
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["urlrefer"]))
                {
                    string turl = Request.QueryString["urlrefer"];
                    _urlreferred = (UrlReferred)Enum.Parse(typeof(UrlReferred), turl);
                }
                return _urlreferred;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UrlReferred == UrlReferred.ContactUs)
                    txtSubject.Text = string.Empty;
                else if (UrlReferred == UrlReferred.ForgotPassword)
                {
                    txtSubject.Text = "Forgot Password";
                    txtSubject.Enabled = false;
                    pnlUserId.Visible = true;
                }
                else if ((UrlReferred == UrlReferred.RFQ) && !string.IsNullOrEmpty(Request.QueryString["sku"]))
                {
                    txtSubject.Text = string.Format("Request for Quote for SKU : {0}", Request.QueryString["sku"].Trim());
                    txtSubject.Enabled = false;
                }
                else if (UrlReferred == UrlReferred.SignUp)
                {
                    txtSubject.Text = "I want to be a new member";
                    txtSubject.Enabled = false;
                }
                else
                    txtSubject.Text = string.Empty;
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                 string subject = txtSubject.Text.Trim();
                bool isvalid = true;
                if (UrlReferred == UrlReferred.ForgotPassword)
                {
                    if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                        isvalid = false;
                    else
                        subject = subject + " UserId: " + txtUserId.Text.Trim();
                }
                if (isvalid)
                {
                    Enums.EmailSentStatus emailstatus = EmailManager.SendEmail(subject, txtMessage.Text.Trim(), null, 0,
                        txtEmail.Text.Trim(), txtName.Text.Trim());
                }
                //if (emailstatus == Enums.EmailSentStatus.Fail)
                    //throw objexc;
            }
        }
    }
    public enum UrlReferred
    {
        ContactUs,
        ForgotPassword,
        SignUp,
        RFQ
    }


}