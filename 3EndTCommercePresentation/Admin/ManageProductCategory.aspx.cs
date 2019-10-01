using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3EndTBusinessLayer;
using _3EndTDataLayer;
using System.IO;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer.domain;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageProductCategory : System.Web.UI.Page
    {     
        private static string _imageUrl { get; set; }
        private static int _categoryId { get; set; }
        private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)            
                LoadCategory();  
        }
        protected void LoadCategory()
        {
            List<Category> categories = CategoryManager.GetAllCategories(false);

            ddlCategoryName.Items.Clear();
            foreach(Category c in categories)
            {
                string datatext = c.CategoryName + " - L" + c.CategoryLevel;
                ddlCategoryName.Items.Add(new ListItem(datatext, c.CategoryId.ToString()));
            }
            //ddlCategoryName.DataSource = allcat;
            //ddlCategoryName.DataTextField = "CategoryName";
            //ddlCategoryName.DataValueField = "CategoryId";
            //ddlCategoryName.DataBind();
            ListItem item = new ListItem();
            item.Text = "---Select Category---";
            item.Value = "-1";
            ddlCategoryName.Items.Insert(0, item);

            grdCategory.DataSource = categories;
            grdCategory.DataBind();
        }


        public string GetCategoryName(object parentcategoryid)
        {
            string retval = string.Empty;
            Category pcat = CategoryManager.GetCategoryById((int)parentcategoryid);
            if (pcat != null)            
                retval = pcat.CategoryName;            
            return retval;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();

            if (!this.Page.IsValid)
                return;

            string categoryname = txtCategoryName.Text.Trim();
            int parentcategoryid = int.Parse(ddlCategoryName.SelectedItem.Value);
            bool isactive = chkIsActive.Checked;
            bool isservice = chkIsService.Checked;
            Category dbCategory = new Category();
            if (_currentFormMode == Enums.FormMode.Save)
            {
                if (parentcategoryid == -1)
                {
                    //Main Category
                    dbCategory.ParentCategoryId = 0;
                    dbCategory.CategoryLevel = 1;
                }
                else
                {
                    dbCategory.ParentCategoryId = parentcategoryid;
                    Category parcat = CategoryManager.GetCategoryById(parentcategoryid);
                    dbCategory.CategoryLevel = Convert.ToInt16(parcat.CategoryLevel + 1);
                }
                dbCategory.CategoryName = categoryname;
                dbCategory.IsActive = isactive;
                dbCategory.IsService = isservice;
                if (fuCatImage.HasFile)
                {
                    string filename = Path.GetFileName(fuCatImage.FileName);
                    fuCatImage.SaveAs(Server.MapPath("/Images/") + filename);
                    dbCategory.ImageUrl = "/Images/" + filename;
                }
                if (CategoryManager.CheckIfCategoryAlreadyExist(dbCategory))
                {
                    lblConfirmation.Text = "Category Name Already Exists.";
                    return;
                }
                if (CategoryManager.InsertCategory(dbCategory))
                {
                    lblConfirmation.Text = "Item successfully added.";

                    ResetControls();
                    LoadCategory();
                }
                else
                {
                    lblConfirmation.Text = "Item can not be added.";
                }
            }
            else
            {
                dbCategory.CategoryId = _categoryId;
                if (parentcategoryid == -1)
                {
                    //Main Category
                    dbCategory.ParentCategoryId = 0;
                    dbCategory.CategoryLevel = 1;
                }
                else
                {
                    dbCategory.ParentCategoryId = parentcategoryid;
                    Category parcat = CategoryManager.GetCategoryById(parentcategoryid);
                    dbCategory.CategoryLevel = Convert.ToInt16(parcat.CategoryLevel + 1);
                }
                dbCategory.CategoryName = txtCategoryName.Text.Trim();
                dbCategory.IsActive = isactive;
                dbCategory.IsService = isservice;
                if (fuCatImage.HasFile)
                {
                    string filename = Path.GetFileName(fuCatImage.FileName);
                    fuCatImage.SaveAs(Server.MapPath("/Images/") + filename);
                    dbCategory.ImageUrl = "/Images/" + filename;
                }
                else
                {
                    if (_imageUrl != string.Empty)
                    {
                        dbCategory.ImageUrl = _imageUrl;
                        _imageUrl = string.Empty;
                    }
                }
                if (CategoryManager.UpdateCategory(dbCategory))
                {
                    ResetControls();
                    LoadCategory();
                    ddlCategoryName.Enabled = true;
                    btnSave.Text = "Save";
                    _currentFormMode = Enums.FormMode.Save;
                }
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            ddlCategoryName.Enabled = true;
            btnSave.Text = "Save";
            chkIsActive.Checked = true;
        }
        protected void ResetControls()
        {
            this.txtCategoryName.Text = string.Empty;
            this.ddlCategoryName.SelectedValue = "-1";
            rdbtnSubCatNo.Checked = true;
            rdbtnSubCatYes.Checked = false;
            chkIsActive.Checked = true;
        }
        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            LoadCategory();
        }
        protected void grdCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdedit")
            {
                _categoryId = int.Parse(e.CommandArgument.ToString());
                Category category = CategoryManager.GetCategoryById(_categoryId);
                txtCategoryName.Text = category.CategoryName;

                if (category.ParentCategoryId > 0)
                {
                    ddlCategoryName.SelectedValue = category.ParentCategoryId.ToString();
                    rdbtnSubCatYes.Checked = true;
                }
                else
                    rdbtnSubCatNo.Checked = true;

                chkIsActive.Checked = category.IsActive;
                chkIsService.Checked = category.IsService;

                _imageUrl = category.ImageUrl;
                _currentFormMode = Enums.FormMode.Update;
                btnSave.Text = "Update";
            }

        }

        protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


    }
}