using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.admin
{
    public partial class ManageProductItemPrice : System.Web.UI.Page
    {
        private static string _product = string.Empty;
        private List<Tuple<TierProduct, TierProductPrice>> _listRegTPP = null;
        private List<Tuple<TierProduct, TierProductPrice>> _listTierTPP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTiers();                
            }   
        }
        private void LoadTiers()
        {
            ddlTiers.DataSource = TierManager.GetAllTiers();
            ddlTiers.DataTextField = "TierName";
            ddlTiers.DataValueField = "TierId";
            ddlTiers.DataBind();

            ddlTiers.SelectedIndex = 0;
        }
        private void LoadProductItems()
        {
            //For Regular Tier
            _listRegTPP = ProductManager.GetAssociatedProductPricesByTier(1);
            _listTierTPP = ProductManager.GetAssociatedProductPricesByTier(Convert.ToInt16(ddlTiers.SelectedValue));

            lblTierHeader.Text=  ddlTiers.SelectedItem.Text + " Tier";

            List<ProductItemInfo> lpii = ProductManager.GetAllProductItemInfo();
            lvProductItems.DataSource = lpii;
            lvProductItems.DataBind();            
        }

        protected void ddlTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For Regular Tier
            _listRegTPP = ProductManager.GetAssociatedProductPricesByTier(1);
            _listTierTPP = ProductManager.GetAssociatedProductPricesByTier(Convert.ToInt16(ddlTiers.SelectedValue));
            LoadProductItems();
        }


        protected void lvProductItems_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Control cntrl = e.Item.FindControl("lblProduct");
                if (cntrl != null)
                {
                    Label lblproduct = cntrl as Label;
                    HtmlTableRow tr = e.Item.FindControl("rowProduct") as HtmlTableRow;
                    if (lblproduct.Text != _product)
                    {
                        _product = lblproduct.Text;
                        tr.Style.Add("display", "");
                    }
                    else
                        tr.Style.Add("display", "none");
                }
                cntrl = e.Item.FindControl("hdnProductItemId");
                if (cntrl != null)
                {
                    HiddenField hdnproductitemid = cntrl as HiddenField;
                    int productitemid = Convert.ToInt32(hdnproductitemid.Value);
                    TextBox txtTierPrices = e.Item.FindControl("txtTierPrices") as TextBox;
                    if (_listRegTPP != null)
                    {
                        Label lblregtierprices = e.Item.FindControl("lblRegularTierPrices") as Label;
                        decimal regpr = Convert.ToDecimal(_listRegTPP.Where(x => (x.Item1 != null && x.Item1.ProductItemId == productitemid)).Select(x => x.Item2.Price).SingleOrDefault());
                        lblregtierprices.Text = string.Format("$ {0:#,###0.00}", regpr);
                        txtTierPrices.Text = string.Format("{0:#,###0.00}", regpr);
                        if(regpr == -9999)
                        {
                            lblregtierprices.Text = "rfq";
                            txtTierPrices.Text = "rfq";
                        }
                    }

                    if(_listTierTPP != null)
                    {
                        decimal tierpr = Convert.ToDecimal(_listTierTPP.Where(x => (x.Item1 != null && x.Item1.ProductItemId == productitemid)).Select(x => x.Item2.Price).SingleOrDefault());
                        txtTierPrices.Text = string.Format("{0:#,###0.00}", tierpr);
                        if (tierpr == -9999)
                            txtTierPrices.Text = "rfq";
                    }
                    
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            int productitemid = 0;
            int tierid = Convert.ToInt32(ddlTiers.SelectedValue);
            foreach(ListViewItem lv in lvProductItems.Items)
            {
                Control cntrl = lv.FindControl("txtTierPrices");
                if (cntrl != null)
                {
                    TextBox tb = cntrl as TextBox;
                    if (tb.Text != string.Empty)
                    {
                        if (tb.Text.ToLower().Contains("rfq"))
                            price = -9999;
                        else
                            price = Convert.ToDecimal(tb.Text);
                    }
                    cntrl = lv.FindControl("hdnProductItemId");
                    if (cntrl != null)
                    {
                        HiddenField hdnproductitemid = cntrl as HiddenField;
                        productitemid = Convert.ToInt32(hdnproductitemid.Value);
                    }

                    if (productitemid != 0 && (price > 0 || price == -9999))
                        ProductManager.UpdateTierProductPrices(tierid, productitemid, price);
                }
            }
        }



        protected void dpProductItems_PreRender(object sender, EventArgs e)
        {
            LoadProductItems();
        }
    }
}