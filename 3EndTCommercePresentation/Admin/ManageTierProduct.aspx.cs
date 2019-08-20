using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;



namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageTierProduct : System.Web.UI.Page
    {
        #region Page custom Properties

        public static int TierId { get; set; }
        public static string TierName { get; set; }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTiers();
                LoadCategory();
                LoadSubCategory();
            }
            else
            {
                if (this.Request.Form["__EVENTTARGET"].Contains("_invoketier_event"))
                {
                    List<string> __targeteventarguments = this.Request.Form["__EVENTTARGET"].Split(':').ToList();
                    TierId = int.Parse(__targeteventarguments.Last());
                    TierName = __targeteventarguments.ElementAt(1).ToString();
                    lblCurrentTier.Text = TierName;
                    FlushPageContent();
                    LoadTierProducts();
                    
                }
                else if (this.Request.Form["__EVENTTARGET"].Contains("_savetierproduct"))
                {

                    List<string> __targeteventarguments = this.Request.Form["__EVENTTARGET"].Split('*').ToList();
                    string _tierProducts = __targeteventarguments.ElementAt(1).ToString();
                    if (_tierProducts.Count() > 0)
                    {
                        _tierProducts = _tierProducts.Remove(_tierProducts.LastIndexOf('$'));
                    }
                    SaveTierProducts(_tierProducts);
                }
            }
        }

        private void SaveTierProducts(string _tierProducts)
        {

            List<string> productIds = _tierProducts.Split('$').ToList();

            List<TierProduct> tierProducts = new List<TierProduct>();
            foreach (string productId in productIds)
            {
                tierProducts.Add(new TierProduct() { TierId = TierId, ProductItemId = Int32.Parse( productId == string.Empty ? "0" : productId) });                
            }
            if (ProductManager.SaveTierProduct(tierProducts))
            {
                lblSaveStatus.Text ="Data saved successfully.";
                LoadTierProducts();
            }


        }

        private void LoadTiers()
        {
            List<Tier> Tiers =   TierManager.GetAllTiers();
            if (Tiers != null)
            {
                this.dgvTiers.DataSource = Tiers;
                this.dgvTiers.DataBind();
            }
        }

        private void LoadCategory()
        {
            ddlCategory.Items.Clear();
            List<Category> categories = CategoryManager.GetAllCategoryNameByParentId();
            ddlCategory.DataSource = categories;
            categories.Insert(0, new Category { CategoryName = "-- Select Category --", CategoryId = -1 });
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();

        }

        private void LoadSubCategory()
        {
            ddlSubcategory.Items.Clear();

            int categoryId = 0;
            categoryId = int.Parse(ddlCategory.SelectedValue.ToString());
            List<Category> subCategories = CategoryManager.GetAllSubCategoryByParentCategoryId(categoryId);
            subCategories.Insert(0, new Category { CategoryName = "-- Select Sub Category --", CategoryId = -1 });
            ddlSubcategory.DataSource = subCategories;
            ddlSubcategory.DataTextField = "CategoryName";
            ddlSubcategory.DataValueField = "CategoryId";
            ddlSubcategory.DataBind();

        }

        protected void ddlCategory_SelectionChanged(object sender, EventArgs e)
        {
            LoadSubCategory();

        }

 

        private void LoadTierProducts()
        {
            #region Declarations
            int categoryId = int.Parse(ddlCategory.SelectedItem.Value);
            System.Nullable<int> subCategoryId = int.Parse(ddlSubcategory.SelectedItem.Value);
            if (subCategoryId.Equals(-1)) subCategoryId = null;
            ltSourceDiv.Text = string.Empty;
            ltDestination.Text = string.Empty;

            List<GetNonAssociatedProductWithTier_Result> notAssociatedProducts = ProductManager.GetNonAssociatedProductWithTier(TierId, categoryId, subCategoryId);
            List<GetAssociatedProductWithTier_Result> associatedProducts = ProductManager.GetAssociatedProductsWithTier(TierId);
            StringBuilder sbTargetDiv = new StringBuilder();
            StringBuilder sbSourceDiv = new StringBuilder();

            #endregion

            #region Display Non Associated Product
            if (notAssociatedProducts.Count > 0) sbSourceDiv.Append("<ul id=\"gallery\" class=\"gallery ui-helper-reset ui-helper-clearfix\">");
            foreach (GetNonAssociatedProductWithTier_Result product in notAssociatedProducts)
            {
                sbSourceDiv.Append("<li class=\"ui-widget-content ui-corner-tr\">");
                sbSourceDiv.AppendFormat("<h5 class=\"ui-widget-header\">{0}</h5>", product.ProductTitle);
                sbSourceDiv.AppendFormat("<input id=\"productId\" type=\"hidden\" value=\"{0}\"/>", product.ProductId);
                sbSourceDiv.Append("<img src=\"../UploadFile/ProductImage/img_logo.gif\" alt=\"The peaks of High Tatras\" width=\"100\">");
                sbSourceDiv.Append("<a href=\"images/high_tatras.jpg\" title=\"View larger image\" class=\"ui-icon ui-icon-zoomin\">View larger</a>");
                sbSourceDiv.Append("<a href=\"link/to/trash/script/when/we/have/js/off\" title=\"Delete this image\" class=\"ui-icon ui-icon-trash\">Delete image</a>");

            }
            if (notAssociatedProducts.Count > 0)
            {
                sbSourceDiv.Append("</ul>");
                ltSourceDiv.Text = sbSourceDiv.ToString();
            }
            #endregion

            #region Display Associted Product
            if (associatedProducts.Count > 0) sbTargetDiv.Append("<ul class=\"gallery ui-helper-reset\">");
            foreach (GetAssociatedProductWithTier_Result product in associatedProducts)
            {
                sbTargetDiv.Append("<li class=\"ui-widget-content ui-corner-tr ui-draggable\" style=\"display: list-item; width: 48px;\">");
                sbTargetDiv.AppendFormat("<h5 class=\"ui-widget-header\">{0}</h5>", product.ProductTitle);
                sbTargetDiv.AppendFormat("<input id=\"productId\" type=\"hidden\" value=\"{0}\"/>", product.ProductId);
                sbTargetDiv.Append("<img src=\"../UploadFile/ProductImage/img_logo.gif\" alt=\"The peaks of High Tatras\" width=\"100\" style=\"display: inline-block; height: 36px;\">");
                sbTargetDiv.Append("<a href=\"images/high_tatras.jpg\" title=\"View larger image\" class=\"ui-icon ui-icon-zoomin\">View larger</a>");
                sbTargetDiv.Append("<a href=\"link/to/recycle/script/when/we/have/js/off\" title=\"Recycle this image\" class=\"ui-icon ui-icon-refresh\">Recycle image</a>");
                sbTargetDiv.Append("</li>");
            }
            if (associatedProducts.Count > 0)
            {
                sbTargetDiv.Append("</ul>");
                ltDestination.Text = sbTargetDiv.ToString();
            }
            #endregion
        }

        protected void btnLoadProdcts_Click(object sender, EventArgs e)
        {
            FlushPageContent();
            if (TierId == 0)
            {
                this.lblMessage.Text = "Tier not selected. Please select tier among the list in right pane.";
                return;
            }
            LoadTierProducts();
        }

        protected void FlushPageContent()
        {
            this.ltDestination.Text = string.Empty;
            this.ltSourceDiv.Text = string.Empty;

        }
    }
}