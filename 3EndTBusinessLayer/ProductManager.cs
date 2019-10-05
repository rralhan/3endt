using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System.Data.Linq;
using System.Reflection;
using System.Data.Objects.DataClasses;
using System.Web;
using System.Configuration;
using _3EndTDataLayer.domain;

namespace _3EndTBusinessLayer
{
    public class ProductManager
    {
        public static int CacheHours
        {
            get
            {
                if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CacheHours"]))
                    return Convert.ToInt32(ConfigurationManager.AppSettings["CacheHours"]);
                return 1;
            }
        }

        public static List<Product> GetProducts(bool showOnlyActive = true)
        {
            var prds = SQLHelper.GetProducts();
            if (showOnlyActive)
                prds = prds.Where(x => x.IsActive == true).OrderBy(x => x.ProductTitle).ToList();
            return prds;
        }
    
        public static bool InsertProduct(Product prd)
        {
            var retval = SQLHelper.InsertProduct(prd);
            if (retval > 0)
                return true;
            return false;
        }

        public static Boolean CheckIfProductAlreadyExist(Product product)
        {
            var prds = GetProducts();
            Product dbProduct = prds.Where(x => x.ProductTitle.ToLower() == product.ProductTitle.ToLower()).FirstOrDefault();
            if (dbProduct == null) 
                return false;
            else 
                return true;
        }

        //public static List<Category> GetAllSubCategory(int CategoryId)
        //{
        //    EndtCommerceEntities ece = new EndtCommerceEntities();
        //    List<Category> subcats = ece.Categories.Where(x => x.ParentCategoryId == CategoryId).ToList();
        //    return subcats;
        //}

        public static Product GetProductById(int productId)
        {
            return SQLHelper.GetProductById(productId);
        }

        public static void UpdateProductItem(ProductItem productItem)
        {
            var pis = SQLHelper.GetProductItems();
            var pi = pis.Where(x => x.ProductItemId == productItem.ProductItemId && x.IsActive == true).FirstOrDefault<ProductItem>();
            pi.ProductSKU = productItem.ProductSKU;
            pi.ProductFilterId = productItem.ProductFilterId;
            SQLHelper.UpdateProductItem(pi);
        }

        public static void DeleteProduct(int productId)
        {
            var productItems = SQLHelper.GetProductItems();
            var productitems = productItems.Where(pi => pi.ProductId == productId && pi.IsActive == true)
            .Select(x => x.ProductItemId);
            foreach (int pitemid in productitems)
            {
                DeleteProductItem(pitemid);
            }
            var products = SQLHelper.GetProducts();
            var product = products.FirstOrDefault<Product>(x => x.ProductId == productId && x.IsActive == true);
            if (product != null)
                SQLHelper.DeleteProduct(productId);
        }

        public static void DeleteProductItem(int productItemId)
        {
            var productItems = SQLHelper.GetProductItems();
            var tps = SQLHelper.GetTierProducts();
            var tpps = SQLHelper.GetTierProductPrices();
            var prices = (from tpp in tpps
                          join tp in tps on tpp.TierProductId equals tp.TierProductId
                          where tp.ProductItemId == productItemId && tpp.IsActive == true
                          select tpp);
            if (prices != null && prices.Count() > 0)
            {
                foreach (TierProductPrice price in prices)
                {
                    SQLHelper.DeleteTierProductPrice(price.TierProductPriceId);
                }
            }

            var tierproducts = tps.Where<TierProduct>(x => x.ProductItemId == productItemId);
            if (tierproducts != null && prices.Count() > 0)
            {
                foreach (TierProduct tierproduct in tierproducts)
                {
                    SQLHelper.DeleteTierProduct(tierproduct.TierProductId.Value);
                }
            }

            var pi = productItems.Where(x => x.ProductItemId == productItemId && x.IsActive == true).FirstOrDefault<ProductItem>();
            if (pi != null && pi.ProductItemId.HasValue)
                SQLHelper.DeleteProductItem(pi.ProductItemId.Value);

        }
        
        public static bool UpdateProduct(Product prd)
        {
            var retval = SQLHelper.UpdateProduct(prd);
            if (retval > 0)
                return true;
            return false;
        }

        public static void InsertProductFilter(ProductFilter productFilter)
        {
            if (!CheckIfProductFilterExists(productFilter))
            {
                SQLHelper.InsertProductFilter(productFilter);
            }
        }

        public static ProductFilter GetProductFilter(int primaryFilterId,int secondaryFilterId)
        {
            ProductFilter pfilter = null;
            var prdFilters = SQLHelper.GetProductFilters();
            var query = prdFilters.Where(p => p.PrimaryFilterId == primaryFilterId && p.SecondaryFilterId == secondaryFilterId);
            if (query.Count() > 0)
                pfilter = query.FirstOrDefault<ProductFilter>();
            return pfilter;
        }


        public static bool CheckIfProductFilterExists(ProductFilter productfilter)
        {
            bool retval = false;
            var prdFilters = SQLHelper.GetProductFilters();
            var query = prdFilters.Where(p => p.PrimaryFilterId == productfilter.PrimaryFilterId &&
            p.SecondaryFilterId == productfilter.SecondaryFilterId && p.IsActive == true);
            if (query.Count() > 0)
            {
                productfilter = query.FirstOrDefault<ProductFilter>();
                retval = true;
            }
            return retval;
        }


        /// <summary>
        /// Get ProductFilter by ProductFilterid
        /// </summary>
        /// <param name="pfId"></param>
        /// <returns></returns>
        //public static ProductFilter GetProductFilterById(int pfId)
        //{
        //    EndtCommerceEntities ece = new EndtCommerceEntities();
        //    ProductFilter pf = ece.ProductFilters.Where(x => x.ProductFilterId == pfId).SingleOrDefault();
        //    return pf;           
        //}

        public static List<FilterType> GetFilterTypes(bool showActiveOnly = true)
        {
            var retval = SQLHelper.GetFilterTypes();
            if (showActiveOnly)
                retval = retval.Where(x => x.IsActive == true).ToList();

            return retval;
        }
        /// <summary>
        /// Get ProductFilter by ParentProductFilterId
        /// </summary>
        /// <param name="parentProductFilterId"></param>
        /// <returns></returns>
        //public static ProductFilter GetProductFilterByParentId(System.Nullable<int> parentProductFilterId)
        //{            
        //    using (EndtCommerceEntities ece = new EndtCommerceEntities())
        //    {
        //        ProductFilter filter = ece.ProductFilters.Where(x => x.ProductFilterId == parentProductFilterId).FirstOrDefault();
        //        return filter; 
        //    }
        //}


        public static List<Tuple<TierProduct, TierProductPrice>> GetAssociatedProductPricesByTier(int tierId)
        {
            var tps = SQLHelper.GetTierProducts();
            var tpps = SQLHelper.GetTierProductPrices();

            var query = (from tp in tps
                         join tpp in tpps on tp.TierProductId equals tpp.TierProductId
                         where tp.TierId == tierId
                         select new { tp, tpp }).AsEnumerable().Select(x => Tuple.Create(x.tp, x.tpp));
            List<Tuple<TierProduct, TierProductPrice>> tiertuple = query.ToList();

            return tiertuple;
        }
        
        public static void UpdateTierProductPrices(int tierId, int prdItemId, decimal price)
        {
            var tps = SQLHelper.GetTierProducts();
            TierProduct tierprod = tps.Where(tp => tp.ProductItemId == prdItemId && tp.TierId == tierId).SingleOrDefault();
            if (tierprod == null)
            {
                tierprod = new TierProduct();
                tierprod.TierId = tierId;
                tierprod.ProductItemId = prdItemId;
                SQLHelper.InsertTierProducts(tierprod);
            }
            else
            {
                tierprod.TierId = tierId;
                tierprod.ProductItemId = prdItemId;
                tierprod.ModifiedDate = DateTime.UtcNow;
                SQLHelper.UpdateTierProducts(tierprod);
            }

            tps = SQLHelper.GetTierProducts();
            tierprod = tps.FirstOrDefault<TierProduct>(x => x.TierId == tierId && x.ProductItemId == prdItemId);
            if(tierprod != null)
            {
                int tipid = tierprod.TierProductId.HasValue ? tierprod.TierProductId.Value : 0;
                var tpps = SQLHelper.GetTierProductPrices();

                var tierprdprice = tpps.Where(x => x.TierProductId == tipid).FirstOrDefault();
                if (tierprdprice == null)
                {
                    tierprdprice = new TierProductPrice();
                    tierprdprice.TierProductId = tipid;
                    tierprdprice.Price = price;
                    SQLHelper.InsertTierProductPrices(tierprdprice);
                }
                else
                {
                    tierprdprice.TierProductId = tipid;
                    tierprdprice.Price = price;
                    tierprdprice.ModifiedDate = DateTime.UtcNow;
                    SQLHelper.UpdateTierProductPrices(tierprdprice);
                }

            }          
        }

        public static List<Product> GetAllProductsByCategoryId(int categoryId)
        {
            var prds = SQLHelper.GetProducts();
            var query = (from prd in prds
                         where prd.CategoryId == categoryId && prd.IsActive == true
                         select prd).ToList();
            return query;
        }

        //public static List<ProductItem> GetProductItemsByProductId(long productId)
        //{
        //    EndtCommerceEntities ece = new EndtCommerceEntities();
        //    List<ProductItem> productItems = ece.ProductItems.Where(x => x.ProductId == productId).ToList();
        //    return productItems;
        //}

        //public static ProductItem GetProductItemByProductItemId(int productItemId)
        //{
        //    EndtCommerceEntities ece = new EndtCommerceEntities();
        //    ProductItem productItem = ece.ProductItems.Where(x => x.ProductItemId == productItemId).FirstOrDefault();
        //    return productItem;
        //}

        //public static List<ProductItem> GetAllProductItems()
        //{
        //    EndtCommerceEntities ece = new EndtCommerceEntities();
        //    return ece.ProductItems.ToList();
        //}

        public static List<BO.ProductItemInfo> GetProductItemInfoByProductId(int productId, int tierId = 1)
        {
            var query = from pii in GetAllProductItemInfo()
                        join ppt in GetAssociatedProductPricesByTier(tierId) on pii.ItemId equals ppt.Item1.ProductItemId
                        where pii.ProductId == productId
                        select new BO.ProductItemInfo
                           {
                               ProductId = pii.ProductId,
                               ProductName = pii.ProductName,                               
                               ItemId = pii.ItemId,
                               ProductSKU = pii.ProductSKU,
                               PrimaryFilterTypeId = pii.PrimaryFilterTypeId,
                               PrimaryFilterType = pii.PrimaryFilterType,
                               PrimaryFilterId = pii.PrimaryFilterId,
                               PrimaryFilterValue = pii.PrimaryFilterValue,
                               SecondaryFilterTypeId = pii.SecondaryFilterTypeId,
                               SecondaryFilterType = pii.SecondaryFilterType,
                               SecondaryFilterId = pii.SecondaryFilterId,
                               SecondaryFilterValue = pii.SecondaryFilterValue,
                               Price = ppt.Item2.Price,
                               ProductUnit = pii.ProductUnit, 
                               TierId = ppt.Item1.TierId
                           };
            return query.ToList<BO.ProductItemInfo>();

        }

        public static List<BO.ProductItemInfo> GetAllProductItemInfo()
        {
            List<BO.ProductItemInfo> iteminfos = new List<BO.ProductItemInfo>();
            if (HttpContext.Current.Cache["iteminfos"] == null)
            {
                var filters = SQLHelper.GetFilters();
                var filterTypes = SQLHelper.GetFilterTypes();
                var products = SQLHelper.GetProducts();
                var productItems = SQLHelper.GetProductItems();
                var productFilters = SQLHelper.GetProductFilters();

                    var query = from pi in productItems
                                join p in products on pi.ProductId equals p.ProductId
                                join pf in productFilters on pi.ProductFilterId equals pf.ProductFilterId

                                join f1 in filters on pf.PrimaryFilterId equals f1.FilterId into p1
                                from f1 in p1.DefaultIfEmpty() // left join
                                join ft1 in filterTypes on f1.FilterTypeId equals ft1.FilterTypeId

                                join f2 in filters on pf.SecondaryFilterId equals f2.FilterId into p2
                                from f2 in p2.DefaultIfEmpty()// left join
                                join ft2 in filterTypes on f2.FilterTypeId equals ft2.FilterTypeId

                                where p.IsActive == true && pf.IsActive == true
                                select new BO.ProductItemInfo
                                {
                                    ProductId = p.ProductId.Value,
                                    ProductName = p.ProductTitle,
                                    ProductUnit = p.Unit,
                                    ItemId = pi.ProductItemId.Value,
                                    ProductSKU = pi.ProductSKU,
                                    PrimaryFilterTypeId = f1.FilterTypeId,
                                    PrimaryFilterType = ft1.FilterTypeName,
                                    PrimaryFilterId = f1.FilterId.Value,
                                    PrimaryFilterValue = f1.FilterValue,
                                    SecondaryFilterTypeId = f2.FilterTypeId,
                                    SecondaryFilterType = ft2.FilterTypeName,
                                    SecondaryFilterId = f2.FilterId.Value,
                                    SecondaryFilterValue = f2.FilterValue
                                };
                    iteminfos = query.OrderBy(x => x.ItemId).ToList<BO.ProductItemInfo>();                

                    HttpContext.Current.Cache.Insert("iteminfos", iteminfos, null, DateTime.UtcNow.AddHours(CacheHours), System.Web.Caching.Cache.NoSlidingExpiration);                                        
                
            }
            else            
                iteminfos = (List<BO.ProductItemInfo>)HttpContext.Current.Cache["iteminfos"];
            return iteminfos;
        }
        
        

        public static bool InsertProductItem(ProductItem item)
        {
            var retval = SQLHelper.InsertProductItem(item);
            if (retval > 0)
                return true;
            return false;
        }

        public static List<Filter> GetFilters(int filterTypeId = 0, string filterValue = "")
        {
            var filters = SQLHelper.GetFilters();
            if (filterTypeId > 1 && filterValue.Trim() != string.Empty)
            {
                var query = filters.AsEnumerable<Filter>().Where(p => p.FilterTypeId == filterTypeId && p.FilterValue == filterValue && p.IsActive == true);
                return query.ToList<Filter>();
            }
            return filters;         
        }

        public static void InsertORUpdateFilter(Filter filter)
        {
            if (filter.FilterId > 0)
            {
                SQLHelper.UpdateFilter(filter);
            }
            else
            {
                SQLHelper.InsertFilter(filter);
            }
        }

    }
}
