using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _3EndTBusinessLayer;
using _3EndTDataLayer;
using _3EndTBusinessLayer.BusinessObject;
using System.Text;
using _3EndTDataLayer.domain;

namespace _3EndTCommercePresentation.MasterPages
{
    public partial class Client : System.Web.UI.MasterPage
    {
        
        public static Client Instance { get { return new Client(); } }
        public static int CategoryId { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderAllCategories();
                if(Session["Navigation"] != null && !string.IsNullOrEmpty(Session["Navigation"].ToString()))
                {
                    hdnNav.Value = Session["Navigation"].ToString();
                }
            }

        }

        protected void OnLoggedOut_Click(object sender, EventArgs e)
        {
            this.Session.Abandon();
            HttpContext.Current.Response.Redirect("/default.aspx");
        }
        private void LoadInnerSubCatagories()
        {
           
        }

        private void RenderAllCategories()
        {
            List<Category> allcategories = CategoryManager.GetAllCategories(); 
            List<Category> parentcategories = CategoryManager.GetTopCategories();
            ltProductItems.Text = RenderCategories(allcategories, parentcategories);

            parentcategories = CategoryManager.GetTopCategories(true);
            ltServiceItems.Text = RenderCategories(allcategories, parentcategories);
        }

        private string RenderCategories(List<Category> allCategories,List<Category> parentCategories)
        {
            string retval = string.Empty;
            List<Category> subcategories = null;
            StringBuilder menu = new StringBuilder();

            menu.Append(@"<ul class='nav navbar-nav'>");
            foreach (Category category in parentCategories)
            {
                subcategories = allCategories.Where(x => x.ParentCategoryId == category.CategoryId).ToList();
                if (subcategories.Count() > 0)
                {
                    menu.AppendFormat(@"<li class='panel panel-default panel-expando' id='dropdown'><a href='#dropdown-lvl2_{0}' data-toggle='collapse' aria-expanded='false' aria-controls='collapseExample'> <span class='glyphicon glyphicon-off'></span>{1}<span class='caret'></span></a>", category.CategoryId, category.CategoryName);
                    menu.AppendFormat("<div id='dropdown-lvl2_{0}' class='panel-collapse collapse'><div class='panel-body'><ul class='nav navbar-nav'>", category.CategoryId);
                    foreach (Category innerCategory in subcategories)
                    {
                        menu.AppendFormat("<li id='liTProduct_{0}'><a href='/client/products.aspx?_cid={0}' onclick='addToCookieNav();'>{1}</a></li>", innerCategory.CategoryId, innerCategory.CategoryName);
                    }
                    menu.Append("</ul></div></div>");
                }
                else
                    menu.AppendFormat("<li class='panel panel-default' id='dropdown'><a href='/client/under-construction.aspx' ><span class='glyphicon glyphicon-off'></span>{1}</a>", category.CategoryId, category.CategoryName);

                menu.AppendFormat("</li>");
            }
            menu.Append("</ul>");
            retval = menu.ToString();
            return retval;
        }

        /*
        public void RenderShoppingCartDetails()
        {
            List<CartItem> cartItems = ShoppingCart.Instance.CartItems;
            if (cartItems == null)
                return;
            lblItemQuantity.Text = cartItems.Sum(x => x.Quantity).ToString();
            this.lblTotalPrice.Text = cartItems.Sum(x => x.TotalPrice).ToString();
        }
        */

        //protected void PopulateNode(object sender, TreeNodeEventArgs e)
        //{
        //    List<Category> allcats = CategoryManager.GetTopCategories();
        //    foreach(var c in allcats)
        //    {
        //        TreeNode newnode = new TreeNode(c.CategoryName,c.CategoryId.ToString());
        //        newnode.SelectAction = TreeNodeSelectAction.Expand;
        //        newnode.PopulateOnDemand=true;
        //        e.Node.ChildNodes.Add(newnode);
        //    }

        //}

        
    }
}