using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace _3EndTCommercePresentation.Client
{
    public partial class Products : System.Web.UI.Page
    {
        public static int _categoryId = 0;
        private int _tierId = 1;
        public string ImagePath
        {
            get
            {
                return Server.MapPath("/Images/");
            }
        }

        public int ItemCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.CompanyId > 0)
                _tierId = CompanyManager.GetCompanyByCompanyId(SessionManager.CompanyId).TierId;
            if (!IsPostBack)
            {
                if (Request.QueryString["_cid"] == null)
                    Response.Redirect("/Default.aspx");
                _categoryId = int.Parse(Request.QueryString["_cid"].ToString());
                Session["update"] = DateTime.UtcNow.ToBinary(); //Server.UrlDecode(System.DateTime.Now.ToString());
                LoadItems();
            }
        }

        private void LoadItems()
        {
            List<ProductPageBindableObject> productpageobjects = new List<ProductPageBindableObject>();
            List<Product> products = ProductManager.GetAllProductByCategoryId(_categoryId);
            if(products.Count > 0)            
                ShoppingCart1.HeaderLabel = products[0].Category.CategoryName;            
       
            List<Category> subcats = CategoryManager.GetAllSubCategoryByParentCategoryId(_categoryId);

            var query = (from p in products
                         select new ProductPageBindableObject { Id = p.ProductId, ImageUrl = p.ImageUrl, Title = p.ProductTitle, Type = BindableObjectType.Product, Description = p.Description })
                         .Concat(from c in subcats
                                 select new ProductPageBindableObject { Id = c.CategoryId, ImageUrl = c.ImageUrl, Title = c.CategoryName, Type = BindableObjectType.Category, Description = string.Empty });

            if (query.Count() > 0)
            {
                productpageobjects = query.OrderBy(q => q.Title).ToList<ProductPageBindableObject>();
                lvProducts.DataSource = productpageobjects;
                lvProducts.DataBind();
            }
            else
                Response.Redirect("/client/under-construction.aspx");           
        }
        
        public string GetProductDetails(object desc)
        {
            string description = (string)desc;
            description = HttpUtility.HtmlDecode(description);
            if (description.Count() > 100)
                return description.Substring(0, 96) + " ...";
            else
                return description;
        }
        public string GetProductLink(object type,object id)
        {
            string retval = "/client/product-details.aspx?_pid="+id.ToString();
            BindableObjectType bot = (BindableObjectType)Enum.Parse(typeof(BindableObjectType), type.ToString());
            if (bot == BindableObjectType.Category)
                retval = "/client/products.aspx?_cid=" + id.ToString();
            return retval;
        }
        protected void lvProducts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                #region Get Repeater controls
                HiddenField hdntype = e.Item.FindControl("hdnItemType") as HiddenField;
                BindableObjectType type = (BindableObjectType)Enum.Parse(typeof(BindableObjectType), hdntype.Value);

                HiddenField hdnproductid = e.Item.FindControl("hdnItemId") as HiddenField;
                int productid = Convert.ToInt32(hdnproductid.Value);

                var btncart = Utility.FindControlRecursive(e.Item as Control, "lnkCart") as LinkButton;
                var btnrfq = Utility.FindControlRecursive(e.Item as Control, "lnkRFQ") as HtmlAnchor;

                HtmlInputHidden hdnproductitems = Utility.FindControlRecursive(e.Item as Control, "hdnProductItems") as HtmlInputHidden;
                Label lblproductitemprice = Utility.FindControlRecursive(e.Item as Control, "lblProductItemPrice") as Label;
                Label lblproductunit = Utility.FindControlRecursive(e.Item as Control, "lblProductUnit") as Label;
                //var lblSKU = Utility.FindControlRecursive(e.Item as Control, "lblSKU") as HtmlGenericControl;

                DropDownList ddlprimaryfilter = Utility.FindControlRecursive(e.Item as Control, "ddlPrimaryFilter") as DropDownList;
                DropDownList ddlsecondaryfilter = Utility.FindControlRecursive(e.Item as Control, "ddlSecondaryFilter") as DropDownList;

                Label lblprimaryfiltertype = Utility.FindControlRecursive(e.Item as Control, "lblPrimaryFilterType") as Label;
                Label lblsecondaryfiltertype = Utility.FindControlRecursive(e.Item as Control, "lblSecondaryFilterType") as Label;

                HtmlGenericControl divFurtherCategory = Utility.FindControlRecursive(e.Item as Control, "divFurtherCategory") as HtmlGenericControl;
                HtmlGenericControl divAddToCart = Utility.FindControlRecursive(e.Item as Control, "divAddToCart") as HtmlGenericControl;
                
                HtmlImage imgproduct = Utility.FindControlRecursive(e.Item as Control, "imgProduct") as HtmlImage;
                ListViewDataItem item = e.Item as ListViewDataItem;
                var url = Convert.ToString(item.DataItem.GetPropertyValue("ImageUrl"));
                if (string.IsNullOrEmpty(url))
                    url = "/Images/NoImage.jpg";
                imgproduct.Src = url;

               
                #endregion

                if (type == BindableObjectType.Product)
                {
                    #region Product
                    List<ProductItemInfo> pilist = ProductManager.GetProductItemInfoByProductId(productid, _tierId);
                   
                    if (User.Identity.IsAuthenticated)
                    {
                        btnrfq.ToDisplayNone(); // This is default value;
                        btncart.ToDisplayBlock();
                        JavaScriptSerializer jss = new JavaScriptSerializer();               
                        if (pilist == null || pilist.Count <= 0)
                        {
                            e.Item.Visible = false;
                            ddlprimaryfilter.ToDisplayNone();
                            ddlsecondaryfilter.ToDisplayNone();
                            btncart.ToDisplayNone();
                        }
                        //if there is no particular product item only product
                        else if (pilist.Count == 1 && pilist[0].PrimaryFilterValue.Trim() == string.Empty)
                        {
                            ddlprimaryfilter.ToDisplayNone();
                            ddlsecondaryfilter.ToDisplayNone();
                            hdnproductitems.Value = jss.Serialize(pilist);
                            //lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                            lblproductunit.Text = "/ " + pilist[0].ProductUnit;
                            
                            //if (lblSKU != null)
                            //    lblSKU.InnerText = pilist[0].ProductSKU;

                            if (pilist[0].Price < 0)
                            {
                                btnrfq.ToDisplayBlock();
                                btnrfq.Attributes.Add("href", "~/client/contact-us.aspx?urlrefer=3&sku=" + pilist[0].ProductSKU);
                                btncart.ToDisplayNone();
                            }
                            else
                            {
                                lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                                btnrfq.ToDisplayNone();
                                btncart.ToDisplayBlock();
                            }
                            ItemCount++;
                        }
                        else
                        {
                            TextInfo myti = new CultureInfo("en-US", false).TextInfo;
                            ItemCount++;
                            hdnproductitems.Value = jss.Serialize(pilist);

                            if (!IsPostBack)
                                Utility.BindDropDowns(pilist, "PrimaryFilterValue", "PrimaryFilterId", ddlprimaryfilter);
                            lblprimaryfiltertype.Text = myti.ToTitleCase(pilist[0].PrimaryFilterType.Replace("Product", "")) + " : ";
                            ddlprimaryfilter.Attributes.Add("onchange", "jsProducts.displayPrice('" + hdnproductitems.ClientID + "');");// "','" + ddlprimaryfilter.ClientID + "', '" + ddlsecondaryfilter.ClientID + "','" + lblproductitemprice.ClientID + "');");

                            //if (lblSKU != null)
                            //    lblSKU.InnerText = pilist[0].ProductSKU;
                            lblproductunit.Text = "/ " + pilist[0].ProductUnit;
                            List<ProductItemInfo> testpii = pilist.Where(p => p.SecondaryFilterValue != string.Empty).ToList();
                            if (testpii.Count > 0)
                            {
                                // Do secondary filter stuff here.
                                lblsecondaryfiltertype.Text = myti.ToTitleCase(pilist[0].SecondaryFilterType.Replace("Product", "")) + " : ";
                                testpii = testpii.Where(p => p.PrimaryFilterId == Convert.ToInt32(ddlprimaryfilter.SelectedValue)).ToList(); ;
                                if (!IsPostBack)
                                {
                                    Utility.BindDropDowns(testpii, "SecondaryFilterValue", "SecondaryFilterId", ddlsecondaryfilter);
                                    ddlprimaryfilter.Attributes.Add("onchange", "jsProducts.displaySecondDropdown('" + hdnproductitems.ClientID + "');jsProducts.displayPrice('" + hdnproductitems.ClientID + "');");
                                    ddlsecondaryfilter.Attributes.Add("onchange", "jsProducts.displayPrice('" + hdnproductitems.ClientID + "');");
                                }
                            }
                            else
                                ddlsecondaryfilter.ToDisplayNone();

                            //Display settings for first time                    
                            if (pilist[0].Price < 0)
                            {
                                btnrfq.ToDisplayBlock();
                                btnrfq.Attributes.Add("href", "~/client/contact-us.aspx?urlrefer=3&sku=" + pilist[0].ProductSKU);
                                btncart.ToDisplayNone();
                            }
                            else
                            {
                                int primaryFilterValue = 0;
                                if (int.TryParse(ddlprimaryfilter.SelectedItem.Value, out primaryFilterValue) && primaryFilterValue <= 0)
                                {
                                    lblproductitemprice.ToDisplayNone();
                                    lblproductunit.ToDisplayNone();
                                }
                                else
                                    lblproductitemprice.Text = string.Format("$ {0:#,###0.00}", pilist[0].Price);
                                btnrfq.ToDisplayNone();
                                btncart.ToDisplayBlock();
                            }
                        }
                       
                    }
                    divFurtherCategory.ToDisplayNone();
                    #endregion
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        btncart.ToDisplayNone();
                        ddlprimaryfilter.ToDisplayNone();
                        ddlsecondaryfilter.ToDisplayNone();
                        divAddToCart.ToDisplayNone();
                    }
                    divFurtherCategory.ToDisplayBlock();                 
                    
                    ItemCount++;
                }
            }
        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var viewStateUpdateTime  = DateTime.MinValue;
            var sessionUpdateTime = DateTime.MinValue;
            if(ViewState["update"] != null)
                viewStateUpdateTime = DateTime.FromBinary(Convert.ToInt64(ViewState["update"]));
            if(Session["update"] != null)
                sessionUpdateTime = DateTime.FromBinary(Convert.ToInt64(Session["update"]));

            if (e.CommandName.ToLower() == "addtocart" && viewStateUpdateTime == sessionUpdateTime)
            {        
                HiddenField hdnproductid = e.Item.FindControl("hdnItemId") as HiddenField;
                int productid = Convert.ToInt32(hdnproductid.Value);
                DropDownList ddlprimaryfilter = Utility.FindControlRecursive(e.Item as Control, "ddlPrimaryFilter") as DropDownList;
                DropDownList ddlsecondaryfilter = Utility.FindControlRecursive(e.Item as Control, "ddlSecondaryFilter") as DropDownList;

                var hdnsecondaryproductitemchoice = Utility.FindControlRecursive(e.Item as Control, "hdnSecondaryProductItemChoice") as HiddenField;

                List<ProductItemInfo> pilist = ProductManager.GetProductItemInfoByProductId(productid, _tierId);
                if (ddlprimaryfilter.Items.Count > 0 && ddlprimaryfilter.SelectedValue != string.Empty)
                {
                    var query = pilist.Where(p => p.PrimaryFilterId == Convert.ToInt32(ddlprimaryfilter.SelectedValue));
                    if (ddlsecondaryfilter != null && ddlsecondaryfilter.SelectedValue != string.Empty)
                    {
                        var secondaryselection = hdnsecondaryproductitemchoice.Value;
                        query = query.Where(p => p.SecondaryFilterId == Convert.ToInt32(secondaryselection));
                    }
                    ShoppingCart1.AddToCart(query.FirstOrDefault());
                }
                else
                    ShoppingCart1.AddToCart(pilist.FirstOrDefault());
                ItemCount++;
                Session["update"] = DateTime.UtcNow.ToBinary();    //Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }

        [WebMethod]
        public static void UpdateShoppingCart(string strTempCarts)
        {
            //Repeated work. To remove later.
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<UserCart> tempcarts = jss.Deserialize<List<UserCart>>(strTempCarts);
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

        protected void lvProducts_PreRender(object sender, EventArgs e)
        {
            //if (ItemCount <= 0 && User.Identity.IsAuthenticated)
            //    Response.Redirect("/client/under-construction.aspx");

            ViewState["update"] = Session["update"];
        }
    }

    #region secondary classes

    [Serializable()]
    class UserCart : ProductItemInfo
    {
        public int Quantity { get; set; }
    }

    [Serializable()]
    class ProductPageBindableObject
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public BindableObjectType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    [Serializable()]
    enum BindableObjectType
    {
        Product,
        Category
    }
    #endregion
}