using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _3EndTBusinessLayer;
using  _3EndTDataLayer;

namespace _3EndTCommercePresentation.Admin
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        private static int CategoryId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                delPanel.Visible = false;
                LoadCategory();
            }

        }

        protected void LoadCategory()
        {

            List<Category> dbCategory = CategoryManager.GetAllParentCategory();
            grdCategory.DataSource = dbCategory;
            grdCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();
            if (!this.Page.IsValid)
                return;

            string CategoryName = txtCategoryName.Text.Trim();
            bool IsActive = chkIsActive.Checked;
            //int ParentCategoryId = (int)ENUMS.Category.ParentId;
            Category dbCategory = new Category();
            if (btnSave.Text == "Save")
            {
                dbCategory.CategoryName = CategoryName;
                dbCategory.IsActive = IsActive;
                //dbCategory.ParentCategoryId = ParentCategoryId;

                if (CategoryManager.CheckIfCategoryAlreadyExist(dbCategory))
                {
                    lblMessage.Text = "Category Name Already Exists.";
                    return;
                }

                if (CategoryManager.InsertCategory(dbCategory))
                {
                    lblMessage.Text = "Data Saved";
                    LoadCategory();
                }
                else
                {
                    lblMessage.Text = "Data Save Failed";
                }
            }
            else
            {
                if (btnSave.Text == "Update")
                {
                    dbCategory.CategoryId = CategoryId;
                    dbCategory.CategoryName = txtCategoryName.Text.Trim();
                    dbCategory.IsActive = IsActive;


                    if (CategoryManager.UpdateCategory(dbCategory))
                    {
                        ResetControls();
                        LoadCategory();
                        btnSave.Text = "Save";
                    }
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            btnSave.Text = "Save";
            chkIsActive.Checked = true;

        }

        protected void ResetControls()
        {
            this.txtCategoryName.Text = string.Empty;

            chkIsActive.Checked = false;


        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            delPanel.Visible = false;

        }
        protected void btnYes_Click(object sender, EventArgs e)
        {

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
                CategoryId = int.Parse(e.CommandArgument.ToString());

                Category Cata = CategoryManager.GetCategoryById(CategoryId);
                txtCategoryName.Text = Cata.CategoryName;

                if (Cata.IsActive.ToString() != "")
                {
                    if (bool.Parse(Cata.IsActive.ToString()))
                    {
                        chkIsActive.Checked = true;
                    }
                    else
                    {
                        chkIsActive.Checked = false;
                    }
                }


                btnSave.Text = "Update";
            }
            if (e.CommandName == "cmddelete")
            {
                delPanel.Visible = true;
                CategoryId = int.Parse(e.CommandArgument.ToString());
            }
        }
    }
}