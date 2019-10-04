using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation
{
    public partial class ManageProductItem : System.Web.UI.Page
    {
        private static List<ProductItemInfo> _piis;
        private static Enums.FormMode _currentFormMode = Enums.FormMode.Save;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUniqueSKU.Visible = false;
            if (!IsPostBack)
            {
                LoadProducts();
                LoadFilterTypes();
                LoadProductItemInfoGrid();                
            }            
        }

        private void LoadProductItemInfoGrid()
        {
            _piis = ProductManager.GetAllProductItemInfo();
            grdProductItem.DataSource = _piis;
            grdProductItem.DataBind();                          
        }

        private void LoadProducts()
        {
            List<Product> products  = ProductManager.GetProducts();
            ddlProduct.DataSource = products;
            ddlProduct.DataTextField = "ProductTitle";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataBind();

            ddlProduct.Items.Insert(0, new ListItem("-- Select Product --", "-1"));
            ddlProduct.SelectedIndex = 0;
        }
        private void LoadFilterTypes()
        {
            Action<List<FilterType>,DropDownList> BindFilterTypes = delegate(List<FilterType> filterTypes, DropDownList ddlProdFilter)
            {
                ddlProdFilter.DataSource = filterTypes;
                ddlProdFilter.DataTextField = "FilterTypeName";
                ddlProdFilter.DataValueField = "FilterTypeId";
                ddlProdFilter.DataBind();
                ddlProdFilter.Items.Insert(0, new ListItem(" -- Select Filter --", "-1"));
                ddlProdFilter.SelectedIndex = 0;
            };


            List<FilterType> filtertypes = ProductManager.GetFilterTypes();
            BindFilterTypes(filtertypes, ddlProductFilter);
            BindFilterTypes(filtertypes, ddlProductFilter2);
            ddlProductFilter.DataSource = filtertypes; 

        }
      
        private void LoadFilterValues(DropDownList ddlPF,DropDownList ddlPFV)
        {
            List<ListItem> lis = ddlPFV.Items.Cast<ListItem>().Where(i => Convert.ToInt16(i.Value) > 0).ToList<ListItem>();
            lis.ForEach(i => ddlPFV.Items.Remove(i));

            List<Filter> filters = ProductManager.GetFilters(Convert.ToInt32(ddlPF.SelectedValue));
            foreach (Filter f in filters)
            {
                ddlPFV.Items.Add(new ListItem(f.FilterValue, f.FilterId.ToString()));
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int prodfilterid = AddProductFilters();
            if (prodfilterid > 0)         
                UpdateProductItem(prodfilterid);
            Utility.RemoveFromCache("iteminfos");            
            lblMessage.Text = "Data Saved";
            ResetControls();           
        }

        private int AddProductFilters()
        {
            int retval = 0;     
            
//            •	Create a filter entry
//•	Create a product filter entry
            Func<int, string, Filter> CreateFilter = delegate(int filterTypeId, string filterValue)
            {
                Filter filter = null;
                filter = ProductManager.GetFilters(filterTypeId, filterValue).SingleOrDefault<Filter>();
                if (filter == null)
                {
                    filter = new Filter
                   {
                       FilterTypeId = filterTypeId,
                       FilterValue = filterValue
                   };
                    ProductManager.InsertORUpdateFilter(filter);
                }
                return filter;
            };

            Func<Filter, Filter, ProductFilter> CreateProductFilter = delegate(Filter primaryFilter, Filter secondaryFilter)
            {
                ProductFilter pfilter = null;
                pfilter = ProductManager.GetProductFilter(primaryFilter.FilterId.Value, secondaryFilter.FilterId.Value);
                if (pfilter == null)
                {
                    pfilter = new ProductFilter
                    {
                        PrimaryFilterId = primaryFilter.FilterId.Value,
                        SecondaryFilterId = secondaryFilter.FilterId.Value
                    };
                    ProductManager.InsertProductFilter(pfilter);
                }
                return pfilter;
            };

                        
            //Create Primary filter

            string selval = string.Empty;
 
            Filter primaryfilter = null;
            Filter secondaryfilter = null;
            ProductFilter productfilter = null;
            if (chkNoFilter.Checked)
            {
                primaryfilter = CreateFilter(1, ddlProduct.SelectedValue);
                secondaryfilter = CreateFilter(1, string.Empty);
                productfilter = CreateProductFilter(primaryfilter, secondaryfilter);                
            }
            else
            {
                if (!chkSecondFilter.Checked)
                {
                    // There is only primary filter, thus the secondaryfilter is default value
                    secondaryfilter = CreateFilter(1, string.Empty);
                    if ((Convert.ToInt32(ddlProductFilterVal.SelectedValue) <= 0) && (!string.IsNullOrEmpty(txtProductFilterVal.Text)))
                    {
                        // We are adding a new filter value through textbox and then add a productfilter
                        primaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter.SelectedValue), txtProductFilterVal.Text.Trim());
                        productfilter = CreateProductFilter(primaryfilter, secondaryfilter);
                    }
                    else
                    {
                        // Adding a filtervalue through dropdown
                        primaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter.SelectedValue), ddlProductFilterVal.SelectedItem.Text.Trim());
                        productfilter = CreateProductFilter(primaryfilter, secondaryfilter);
                    }

                }
                else
                {
                    //There is primary and secondary filter
                    //Create the primary filter
                    if ((Convert.ToInt32(ddlProductFilterVal.SelectedValue) <= 0) && (!string.IsNullOrEmpty(txtProductFilterVal.Text)))
                        primaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter.SelectedValue), txtProductFilterVal.Text.Trim());
                    else
                        primaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter.SelectedValue), ddlProductFilterVal.SelectedItem.Text.Trim());
                    //Create the secondary filter
                    if ((Convert.ToInt32(ddlProductFilter2Val.SelectedValue) <= 0) && (!string.IsNullOrEmpty(txtProductFilter2Val.Text)))
                        secondaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter2.SelectedValue), txtProductFilter2Val.Text.Trim());
                    else
                        secondaryfilter = CreateFilter(Convert.ToInt32(ddlProductFilter2.SelectedValue), ddlProductFilter2Val.SelectedItem.Text.Trim());

                    productfilter = CreateProductFilter(primaryfilter, secondaryfilter);
                }       
            }

            if (productfilter != null)
                retval = productfilter.ProductFilterId.Value;
            return retval;

        }

        private void UpdateProductItem(int prodFilterId)
        {
            ProductItem item = new ProductItem();
            item.ProductSKU = txtProductSKU.Text.Trim();
            item.ProductFilterId = prodFilterId;
            item.ProductId = Convert.ToInt32(ddlProduct.SelectedItem.Value);
            if (_currentFormMode == Enums.FormMode.Update)
            {
                if (!string.IsNullOrEmpty(hdnProductItemId.Value))
                    item.ProductItemId = Convert.ToInt32(hdnProductItemId.Value);
                ProductManager.UpdateProductItem(item); //updating by the productfilterid
            }
            else
                ProductManager.InsertProductItem(item);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void ResetControls()
        {         
            LoadFilterTypes();
            LoadProductItemInfoGrid();

            ddlProduct.SelectedIndex = 0;
            txtProductSKU.Text = string.Empty;
            chkNoFilter.Checked = false;
            chkSecondFilter.Checked = false;
            ddlProductFilter.SelectedIndex = 0;
            ddlProductFilter2.SelectedIndex = 0;
            ddlProductFilterVal.SelectedIndex = 0;
            ddlProductFilter2Val.SelectedIndex = 0;
            txtProductFilterVal.Text = string.Empty;
            txtProductFilter2Val.Text = string.Empty;
            //txtProductFilterVal.Style.Add("display", "none");
            //txtProductFilter2Val.Style.Add("display", "none");
            btnSave.Text = "Save";
            _currentFormMode = Enums.FormMode.Save;
        }

        protected void ddlProductFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* To figure this out later
            ListItem li = ddlProductFilter2.Items.FindByValue("1");
            ddlProductFilter2.Items.Remove(li);            
             li = ddlProductFilter2.Items.FindByValue(ddlProductFilter.SelectedValue);
            ddlProductFilter2.Items.Remove(li);
            */
    
            LoadFilterValues(sender as DropDownList,ddlProductFilterVal);
            lblMessage.Text = string.Empty;
        }

        protected void ddlProductFilter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFilterValues(sender as DropDownList, ddlProductFilter2Val);
        }

        protected void grdProductItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductItem.PageIndex = e.NewPageIndex;
            LoadProductItemInfoGrid();
        }

        protected void grdProductItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdedit")
            {
                ResetControls();
                if (_piis != null && _piis.Count > 0)
                {
                    int editeditemid = int.Parse(e.CommandArgument.ToString());
                    var pii = _piis.Where(p => p.ItemId == editeditemid).FirstOrDefault();
                    hdnProductItemId.Value = pii.ItemId.ToString();


                    txtProductSKU.Text = pii.ProductSKU;
                    ddlProduct.SelectedValue = pii.ProductId.ToString();
                    if (pii.PrimaryFilterId <= 1)
                        chkNoFilter.Checked = true;
                    else
                    {
                        ddlProductFilter.SelectedValue = pii.PrimaryFilterTypeId.ToString();
                        LoadFilterValues(ddlProductFilter, ddlProductFilterVal);
                        ddlProductFilterVal.SelectedIndex = ddlProductFilterVal.Items.IndexOf(ddlProductFilterVal.Items.FindByText(pii.PrimaryFilterValue));
                        if(pii.SecondaryFilterId > 1)
                        {
                            chkSecondFilter.Checked = true;
                            ddlProductFilter2.SelectedValue = pii.SecondaryFilterTypeId.ToString();
                            LoadFilterValues(ddlProductFilter2, ddlProductFilter2Val);
                            ddlProductFilter2Val.SelectedIndex = ddlProductFilter2Val.Items.IndexOf(ddlProductFilter2Val.Items.FindByText(pii.SecondaryFilterValue));
                        }
                    }
                    btnSave.Text = "Update";
                    btnDelete.Visible = true;
                    _currentFormMode = Enums.FormMode.Update;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnProductItemId.Value))
            {
                ProductManager.DeleteProductItem(Convert.ToInt32(hdnProductItemId.Value));
                Utility.RemoveFromCache("iteminfos");
                lblMessage.Text = "Data Saved";
                ResetControls();   
            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filteredGridValues = ProductManager.GetAllProductItemInfo();
            if (Convert.ToInt32(ddlProduct.SelectedItem.Value) > 0)
            {
                var tempProductValue = Convert.ToInt32(ddlProduct.SelectedItem.Value);
                filteredGridValues = filteredGridValues.Where(x => x.ProductId == tempProductValue).ToList();
                grdProductItem.DataSource = filteredGridValues;
                grdProductItem.DataBind();


                //ddlProduct.SelectedIndex = 0;
                txtProductSKU.Text = string.Empty;
                chkNoFilter.Checked = false;
                chkSecondFilter.Checked = false;
                ddlProductFilter.SelectedIndex = 0;
                ddlProductFilter2.SelectedIndex = 0;
                ddlProductFilterVal.SelectedIndex = 0;
                ddlProductFilter2Val.SelectedIndex = 0;
                txtProductFilterVal.Text = string.Empty;
                txtProductFilter2Val.Text = string.Empty;
                btnSave.Text = "Save";
            }
        }


    }
}