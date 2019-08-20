using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using _3EndTDataLayer;

namespace _3EndTBusinessLayer.BusinessObject
{
    public class Product
    {
        public decimal Price { get; set; }
        public int CategoryId {get;set;}
        public string Description {get;set;}
        public string ImageUrl {get;set;}
        public Boolean IsActive {get;set;}
        public long ProductId {get;set;}           
        public string ProductTitle{get;set;}

        public string Unit{get;set;}
        public long ProductItemId{get;set;}   
        public string ProductSKU{get;set;}
        //public Dictionary<int, string> ProductTypes = new Dictionary<int, string>();
        //public Dictionary<int, string> Dimensions = new Dictionary<int, string>();

        public int parentProductFilterId { get; set; }
        public int childProductFilterId { get; set; }

        public List<ProductFilter> ProductFilters = new List<ProductFilter>();
        public List<ProductItem> ProductItems = new List<ProductItem>();

        public Product(int productItemId)
        {

            _3EndTDataLayer.ProductItem productItem = ProductManager.GetProductItemByProductItemId(productItemId);
            long CustomerId = SessionManager.CustomerId;

            this.ProductId = productItem.ProductId;
            this.CategoryId = productItem.Product.CategoryId;
            this.Description = productItem.Product.Description;
            this.ImageUrl = productItem.Product.ImageUrl;
            this.IsActive = productItem.Product.IsActive;
            this.ProductId = productItem.Product.ProductId;
            this.ProductTitle = productItem.Product.ProductTitle;
            this.Unit = productItem.Product.Unit;
            List<ProductItem> ProductItems = ProductManager.GetProductItemsByProductId(productItem.Product.ProductId);
            ProductFilter productFilter = null;
            if( ProductItems != null)
            {
                //each of the product item contains filters
                //if product items filter exisit then you must provide an option to 
                //select different filters such as Material and Dimension in a dropdownlistbox in the user interface part(carts.aspx)
                //All the available filters are fetched just beacuse later in the interface you do not have to fetch from database.
                foreach (ProductItem item in ProductItems)
                {
                    if (item.ProductFilter != null)
                    {
                        productFilter = new _3EndTDataLayer.ProductFilter();
                        //productFilter = item.ProductFilter; *****
                        ProductFilters.Add(productFilter);
                    }
                    #region Add Parent Filter to Product Filter
                    //Product Filter contains only child product filter but does not contain parent filter
                    //but carts.aspx user has to first select parent filter and the child filter 
                    //parent filter is treated as product type(Material) and child fiter is treaed as Dimension
                    //but in case of prodcutItem which do not have filter it will not contains such parent and child filters there will only on productItem.
                    //Section code below only add the parent filter if it is unique. i.e. no duplicate parent filter is added.

                    ProductFilter parentProductFilter = new ProductFilter();
                    System.Nullable<int> parentProductFilterId = null;
                    if (item.ProductFilter != null)
                        //parentProductFilterId = item.ProductFilter.ParentProductFilterId; *****
                    parentProductFilter = ProductManager.GetProductFilterByParentId(parentProductFilterId);
                    if (parentProductFilter != null)
                    {
                        ProductFilter tempFilter = ProductFilters.Where(x => x.ProductFilterId == parentProductFilter.ProductFilterId).FirstOrDefault();
                        if (tempFilter == null)
                            ProductFilters.Add(parentProductFilter);
                    }
                    #endregion
                }
            }

            
        }
    }
}
