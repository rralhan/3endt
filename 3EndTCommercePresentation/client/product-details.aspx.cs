using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.Client
{
    public partial class product_details : System.Web.UI.Page
    {
        private static int _tierId = 1;
        private static int _productId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.CompanyId > 0)
                    _tierId = CompanyManager.GetCompanyByCompanyId(SessionManager.CompanyId).TierId;
                if (Request.QueryString["_pid"] == null && Request.UrlReferrer != null)
                    Response.Redirect(Request.UrlReferrer.ToString());
                _productId = int.Parse(Request.QueryString["_pid"].ToString());
                LoadProductInfo();
            }
        }
        private void LoadProductInfo()
        {
            var prod = ProductManager.GetProductById(_productId);
            List<ProductItemInfo> pilist = ProductManager.GetProductItemInfoByProductId(_productId);
            JavaScriptSerializer jss = new JavaScriptSerializer();

            lblProductName.Text = prod.ProductTitle;
            
            imgProduct.Src = prod.ImageUrl;
            lblProductDesc.Text = HttpUtility.HtmlDecode(prod.Description);
            if (User.Identity.IsAuthenticated)
            {
                DropDownList ddlprimaryfilter = Utility.FindControlRecursive(lvItemPrice, "ddlPrimaryFilter") as DropDownList;
                if (!IsPostBack)
                    Utility.BindDropDowns(pilist, "PrimaryFilterValue", "PrimaryFilterId", ddlprimaryfilter);

                DropDownList ddlsecondaryfilter = Utility.FindControlRecursive(lvItemPrice, "ddlSecondaryFilter") as DropDownList;
                LinkButton btncart = Utility.FindControlRecursive(lvItemPrice, "lnkCart") as LinkButton;
                var btnrfq = Utility.FindControlRecursive(lvItemPrice, "lnkRFQ") as HtmlAnchor;

                var lblSKU = Utility.FindControlRecursive(lvItemPrice, "lblSKU") as Label;

                HiddenField hdnproductitems = Utility.FindControlRecursive(lvItemPrice, "hdnProductItems") as HiddenField;
                Label lblproductitemprice = Utility.FindControlRecursive(lvItemPrice, "lblProductItemPrice") as Label;
                Label lblproductunit = Utility.FindControlRecursive(lvItemPrice, "lblProductUnit") as Label;

                Label lblprimaryfiltertype = Utility.FindControlRecursive(lvItemPrice, "lblPrimaryFilterType") as Label;
                Label lblsecondaryfiltertype = Utility.FindControlRecursive(lvItemPrice, "lblSecondaryFilterType") as Label;

                if (pilist == null || pilist.Count <= 0)
                {
                    ddlprimaryfilter.Visible = false;
                    ddlsecondaryfilter.Visible = false;
                    btncart.Visible = false;
                }
                else if (pilist.Count == 1 && pilist[0].PrimaryFilterValue.Trim() == string.Empty)
                {
                    ddlprimaryfilter.Visible = false;
                    ddlsecondaryfilter.Visible = false;
                    hdnproductitems.Value = jss.Serialize(pilist);
                    //lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                    lblproductunit.Text = "/ " + pilist[0].ProductUnit;
                    lblSKU.Text = pilist[0].ProductSKU;
                    if (pilist[0].Price < 0)
                    {
                        btnrfq.Style.Add("display", "");
                        btnrfq.Attributes.Add("href", "~/client/contact-us.aspx?urlrefer=3&sku="+lblSKU.Text);
                        btncart.ToDisplayNone();
                    }
                    else
                    {
                        lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                        btnrfq.Style.Add("display", "none");
                        btncart.ToDisplayBlock();
                    }
                }
                else
                {
                    TextInfo myti = new CultureInfo("en-US", false).TextInfo;

                    hdnproductitems.Value = jss.Serialize(pilist);
                    lblprimaryfiltertype.Text = myti.ToTitleCase(pilist[0].PrimaryFilterType.Replace("Product", "")) + " : ";
                    ddlprimaryfilter.Attributes.Add("onchange", "jsProducts.showPrice('" + hdnproductitems.ClientID + "','" + ddlprimaryfilter.ClientID + "', '" + ddlsecondaryfilter.ClientID + "','" + lblproductitemprice.ClientID + "');");
                    //lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                    lblproductunit.Text = "/ " + pilist[0].ProductUnit;
                    List<ProductItemInfo> testpii = pilist.Where(p => p.SecondaryFilterValue != string.Empty).ToList();
                    lblSKU.Text = pilist[0].ProductSKU;
                    if (testpii.Count > 0)
                    {
                        // Do secondary filter stuff here.

                        testpii = testpii.Where(p => p.PrimaryFilterId == Convert.ToInt32(ddlprimaryfilter.SelectedValue)).ToList(); ;
                        lblsecondaryfiltertype.Text = myti.ToTitleCase(pilist[0].SecondaryFilterType.Replace("Product", "")) + " : ";
                        if (!IsPostBack)
                        {
                            //ddlprimaryfilter.AutoPostBack = true;
                            Utility.BindDropDowns(testpii, "SecondaryFilterValue", "SecondaryFilterId", ddlsecondaryfilter);
                            ddlprimaryfilter.Attributes.Add("onchange", "jsProducts.displaySecondDropdown('" + hdnproductitems.ClientID + "','" + ddlprimaryfilter.ClientID + "', '" + ddlsecondaryfilter.ClientID + "');" + @"
                                                                               jsProducts.showPrice('" + hdnproductitems.ClientID + "','" + ddlprimaryfilter.ClientID + "', '" + ddlsecondaryfilter.ClientID + "','" + lblproductitemprice.ClientID + "');");
                            ddlsecondaryfilter.Attributes.Add("onchange", "jsProducts.showPrice('" + hdnproductitems.ClientID + "','" + ddlprimaryfilter.ClientID + "', '" + ddlsecondaryfilter.ClientID + "','" + lblproductitemprice.ClientID + "');");
                            ddlsecondaryfilter.Visible = true;
                            ddlsecondaryfilter.ToDisplayBlock();
                        }
                    }
                    else
                        ddlsecondaryfilter.Visible = false;

                    //Display Request for quote
                    if (pilist[0].Price < 0)
                    {
                        btnrfq.Style.Add("display", "");
                        btnrfq.Attributes.Add("href", "~/client/contact-us.aspx?urlrefer=3&sku=" + lblSKU.Text);
                        btncart.ToDisplayNone();
                    }
                    else
                    {
                        lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                        btnrfq.Style.Add("display", "none");
                        btncart.ToDisplayBlock();
                    }
                }

            }
        }

        protected void lnkCart_Click(object sender, EventArgs e)
        {
            DropDownList ddlprimaryfilter = Utility.FindControlRecursive(lvItemPrice, "ddlPrimaryFilter") as DropDownList;
            DropDownList ddlsecondaryfilter = Utility.FindControlRecursive(lvItemPrice, "ddlSecondaryFilter") as DropDownList;

            List<ProductItemInfo> pilist = ProductManager.GetProductItemInfoByProductId(_productId, _tierId);
            var query = pilist.Where(p => p.PrimaryFilterId == Convert.ToInt32(ddlprimaryfilter.SelectedValue));
            if (ddlsecondaryfilter != null && ddlsecondaryfilter.SelectedValue != string.Empty)
                query = query.Where(p => p.SecondaryFilterId == Convert.ToInt32(ddlsecondaryfilter.SelectedValue));

            ShoppingCart1.AddToCart(query.FirstOrDefault());                      
         
        }
    }
}