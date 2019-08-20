using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTDataLayer;
using _3EndTBusinessLayer.BusinessObject;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageCompanyShippingAddress : System.Web.UI.Page
    {
        //TODO: Delete shipping address
        private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanyName();
                SetInitialState();
            }

   
            lblMessage.Text = string.Empty;
        }

        private void SetInitialState()
        {
            pnlShipping.Visible = false;
            ResetControls();
            LoadShippingAddressGrid();
        }

        private void LoadShippingAddressGrid()
        {
            gvShippingAddress.DataSource = CompanyManager.GetCompanyAddresses();
            gvShippingAddress.DataBind();
        }

        protected void LoadCompanyName()
        {
            List<Company> companies = CompanyManager.GetAllCompanies();

            ddlCompanyName.DataSource = companies;
            ddlCompanyName.DataTextField = "CompanyName";
            ddlCompanyName.DataValueField = "CompanyId";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem(" -- Select Company --","-1"));

            LoadShippingState();
        }

        protected void LoadShippingState()
        {
            ddlShippingState.DataSource = CompanyManager.GetStates();
            ddlShippingState.DataTextField = "name";
            ddlShippingState.DataValueField = "abbreviation";
            ddlShippingState.DataBind();
            ddlShippingState.Items.Insert(0, new ListItem(" -- Select a State --", "-1"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();

            if (!this.Page.IsValid)
                return;

            int companyid = Convert.ToInt32(ddlCompanyName.SelectedValue);

            Address newsa = new Address
            {
                CompanyId = companyid,
                IsPrimary = chkIsPrimary.Checked,
                AddressName = txtShippingName.Text,
                AddressLine1 = txtShippingAddress1.Text,
                AddressLine2 = txtShippingAddress2.Text,
                City = txtShippingCity.Text,
                State = ddlShippingState.SelectedValue,
                IsActive = chkIsActive.Checked,
                Type = AddressType.Shipping,
                Zipcode = txtZipCode.Text
            };

            //Make sure that only one shipping address isPrimary
            if (newsa.IsPrimary)
            {
                List<Address> allcsa = CompanyManager.GetAddressesByCompanyId(newsa.CompanyId);
                foreach(Address sa in allcsa)
                {
                    sa.IsPrimary = false;
                    CompanyManager.UpdateAddress(sa);
                }
            }
            
            if (_currentFormMode == Enums.FormMode.Save)
            {
                if (!CompanyManager.CheckIfAddressAlreadyExists(newsa))
                {
                    CompanyManager.InsertAddress(newsa);
                    lblMessage.Text = "Your Data has been saved !!";
                    SetInitialState();
                    ddlCompanyName.SelectedIndex = 0;
                }
            }
            if (_currentFormMode == Enums.FormMode.Update)
            {
                if (Convert.ToInt32(ddlShippingAddress.SelectedValue) > 0)
                {
                    newsa.AddressId = Convert.ToInt32(ddlShippingAddress.SelectedValue);
                    CompanyManager.UpdateAddress(newsa);                    
                    SetInitialState();
                    lblMessage.Text = "Your Data has been updated !!";
                    ddlCompanyName.SelectedIndex = 0;
                }
            }   
        }
       
        
        protected void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompanyName.SelectedIndex > 0)
            {                
                List<Address> compshipaddrs = CompanyManager.GetAddressesByCompanyId(Convert.ToInt32(ddlCompanyName.SelectedValue));
                
                if (compshipaddrs != null && compshipaddrs.Count > 0)
                {
                    pnlShipping.Visible = true;
                    ddlShippingAddress.Items.Clear();
                    ddlShippingAddress.DataSource = compshipaddrs;
                    ddlShippingAddress.DataTextField = "AddressName";
                    ddlShippingAddress.DataValueField = "AddressId";
                    ddlShippingAddress.DataBind();

                    ddlShippingAddress.Items.Insert(0, new ListItem("Add New Shipping Address", "0"));
                    ddlShippingAddress.Items.Insert(0, new ListItem("-- Select Shipping Address -- ", "-1"));
                    
                }
            }
        }

        protected void ddlShippingAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlShippingInfo.Visible = true;
            if (Convert.ToInt32(ddlShippingAddress.SelectedValue) > 0)
            {                
                int shipaddressid = Convert.ToInt32(ddlShippingAddress.SelectedValue);
                Address compshipaddrs = CompanyManager.GetAddressByID(shipaddressid);
                if (compshipaddrs != null)
                {                   
                    txtShippingName.Text = compshipaddrs.AddressName;
                    txtShippingAddress1.Text = compshipaddrs.AddressLine1;
                    txtShippingAddress2.Text = compshipaddrs.AddressLine2;
                    txtShippingCity.Text = compshipaddrs.City;
                    ddlShippingState.SelectedValue = compshipaddrs.State;
                    txtZipCode.Text = compshipaddrs.Zipcode;
                    chkIsPrimary.Checked = compshipaddrs.IsPrimary;
                    chkIsActive.Checked = compshipaddrs.IsActive;
                    btnSave.Text = "Update";
                    _currentFormMode = Enums.FormMode.Update;
                }
            }
            if (Convert.ToInt32(ddlShippingAddress.SelectedValue) == 0)
                ResetControls();
            
        }

        protected void ResetControls()
        {        
            chkSameAsBilling.Checked = false;
            txtShippingName.Text = string.Empty;
            txtShippingAddress1.Text = string.Empty;
            txtShippingAddress2.Text = string.Empty;
            txtShippingCity.Text = string.Empty;
            ddlShippingState.SelectedIndex = 0;
            txtZipCode.Text = string.Empty;
            chkIsPrimary.Checked = true;
            chkIsActive.Checked = true;
            btnSave.Text = "Save";
            _currentFormMode = Enums.FormMode.Save;
        }

        protected void chkSameAsBilling_CheckedChanged(object sender, EventArgs e)
        {
            int companyid = Convert.ToInt32(ddlCompanyName.SelectedValue);
            if (companyid > 0)
            {
                Company company = CompanyManager.GetCompanyByCompanyId(companyid);
                if (chkSameAsBilling.Checked)
                {
                    Address billingaddr = CompanyManager.GetAddressesByCompanyId(companyid, AddressType.Billing).FirstOrDefault<Address>();
                    if (billingaddr != null)
                    {
                        txtShippingName.Text = billingaddr.AddressName == null ? string.Empty : billingaddr.AddressName;
                        txtShippingAddress1.Text = billingaddr.AddressLine1;
                        txtShippingAddress2.Text = billingaddr.AddressLine2 == null ? string.Empty : billingaddr.AddressLine2;
                        txtShippingCity.Text = billingaddr.City;
                        txtZipCode.Text = billingaddr.Zipcode;
                        ddlShippingState.SelectedValue = billingaddr.State;
                    }
                }
                else
                {
                    txtShippingAddress1.Text = string.Empty;
                    txtShippingAddress2.Text = string.Empty;
                }
            }             
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetInitialState();
        }

        
    }
}