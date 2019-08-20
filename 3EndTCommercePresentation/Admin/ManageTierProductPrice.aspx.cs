using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTDataLayer;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageTierProductPrice : System.Web.UI.Page
    {
        public static int TierId { get; set; }
        public static string TierName { get; set; }
        public static List<TierProductPrice> tireProductPrices = new List<TierProductPrice>();
        public static List<Customer> customers = new List<Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Visible = false;
                btnReset.Visible = false;
                LoadTier();

            }
            else
            {
                if (this.Request.Form["__EVENTTARGET"].Contains("_invoketier_event"))
                {
                    List<string> __targeteventarguments = this.Request.Form["__EVENTTARGET"].Split(':').ToList();
                    TierId = int.Parse(__targeteventarguments.Last());
                    TierName = __targeteventarguments.ElementAt(1).ToString();
                    lblCurrentTier.Text = TierName;
                    LoadTierProductPrice();
                    btnSave.Visible = true;
                    btnReset.Visible = true;
                }
            }

        }
        private void LoadTier()
        {
            List<Tier> Tiers = TierManager.GetAllTiers();
            if (Tiers != null)
            {
                this.dgvTiers.DataSource = Tiers;
                this.dgvTiers.DataBind();
            }
        }
      
        private void LoadTierProductPrice()
        {

            List<GetTierProductPriceByTierId_Result> TierProductPrices = TierManager.GetAllTierProductPricesByTierId(TierId);

            gvTierProductPrices.DataSource = TierProductPrices;
            gvTierProductPrices.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //List<TierProductPrice> tireProductPrices = new List<TierProductPrice>();
            foreach (GridViewRow Row in gvTierProductPrices.Rows)
            {
                Label lblTierProductId = Row.FindControl("lblTierProductId") as Label;
                long tierProducId = int.Parse(lblTierProductId.Text.ToString());
                TextBox TextRetailPrice = Row.FindControl("txtRetailPrice") as TextBox;
                //TextBox TextPreferredPrice = Row.FindControl("txtPreferredPrice") as TextBox;
                decimal RetailPrice = decimal.Parse(TextRetailPrice.Text.Trim() == string.Empty ? "0" : TextRetailPrice.Text.Trim());

                TierProductPrice tierProductPrice = new TierProductPrice();
                tierProductPrice.TierProductId = tierProducId;
                tierProductPrice.Price = RetailPrice;


                tireProductPrices.Add(tierProductPrice);
            }
           
            
            if (TierManager.AddTiertProductPrice(tireProductPrices))
            {                
                lblMessage.Text = "Data Saved";
            }
            else
            {
                lblMessage.Text = "Data Save Failed";
            }

        }
       
        protected void btnReset_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in gvTierProductPrices.Rows)
            {
                TextBox TextRetailPrice = Row.FindControl("txtRetailPrice") as TextBox;
                //TextBox TextPreferredPrice = Row.FindControl("txtPreferredPrice") as TextBox;
                TextRetailPrice.Text = string.Empty;
                //TextPreferredPrice.Text = string.Empty;
            }

        }
    }
}