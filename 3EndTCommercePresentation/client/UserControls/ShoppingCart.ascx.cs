using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTCommercePresentation.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.client.UserControls
{
    public partial class UC_ShoppingCart : System.Web.UI.UserControl
    {
        private string _headerLabel = "Products";
        public string HeaderLabel
        {
            get
            {
                return _headerLabel;
            }
            set
            {
                _headerLabel = value;
            }
        }
                
        public bool IsUserAuthenticated
        {
            get
            {
                return Page.User.Identity.IsAuthenticated;
            }           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadShoppingCart();
            }
        }

        public void AddToCart(ProductItemInfo prodItemInfo)
        {
            if (prodItemInfo != null)
            {
                ShoppingCart.Instance.AddToCart(prodItemInfo);
                LoadShoppingCart();
            }
        }

        private void LoadShoppingCart()
        {
            //if (!IsUserAuthenticated)
            //    ShoppingCart.Instance.FlushShoppingCart();
            lvShoppingCart.DataSource = ShoppingCart.Instance.CartItems;
            lvShoppingCart.DataBind();
            if (ShoppingCart.Instance.CartItems.Select(x => x.Quantity).Sum() > 0)
            {
                spnCartQuantity.InnerText = Convert.ToString(ShoppingCart.Instance.CartItems.Select(x => x.Quantity).Sum());
                divDisplayCart.Style.Add("display", "block");
                spnCartQuantity.Visible = true;
            }
            else
                spnCartQuantity.Visible = false;
        }

        protected void lvShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                TextBox txtquantity = Utility.FindControlRecursive(e.Item as Control, "txtQuantity") as TextBox;
                Label lblprice = Utility.FindControlRecursive(e.Item as Control, "lblItemPriceTotal") as Label;
                txtquantity.Attributes.Add("onkeypress", "return jsShoppingCart.isNumber(event);");
                //txtquantity.Attributes.Add("onblur", "jsShoppingCart.updatePrice();");
                HtmlImage btnclose = Utility.FindControlRecursive(e.Item as Control, "imgBtnClose") as HtmlImage;
                btnclose.Attributes.Add("onclick", "jsShoppingCart.deleteItem(this,'" + txtquantity.ClientID + "');");

                HiddenField hdnproductitemid = Utility.FindControlRecursive(e.Item as Control, "hdnProductItemId") as HiddenField;
                int productitemid = Convert.ToInt32(hdnproductitemid.Value);

                Label lblprimaryfiltertype = Utility.FindControlRecursive(e.Item as Control, "lblPrimaryFilterType") as Label;
                Label lblprimaryfiltervalue = Utility.FindControlRecursive(e.Item as Control, "lblPrimaryFilterValue") as Label;
                Label lblsecondaryfiltertype = Utility.FindControlRecursive(e.Item as Control, "lblSecondaryFilterType") as Label;
                Label lblsecondaryfiltervalue = Utility.FindControlRecursive(e.Item as Control, "lblSecondaryFilterValue") as Label;

                List<ProductItemInfo> lpii = ProductManager.GetAllProductItemInfo();
                ProductItemInfo pii = lpii.SingleOrDefault(p => p.ItemId == productitemid);
                if (pii != null)
                {
                    if (pii.PrimaryFilterType.ToLower().Replace(' ', '_').IndexOf("no_f") > -1)
                    {
                        lblprimaryfiltertype.Visible = false;
                        lblprimaryfiltervalue.Visible = false;
                    }
                    else
                    {
                        lblprimaryfiltertype.Text = pii.PrimaryFilterType + ": ";
                        lblprimaryfiltervalue.Text = pii.PrimaryFilterValue;
                    }

                    if (pii.SecondaryFilterType.ToLower().Replace(' ', '_').IndexOf("no_f") > -1)
                    {
                        lblsecondaryfiltertype.Visible = false;
                        lblsecondaryfiltervalue.Visible = false;
                    }
                    else
                    {
                        lblsecondaryfiltertype.Text = pii.SecondaryFilterType + ": ";
                        lblsecondaryfiltervalue.Text = pii.SecondaryFilterValue;
                    }

                }
            }
        }

        protected void lnkCheckout_Click(object sender, EventArgs e)
        {
            //Just in case validate again from the JSON cart.
            ValidateFromJSONCart();
            Response.Redirect("~/client/purchase-order.aspx");
        }

        private void AddToCart()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<UserCart> usercarts = jss.Deserialize<List<UserCart>>(hdnShoppingCart.Value);
            if (usercarts == null)
                usercarts = new List<UserCart>();
            foreach(var uc in usercarts)
            {
                //Updating the quantity
                var cartitem = ShoppingCart.Instance.CartItems.FirstOrDefault(c => c.ProductItemId == uc.ItemId);
                if(cartitem != null && cartitem.Quantity != uc.Quantity)                
                    cartitem.Quantity = uc.Quantity;
                else
                {
                    List<ProductItemInfo> lpii = ProductManager.GetProductItemInfoByProductId(uc.ProductId, uc.TierId);
                    var pii = lpii.FirstOrDefault(x => x.ItemId == uc.ItemId);
                    if (pii != null)
                    {
                        for (int q = 1; q <= uc.Quantity; q++)
                        {
                            ShoppingCart.Instance.AddToCart(pii);
                        }
                    }
                }
            }
        }

        private void ValidateFromJSONCart()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<UserCart> tempcarts = jss.Deserialize<List<UserCart>>(hdnShoppingCart.Value);
            if (tempcarts != null)
            {
                foreach (UserCart tc in tempcarts)
                {
                    CartItem ci = ShoppingCart.Instance.CartItems.Find(c => c.ProductItemId == tc.ItemId);//.Single<CartItem>();
                    if (ci != null)
                    {
                        if (ci.Quantity != tc.Quantity)
                            ci.Quantity = tc.Quantity;
                        if (tc.Quantity <= 0)
                            ShoppingCart.Instance.CartItems.Remove(ci);
                    }
                }
            }
        }

        protected void MainLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void lnkDisplayCart_Click(object sender, EventArgs e)
        {
            AddToCart();
            LoadShoppingCart();        
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "jsShoppingCart.displayCart();", true);
        }       

    }
}