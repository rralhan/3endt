using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageTier : System.Web.UI.Page
    {
        public static int _tierId { get; set; }
        public static bool _isRequestFromGridview;
        private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadTiers();
        }
        protected void LoadTiers()
        {
            List<Tier> dbCategory = TierManager.GetAllTiers();
            grdTier.DataSource = dbCategory;
            grdTier.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();
            if (!this.Page.IsValid)
                return;

            string TierName = txtTierName.Text.Trim();            
            
            Tier dbTier = new Tier();
            dbTier.TierName = TierName;
            dbTier.IsActive = chkIsActive.Checked;
            dbTier.IsDefault = chkIsDefault.Checked;
            switch (_currentFormMode)
            {
                case Enums.FormMode.Save:
                    if (TierManager.CheckIfTierAlreadyExist(dbTier))
                    {
                        lblConfirmation.Text = "Tier Name Already Exists.";
                        return;
                    }
                    else
                    {
                        if (TierManager.InsertTier(dbTier))
                        {
                            lblConfirmation.Text = "Data Saved";
                            LoadTiers();
                            ResetControls();
                        }
                        else
                        {
                            lblConfirmation.Text = "Data Save Failed";
                        }
                    }
                    break;
                case Enums.FormMode.Update:
                    dbTier.TierId = _tierId;
                    if (TierManager.UpdateTier(dbTier))
                    {
                        _currentFormMode = Enums.FormMode.Save;
                        ResetControls();
                        LoadTiers();                        
                    }
                    break;
            }
        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();                     
        }

        protected void ResetControls()
        {
            this.txtTierName.Text = string.Empty;
            btnSave.Text = "Save";
            chkIsDefault.Checked = false;
            chkIsActive.Checked = true;
        }
        
        protected void grdTier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTier.PageIndex = e.NewPageIndex;
            LoadTiers();
        }

        protected void grdTier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdedit")
            {
                _tierId = int.Parse(e.CommandArgument.ToString());

                Tier Tier = TierManager.GetTierById(_tierId);
                txtTierName.Text = Tier.TierName;

                chkIsActive.Checked = Tier.IsActive;
                
                if (Tier.IsDefault != null)                
                    chkIsDefault.Checked = Convert.ToBoolean(Tier.IsDefault);
                
                _currentFormMode = Enums.FormMode.Update;
                btnSave.Text = "Update";
            }
            if (e.CommandName == "cmddelete")
            {                
                _tierId = int.Parse(e.CommandArgument.ToString());
            }
            //if (e.CommandName == "cmdCustomerTier")
            //{
            //    TierId = int.Parse(e.CommandArgument.ToString());


            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //    sb.Append(@"<script type='text/javascript'>");
            //    sb.Append("$('#detailModal').modal('show');");
            //    sb.Append(@"</script>");
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            //               "ModalScript", sb.ToString(), false);
            //    List<Customer> CustomerNotInTier = CustomerManger.GetCustomerNotInTier(TierId);
            //    gvCustomer.DataSource = CustomerNotInTier;
            //    gvCustomer.DataBind();
            //    IsRequestFromGridview = true;

            //}
        }

       /* protected void btnOk_Click(object sender, EventArgs e)
        {
            List<TierProductPrice> tierProductPrices = TierManager.GetTierProductPriceByTierId(TierId);

            List<Customer> selectedCustomers = new List<Customer>();
            List<CustomerTierProductPrice> customerTireProductPrices = new List<CustomerTierProductPrice>();
            CustomerTierProductPrice ctpp = null;

            //Iterating all the customers who are checked to be fit in the selected Tier.
            foreach (GridViewRow Row in gvCustomer.Rows)
            {
                CheckBox chkCustomerTier = Row.FindControl("chkCustomerTier") as CheckBox;
                if (chkCustomerTier.Checked)
                {
                    Label lblCustomerId = Row.FindControl("lblCustomerId") as Label;
                    long CustomerId = int.Parse(lblCustomerId.Text.ToString());
                    selectedCustomers.Add(new Customer() { CustomerId = CustomerId });

                    //Iterating the TireProductPrices so that all the prices are assigned to each of the selected Customer.
                    foreach (TierProductPrice tpp in tierProductPrices)
                    {
                        ctpp = new CustomerTierProductPrice();
                        ctpp.CustomerId = CustomerId;
                        ctpp.SpecialPrice = tpp.Price;
                        ctpp.TierProductId = tpp.TierProductId.Value;
                        customerTireProductPrices.Add(ctpp);
                    }
                }

            }


            if (TierManager.ApplyCustomerTierProductPrices(selectedCustomers, customerTireProductPrices))
            {
                lblConfirmation.Text = "Prices applied successfully.";
            }
            else
            {
                lblConfirmation.Text = "Data Save Failed";
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#detailModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                       "ModalScript", sb.ToString(), false);

        }

       protected void lnkAssignCustomers_Click(object sender, EventArgs e)
       {
           IsRequestFromGridview = false;
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.Append(@"<script type='text/javascript'>");
           sb.Append("$('#detailModal').modal('show');");
           sb.Append(@"</script>");
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                      "ModalScript", sb.ToString(), false);
           List<Customer> customers = CustomerManger.GetAllCustomers();
           gvCustomer.DataSource=customers;
           gvCustomer.DataBind();
       }
       */
    }
}