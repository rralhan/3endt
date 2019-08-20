using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;

namespace _3EndTCommercePresentation.client
{
    public partial class carts : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (SessionManager.CustomerId <= 0)
                Response.Redirect("~/Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dlCartItems.DataSource = ShoppingCart.Instance.GetCartItems();
                dlCartItems.DataBind();
            }
        }

        protected void ddlItemQuantity_SelectionChanged(object sender, EventArgs e)
        {
            DropDownList ddlItemQuantity = (DropDownList)sender;
            DropDownList ddlProductType = (DropDownList)ddlItemQuantity.FindControl("ddlProductType");

            ddlProductType_SelectedIndexChanged(ddlProductType, e);
        }

        protected void dlCartItems_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            List<CartItem> cartItems = ShoppingCart.Instance.GetCartItems();
            long productId = int.Parse(((HiddenField)e.Item.FindControl("hdProductId")).Value);

            CartItem cartItem = cartItems.Where(x => x.ProductId == productId).FirstOrDefault();
            List<GetParentProductFiltersByProductId_Result> productFilters = ProductManager.GetParentProductFiltersByProductId(productId);

            List<ProductItem> productTypes = null;
            List<ProductItem> dimensions = null;
            List<ProductItem> thickness = null;

            HtmlControl divType = (HtmlControl)e.Item.FindControl("divType");
            HtmlControl divDimension = (HtmlControl)e.Item.FindControl("divDimension");
            HtmlControl divThickness = (HtmlControl)e.Item.FindControl("divThickness");

            #region Load Filter Data
            if (productFilters.Count > 0)
            {
                foreach (GetParentProductFiltersByProductId_Result productFilter in productFilters)
                {
                    if (productFilter.ProductFilter == null) continue;
                    switch (productFilter.ProductFilter.ToString().ToLower())
                    {
                        case "type":
                            #region Display Product Types
                            DropDownList ddlProductType = (DropDownList)e.Item.FindControl("ddlProductType");
                            productTypes = ProductManager.GetProductFilterTypesByProductId(productId, "type");
                            ddlProductType.DataSource = productTypes;
                            ddlProductType.DataTextField = "ProductFilterValue";
                            ddlProductType.DataValueField = "ProductItemId";
                            ddlProductType.DataBind();
                            ddlProductType.SelectedValue = cartItem.ProductItemId.ToString();
                            #endregion
                            break;
                        case "dimension":
                            #region Display Dimension on DropDownList
                            DropDownList ddlDimension = (DropDownList)e.Item.FindControl("ddlDimension");
                            dimensions = ProductManager.GetProductFilterTypesByProductId(productId, "dimension");
                            ddlDimension.DataSource = dimensions;
                            ddlDimension.DataTextField = "ProductFilterValue";
                            ddlDimension.DataValueField = "ProductItemId";
                            ddlDimension.DataBind();
                            ddlDimension.SelectedValue = cartItem.ProductItemId.ToString();
                            #endregion
                            break;
                        case "thickness":
                            #region Display Dimension on DropDownList
                            DropDownList ddlThickness = (DropDownList)e.Item.FindControl("ddlThickness");
                            thickness = ProductManager.GetProductFilterTypesByProductId(productId, "thickness");
                            ddlThickness.DataSource = dimensions;
                            ddlThickness.DataTextField = "ProductFilterValue";
                            ddlThickness.DataValueField = "ProductItemId";
                            ddlThickness.DataBind();
                            ddlThickness.SelectedValue = cartItem.ProductItemId.ToString();
                            #endregion

                            break;
                        default: break;
                    }
                }
            }
            else
            {
                HtmlControl divFilters = (HtmlControl)e.Item.FindControl("divFilters");
                divFilters.Style.Add("display", "none");
            }
            #endregion

            #region Display Item Quantity
            DropDownList ddlItemQuantity = (DropDownList)e.Item.FindControl("ddlItemQuantity");
            ddlItemQuantity.SelectedValue = cartItem.Quantity.ToString();
            #endregion

            #region display filter data
            switch (productFilters.Count)
            {
                case 1:
                    //divType.Style.Add("display", "none");
                    divDimension.Style.Add("display", "none");
                    divThickness.Style.Add("display", "none");
                    break;
                case 2:
                    //divType.Style.Add("display", "none");
                    //divDimension.Style.Add("display", "none");
                    divThickness.Style.Add("display", "none");
                    break;
                case 3:
                    break;
                default:
                    divType.Style.Add("display", "none");
                    divDimension.Style.Add("display", "none");
                    divThickness.Style.Add("display", "none");
                    break;
            }
            #endregion
        }

        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProductType = (DropDownList)sender;

            HiddenField hdProductItemId = (HiddenField)ddlProductType.NamingContainer.FindControl("hdProductItemId");
            Label lblItemPrice = (Label)ddlProductType.NamingContainer.FindControl("lblItemPrice");
            Label lblItemPriceTotal = (Label)ddlProductType.NamingContainer.FindControl("lblItemPriceTotal");
            DropDownList ddlItemQuantity = (DropDownList)ddlProductType.FindControl("ddlItemQuantity");

            hdProductItemId.Value = ddlProductType.SelectedValue.ToString();
            int productItemId = int.Parse(hdProductItemId.Value);
            int quantity = int.Parse(ddlItemQuantity.SelectedValue.ToString());

            GetCustomerProductPrice_Result customerProductPrice = ProductManager.GetCustomerProudctItemPrice(SessionManager.CustomerId, productItemId);
            lblItemPrice.Text = customerProductPrice.SpecialPrice.ToString();

            hdProductItemId.Value = customerProductPrice.ProductItemId.ToString();
            lblItemPriceTotal.Text = (quantity * decimal.Parse(lblItemPrice.Text.Trim())).ToString();

            //DropDownList ddlDimension = (DropDownList)ddlProductType.NamingContainer.FindControl("ddlDimension");
            //int parentProductFilterId = int.Parse(ddlProductType.SelectedValue.ToString());
            //List<ProductFilter> dimensions = ProductManager.GetProductChildFiltersByParentFilterId(parentProductFilterId);
            //ddlDimension.DataSource = dimensions;
            //ddlDimension.DataTextField = "ProductFilterName";
            //ddlDimension.DataValueField = "ProductFilterId";
            //ddlDimension.DataBind();
            //ddlDimension_SelectedIndexChanged(ddlDimension, e);

        }

        protected void ddlDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ignored for now.   Marked by Ram.
            //DropDownList ddlDimension = (DropDownList)sender;
            //HtmlControl divFilters = (HtmlControl)ddlDimension.NamingContainer.FindControl("divFilters");
            //DropDownList ddlItemQuantity = (DropDownList)ddlDimension.FindControl("ddlItemQuantity");
            //Label lblItemPrice = (Label)ddlDimension.NamingContainer.FindControl("lblItemPrice");
            //Label lblItemPriceTotal = (Label)ddlDimension.FindControl("lblItemPriceTotal");
            //HiddenField hdProductItemId = (HiddenField)ddlDimension.NamingContainer.FindControl("hdProductItemId");

            //int ProductItemId = int.Parse(hdProductItemId.Value);
            //int quantity = int.Parse(ddlItemQuantity.SelectedValue.ToString());
            ////CartItem cartItem = ShoppingCart.Instance.GetCartItems().Where(x => x.ProductItemId == ProductItemId).FirstOrDefault();

            //if (divFilters.Style["display"] != null)
            //{
            //    if (divFilters.Style["display"].ToString() == "none")
            //    {
            //        lblItemPriceTotal.Text = (quantity * decimal.Parse(lblItemPrice.Text.Trim())).ToString();
            //        return;
            //    }
            //}
            //int productFilterId = int.Parse(ddlDimension.SelectedValue.ToString());
            //GetCustomerProductPrice_Result customerProductPrice = ProductManager.GetCustomerProudctItemPrice(SessionManager.CustomerId, productFilterId);
            //lblItemPrice.Text = customerProductPrice.SpecialPrice.ToString();

            //hdProductItemId.Value = customerProductPrice.ProductItemId.ToString();
            //lblItemPriceTotal.Text = (quantity * decimal.Parse(lblItemPrice.Text.Trim())).ToString();
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            int productItemId = 0, originalProductItemId = 0, quantity = 0;
            Decimal itemPrice = 0.0m;
            CartItem cartItem = null;

            List<CartItem> cartItems = ShoppingCart.Instance.GetCartItems();
            HiddenField hdProductItemId = null;
            HiddenField hdOriginalProductItemId = null;
            DropDownList ddlItemQuantity = null;
            Label lblItemPrice = null;
            DropDownList ddlProductType = null;
            DropDownList ddlDimension = null;

            foreach (DataListItem item in dlCartItems.Items)
            {
                hdProductItemId = (HiddenField)item.FindControl("hdProductItemId");
                hdOriginalProductItemId = (HiddenField)item.FindControl("hdOriginalProductItemId");
                ddlItemQuantity = (DropDownList)item.FindControl("ddlItemQuantity");
                lblItemPrice = (Label)item.FindControl("lblItemPrice");
                itemPrice = decimal.Parse(lblItemPrice.Text.Trim());
                ddlProductType = (DropDownList)item.FindControl("ddlProductType");
                ddlDimension = (DropDownList)item.FindControl("ddlDimension");

                productItemId = int.Parse(hdProductItemId.Value);
                originalProductItemId = int.Parse(hdOriginalProductItemId.Value);
                quantity = int.Parse(ddlItemQuantity.SelectedValue.ToString());

                cartItem = cartItems.Where(x => x.ProductItemId == originalProductItemId).FirstOrDefault();
                if (cartItem != null)
                {

                    cartItem.ProductItemId = productItemId;
                    cartItem.UnitPrice = itemPrice;
                    cartItem.Quantity = quantity;
                    if (ddlProductType.SelectedValue  != "" || ddlDimension.SelectedValue != "")
                    {
                        cartItem.ParentProductFilterId = int.Parse(ddlProductType.SelectedValue.ToString());
                        cartItem.ChildProductFilterId = int.Parse(ddlDimension.SelectedValue.ToString());
                    }
                }
            }

            ShoppingCart.Instance.UpdateCart(cartItems);
        }

        protected void ddlThickness_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}