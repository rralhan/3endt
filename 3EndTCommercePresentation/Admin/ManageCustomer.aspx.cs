using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageCustomer : System.Web.UI.Page
    {
        //TODO: Update & Delete functionality.
        private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
        public string Password { get; set; }
        private static List<Company> _listComps;
        private static List<User> _listCusts;
        private static int _customerId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {             
            if (!IsPostBack)
            {
                LoadCompanies();               
                LoadCustomers();
                RandomPassword();
            }
            
        }


        public void RandomPassword()
        {
            var chars = "abcdefghijklmnopqr0123456789";
            var random = new Random();
            var result = new string(
            Enumerable.Repeat(chars, 6)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray());
            Password = result.ToString();
            Boolean isDuplicate = true;
            while (isDuplicate)
            {
                isDuplicate = UserManager.IsPasswordExist(Password);
                if (isDuplicate)
                    Password = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray()).ToString();
            }
            txtPassword.Text = Password;
        }

        private void LoadCompanies()
        {
            _listComps = CompanyManager.GetAllCompanies();
            ddlCompany.DataSource = _listComps;
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataValueField = "CompanyId";
            ddlCompany.DataBind();

            ddlCompany.Items.Insert(0,new ListItem(" -- Select Company --", "-1"));
        }


        protected void LoadCustomers()
        {
            _listCusts = UserManager.GetAllCustomers();
            grdCustomer.DataSource = _listCusts;
            grdCustomer.DataBind();

        }
        //protected void LoadCustomer()
        //{
        //    List<Customer> cust = CustomerManger.GetAllCustomers();
        //    grdCustomer.DataSource = cust;
        //    grdCustomer.DataBind();
        //}
      
      
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();
            if (!this.Page.IsValid)
                return;
             
            User cust = new User(); 
            cust.UserName=txtUserName.Text.Trim();
            cust.Password=txtPassword.Text.Trim();
            cust.RoleId=(int)Enums.UserRole.Customer;
            cust.FirstName = txtFirstName.Text.Trim();
            cust.LastName = txtLastName.Text.Trim();
            cust.IsActive = chkIsActive.Checked;
            cust.IsEmailSend = true;
            cust.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);

            if (_currentFormMode == Enums.FormMode.Save)
            {
                if (UserManager.CheckIfUserNameAlreadyExist(cust))
                {
                    lblMessage.Text = "User Name Already Exists.";
                    return;
                }

                if (UserManager.InsertUser(cust))
                {
                    lblMessage.Text = "New User Added.";
                    ResetControls();        
                }
                else
                    lblMessage.Text = "Data Save Failed";
            }
            else
             {
                 cust.UserId = _customerId;
                if (UserManager.UpdateCustomer(cust))
                {
                    ResetControls();
                    btnSave.Text = "Save";
                    _currentFormMode = Enums.FormMode.Save;
                }

            }
            LoadCustomers();
        }

        protected void ResetControls()
        {
            this.txtFirstName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            chkIsActive.Checked = true;           
            ddlCompany.SelectedValue = "-1";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        protected void grdCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCustomer.PageIndex = e.NewPageIndex;
            LoadCustomers();
        }
        /*
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            ddlTierName.Enabled = true;
            RandomPassword();
            txtPassword.Text = Password;
            btnSave.Text = "Save";
        }


        protected void btnNo_Click(object sender, EventArgs e)
        {
            delPanel.Visible = false;

        }
        protected void btnYes_Click(object sender, EventArgs e)
        {

        }

        */

        protected void grdCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int customerid = 0;
            if (e.CommandName == "cmdedit")
            {             
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                Control cntrl = row.FindControl("hdnCompanyId");
                if(cntrl != null)
                {
                    HiddenField hdncompid = cntrl as HiddenField;
                    ddlCompany.SelectedValue = hdncompid.Value;
                }
                cntrl = row.FindControl("hdnCustomerId");
                if(cntrl != null)
                {
                    HiddenField hdncustid = cntrl as HiddenField;
                    _customerId = Convert.ToInt32(hdncustid.Value);
                    User cust = _listCusts.Where(c => c.UserId == _customerId).FirstOrDefault<User>();
                    txtUserName.Text = cust.UserName.Trim();
                    txtPassword.Text = cust.Password.Trim();
                    txtFirstName.Text = cust.FirstName.Trim();
                    txtLastName.Text = cust.LastName.Trim();
                    chkIsActive.Checked = cust.IsActive;
                }
                btnSave.Text = "Update";
                _currentFormMode = Enums.FormMode.Update;
            }
            if (e.CommandName == "cmddelete")
            {               
                customerid = int.Parse(e.CommandArgument.ToString());
            }
        }

        protected void grdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if(e.Row.RowType == DataControlRowType.DataRow)
           {
               Control cntrl = e.Row.FindControl("hdnCompanyId");
               HiddenField hf = null;
               if (cntrl != null)
                   hf = cntrl as HiddenField;

               int compid = Convert.ToInt32(hf.Value);
               if(_listComps != null && _listComps.Count() > 0)
               {
                   Company comp = _listComps.Where(c => c.CompanyId == compid).FirstOrDefault<Company>();
                   cntrl = e.Row.FindControl("lblCompany");
                   if(cntrl != null)
                   {
                       Label lblCompany = cntrl as Label;
                       lblCompany.Text = comp.CompanyName;
                   }
               }
           
           }
        }
      
    }
}