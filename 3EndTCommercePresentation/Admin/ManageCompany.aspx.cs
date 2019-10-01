using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTDataLayer;
using _3EndTBusinessLayer.BusinessObject;
using System.Text;
using _3EndTDataLayer.domain;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageCompany : System.Web.UI.Page
    { 
        //TODO: Delete functionality
       private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
       private static int _companyId = 0; 
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack)
               LoadCompany();
       }

        protected void btnQuestionYes_Click(object sender, EventArgs e)
        {
            mvManageCompany.ActiveViewIndex = 1;
        }

        protected void btnQuestionNo_Click(object sender, EventArgs e)
        {
            mvManageCompany.ActiveViewIndex = 2;
        }

        protected void btnParentSave_Click(object sender, EventArgs e)
        {
            string parent = txtParentCompany.Text.Trim();
            if (!CompanyManager.CheckIfParentExists(parent))
            {
                ParentCompany pcomp = new ParentCompany() { FederalId = txtParentFederal.Text.Trim(), Name = parent };
                if (_currentFormMode == Enums.FormMode.Save)
                    CompanyManager.InsertParentCompany(pcomp);
                mvManageCompany.ActiveViewIndex = 2;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtParentCompany.Text = string.Empty;
            txtParentFederal.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFaxNumber.Text = string.Empty;
            txtBillingAddressLine1.Text = string.Empty;
            txtBillingAddressLine2.Text = string.Empty;
            txtBillingCity.Text = string.Empty;
            txtBillingZipCode.Text = string.Empty;
            txtFederalId.Text = string.Empty;
            txtPhone.Text = string.Empty;
           

            Button btn = sender as Button;
            if (btn.CommandName.ToString() == "compcancel")
                mvManageCompany.ActiveViewIndex = 2;
            else
                mvManageCompany.ActiveViewIndex = 1;
            if(_currentFormMode == Enums.FormMode.Update)            
                _currentFormMode = Enums.FormMode.Save;

            mvManageCompany.ActiveViewIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Company cmp = new Company();
            cmp.CompanyName = txtCompanyName.Text.Trim();
            cmp.FederalId = txtFederalId.Text.Trim();
            cmp.TierId = Convert.ToInt32(ddlTiers.SelectedValue);
            cmp.PhoneNumber = txtPhone.Text.Trim();
            cmp.FaxNumber = (txtFaxNumber.Text != null && txtPhone.Text != string.Empty) ? txtFaxNumber.Text.Trim() : string.Empty;
            cmp.EMailId = (txtEmailId.Text != null && txtEmailId.Text != string.Empty) ? txtEmailId.Text.Trim() : string.Empty;
            cmp.ParentCompanyId = Convert.ToInt32(ddlParentCompany.SelectedValue);
            cmp.IsActive = chkIsActive.Checked;

            Address addr = new Address
            {
                AddressLine1 = txtBillingAddressLine1.Text,
                AddressLine2 = txtBillingAddressLine2.Text,
                City = txtBillingCity.Text,
                State = ddlBillingState.SelectedValue,
                ZipCode = txtBillingZipCode.Text,
                Type = AddressType.Billing,
                CompanyId = cmp.CompanyId
            };


            if (_currentFormMode == Enums.FormMode.Save)
            {
                if (!CompanyManager.CheckIfCompanyExists(txtCompanyName.Text.Trim(), txtFederalId.Text.Trim()))
                {
                    CompanyManager.InsertCompany(cmp);
                    addr.CompanyId = cmp.CompanyId;
                    //Assuming that the address is new too
                    CompanyManager.InsertAddress(addr);
                }
                else
                    lblMessage.Text = "This Company name is not unique. Please enter a different name.";
            }
            else if (_currentFormMode == Enums.FormMode.Update)
            {
                cmp.CompanyId = addr.CompanyId = _companyId;
                CompanyManager.UpdateCompany(cmp);
                if(addr.Type == AddressType.Billing)
                {
                    if (!CompanyManager.CheckIfAddressAlreadyExists(addr))
                        CompanyManager.InsertAddress(addr);
                    else
                        CompanyManager.UpdateAddress(addr);
                }
            }
            LoadCompany();
            if (!lblMessage.Text.Contains("not unique"))
                lblMessage.Text = "Your Data has been saved !!";
            ResetControls();
            _currentFormMode = Enums.FormMode.Save;
        }

        private void ResetControls()
        {
            txtCompanyName.Text = string.Empty;
            txtBillingAddressLine1.Text = string.Empty;
            txtBillingAddressLine2.Text = string.Empty;
            txtFederalId.Text = string.Empty;
            ddlTiers.SelectedIndex = 0;
            txtPhone.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            ddlBillingState.SelectedIndex = 0;
            txtBillingZipCode.Text = string.Empty;
            txtBillingCity.Text = string.Empty;
        }

        protected void mvManageCompany_ActiveViewChanged(object sender, EventArgs e)
        {
            string av = mvManageCompany.GetActiveView().ID;
            if(av == "viewCompany")
            {
                ddlParentCompany.Items.Clear();
                var pclist = CompanyManager.GetParentCompanies();
                ddlParentCompany.DataSource = pclist;
                ddlParentCompany.DataTextField = "Name";
                ddlParentCompany.DataValueField = "ParentCompanyId";
                ddlParentCompany.DataBind();
                ddlParentCompany.Items.Insert(0, new ListItem(" -- Select -- ", "-1"));
               

                ddlTiers.Items.Clear();
                var tierlist = TierManager.GetAllTiers();
                ddlTiers.DataSource = tierlist;
                ddlTiers.DataTextField = "TierName";
                ddlTiers.DataValueField = "TierId";
                ddlTiers.DataBind();
                ddlTiers.Items.Insert(0, new ListItem(" -- Select -- ", "-1"));
            }
        }

        private void LoadCompany()
        {
            List<Company> companies = CompanyManager.GetAllCompanies();
            grdCompany.DataSource = companies;
            grdCompany.DataBind();

            ddlBillingState.DataSource = CompanyManager.GetStates();
            ddlBillingState.DataTextField = "name";
            ddlBillingState.DataValueField = "abbreviation";
            ddlBillingState.DataBind();
            ddlBillingState.Items.Insert(0, new ListItem(" -- Select a State --", "-1"));
        }

        protected void grdCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCompany.PageIndex = e.NewPageIndex;
            LoadCompany();
        }

        protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdedit")
            {
                mvManageCompany.ActiveViewIndex = 2;
                _companyId= int.Parse(e.CommandArgument.ToString());

                Company dbcomp = CompanyManager.GetCompanyByCompanyId(_companyId);
                txtCompanyName.Text = dbcomp.CompanyName;

                Address addr=  CompanyManager.GetAddressesByCompanyId(_companyId, AddressType.Billing).FirstOrDefault<Address>();
                txtBillingAddressLine1.Text = addr.AddressLine1;
                txtBillingAddressLine2.Text = addr.AddressLine2 ?? "";
                txtBillingCity.Text = addr.City;
                ddlBillingState.SelectedValue = addr.State;
                txtBillingZipCode.Text = addr.ZipCode;
                txtFederalId.Text = dbcomp.FederalId;
                txtPhone.Text = dbcomp.PhoneNumber;
                txtFaxNumber.Text = dbcomp.FaxNumber;
                txtEmailId.Text = dbcomp.Email;
                ddlParentCompany.SelectedValue = dbcomp.ParentCompanyId.ToString();
                ddlTiers.SelectedValue = dbcomp.TierId.ToString();
                chkIsActive.Checked = dbcomp.IsActive;
                
                _currentFormMode = Enums.FormMode.Update;
                
                btnCompanySave.Text = "Update";
            }
            if (e.CommandName == "cmddelete")
            {
                //delPanel.Visible = true;
                int companyid = int.Parse(e.CommandArgument.ToString());
            }
        }

        protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control cntrl = e.Row.FindControl("hdnParentCompanyId");
                HiddenField hf = null;
                if (cntrl != null)                
                    hf = cntrl as HiddenField;
                
                int pid = Convert.ToInt32(hf.Value);

                ParentCompany pc = CompanyManager.GetParentCompanyById(pid);
                cntrl = e.Row.FindControl("lblParentCompany");
                if(cntrl != null)
                {
                    Label lblpc = cntrl as Label;
                    lblpc.Text = pc.Name;
                }

                cntrl = e.Row.FindControl("hdnTierId");
                if (cntrl != null)
                    hf = cntrl as HiddenField;

                int tid = Convert.ToInt32(hf.Value);

                Tier tier = TierManager.GetTierById(tid);
                cntrl = e.Row.FindControl("lblTierName");
                if(cntrl != null)
                {
                    Label lbltier = cntrl as Label;
                    lbltier.Text = tier.TierName;
                }

            }
        }
       

    }
}