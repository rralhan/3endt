using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTDataLayer;
namespace _3EndTCommercePresentation.admin
{
    public partial class ManageCustomerTierProductPrice : System.Web.UI.Page
    {
        public static int CustomerId { get; set; }
        public static string CustomerName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Visible = false;
                btnReset.Visible = false;
                LoadSpecialCustomer();

            }
            else
            {
                if (this.Request.Form["__EVENTTARGET"].Contains("_invoketier_event"))
                {
                    List<string> __targeteventarguments = this.Request.Form["__EVENTTARGET"].Split(':').ToList();
                    CustomerId = int.Parse(__targeteventarguments.Last());
                    CustomerName = __targeteventarguments.ElementAt(1).ToString();
                    lblSpecialCustomer.Text = CustomerName;
                    LoadCustomerTierProductPrice();
                    btnSave.Visible = true;
                    btnReset.Visible = true;
                }
            }

        }

        public string GetFormattedString(object firstName, object lastName, object CustomerId)
        {
            string _fName = (string)firstName, _lName = (string)lastName, returnValue = string.Empty;
            long customerId = (long)CustomerId;
            returnValue = string.Format("clickTier(\"_invoketier_event:{0}:{1}\")", _fName + " " + _lName, customerId);
            return returnValue;
        }
        private void LoadSpecialCustomer()
        {
            List<Customer> Customers = CustomerManger.GetAllSpecialCustomer();
            if (Customers != null)
            {
                this.dgvCustomers.DataSource = Customers;
                this.dgvCustomers.DataBind();
            }
        }
        private void LoadCustomerTierProductPrice()
        {
            List<GetCustomerTierProductListPriceByCustomerId_Result> CustomerTierProductPrice = CustomerManger.GetAllCustomerTierProductPriceByCustomerId(CustomerId);

            this.gvSpecialCustomerPrice.DataSource = CustomerTierProductPrice;
            this.gvSpecialCustomerPrice.DataBind();


        }
        private void ResetControls()
        {
            foreach (GridViewRow Row in gvSpecialCustomerPrice.Rows)
            {
                TextBox TextRetailPrice = Row.FindControl("txtRetailPrice") as TextBox;
                TextBox TextPreferredPrice = Row.FindControl("txtPreferredPrice") as TextBox;
                TextRetailPrice.Text = string.Empty;

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<CustomerTierProductPrice> customerTireProductPrices = new List<CustomerTierProductPrice>();
            foreach (GridViewRow Row in gvSpecialCustomerPrice.Rows)
            {
                Label lblTierProductId = Row.FindControl("lblTierProdutId") as Label;
                long TierProductId = int.Parse(lblTierProductId.Text.ToString());
                TextBox TextRetailPrice = Row.FindControl("txtRetailPrice") as TextBox;
                //TextBox TextPreferredPrice = Row.FindControl("txtPreferredPrice") as TextBox;
                decimal RetailPrice = decimal.Parse(TextRetailPrice.Text.Trim() == string.Empty ? "0" : TextRetailPrice.Text.Trim());

                CustomerTierProductPrice customerTierProductPrice = new CustomerTierProductPrice();
                customerTierProductPrice.CustomerId = CustomerId;
                customerTierProductPrice.TierProductId = TierProductId;
                customerTierProductPrice.SpecialPrice = RetailPrice;


                customerTireProductPrices.Add(customerTierProductPrice);


            }

            if (CustomerManger.AddTCustomeriertProductPrice(customerTireProductPrices))
            {
                lblMessage.Text = "Data Saved";
                ResetControls();

            }
            else
            {
                lblMessage.Text = "Data Save Failed";
            }


        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
    }
}