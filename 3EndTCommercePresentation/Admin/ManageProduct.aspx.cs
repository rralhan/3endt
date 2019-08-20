using _3EndTBusinessLayer;
using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using BO = _3EndTBusinessLayer.BusinessObject;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        private static string _imageUrl { get; set; }
        private static long _productId { get; set; }
        private static long _productItemId { get; set; }
        private static int _productFilterId { get; set; }
        static List<ProductItem> ProductItems = new List<ProductItem>();
        static List<ProductFilter> ProductFilters = new List<ProductFilter>();
        private static BO.Enums.FormMode _currentFormMode = BO.Enums.FormMode.Save;

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtProductAddedDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                LoadProducts();
                LoadCategories();
            }
        }
        protected void LoadProducts()
        {
            List<Product> products = ProductManager.GetAllProducts();
            grdProducts.DataSource = products;
            grdProducts.DataBind();
        }
        protected void LoadCategories()
        {
            List<Category> categories = CategoryManager.GetAllSubCategories();
            ddlCategoryName.Items.Clear();
            foreach (Category c in categories)
            {
                string datatext = c.CategoryName + " - L" + c.CategoryLevel;
                ddlCategoryName.Items.Add(new ListItem(datatext, c.CategoryId.ToString()));
            }

            //ddlCategoryName.DataSource = categories;
            //ddlCategoryName.DataTextField = "CategoryName";
            //ddlCategoryName.DataValueField = "CategoryId";
            //ddlCategoryName.DataBind();

            ddlCategoryName.Items.Insert(0,new ListItem("-- Select Category --","-1"));          
            ddlCategoryName.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();

            if (!this.Page.IsValid)
                return;

            Product product = new Product();
            product.CategoryId = Convert.ToInt32(ddlCategoryName.SelectedValue);
            product.ProductTitle = txtProductTitle.Text.Trim(); 
            product.Description = HttpUtility.HtmlEncode(txtDescription.Text.Trim());
            product.Unit = txtProductUnit.Text.Trim();
            product.IsActive = chkIsActive.Checked;
            if (fuProductImage.HasFile)
            {
                string filename = Path.GetFileName(fuProductImage.FileName);
                fuProductImage.SaveAs(Server.MapPath("/Images/") + filename);
                product.ImageUrl = "/Images/" + filename;
            }
            else
            {
                if (_imageUrl != string.Empty)
                {
                    product.ImageUrl = _imageUrl;
                    _imageUrl = string.Empty;
                }                
            }
            
            switch (_currentFormMode)
            {
                case BO.Enums.FormMode.Save:
                    if (ProductManager.CheckIfProductAlreadyExist(product))
                    {
                        lblMessage.Text = "Product you are trying to save already exist. Please enter other Product name.";
                        return;
                    }

                    if (ProductManager.InsertProduct(product))
                    {
                        lblMessage.Text = "Product successfully added.";

                        ResetControls();                       
                    }
                    else
                    {
                        lblMessage.Text = "Item has not be added.";
                    }
                    break;

                case BO.Enums.FormMode.Update:
                    product.ProductId = (int) _productId;
                    if (ProductManager.UpdateProduct(product))
                    {
                        _currentFormMode = BO.Enums.FormMode.Save;
                        ResetControls();
                        btnSave.Text = "Save";
                    }
                    break;
                default: break;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            btnSave.Text = "Save";
        }
        
        
        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdedit")
            {
                _productId = int.Parse(e.CommandArgument.ToString());
                Product product = ProductManager.GetProductById((int)_productId);
                ddlCategoryName.SelectedValue = product.CategoryId.ToString();
                txtProductTitle.Text = product.ProductTitle;
                txtDescription.Text = HttpUtility.HtmlDecode(product.Description);
                txtProductUnit.Text = product.Unit;
                chkIsActive.Checked = product.IsActive;
                _imageUrl = product.ImageUrl;
                btnSave.Text = "Update";
                btnDelete.Visible = true;
                _currentFormMode = BO.Enums.FormMode.Update;

            }
        }

        protected void ResetControls()
        {
            _currentFormMode = BO.Enums.FormMode.Save;
            this.txtProductTitle.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtProductUnit.Text = string.Empty;
           
            ddlCategoryName.SelectedValue = "-1";

            chkIsActive.Checked = true;
            LoadProducts();
        }
        protected void grdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProducts.PageIndex = e.NewPageIndex;
            ResetControls();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(_productId > 0 && btnDelete.Visible)
            {
                ProductManager.DeleteProduct(Convert.ToInt32(_productId));
                lblMessage.Text = "Product Deleted.";
                ResetControls();
            }
        }
        
    }


}