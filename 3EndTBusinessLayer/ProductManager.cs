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

        public static List<FilterType> GetAllFilterTypes(bool showActiveOnly = true)
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

        
        public static List<Tuple<TierProduct,TierProductPrice>> GetAssociatedProductPricesByTier(int tierId)
        {            
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var query = (from tp in ece.TierProducts
                             join tpp in ece.TierProductPrices on tp.TierProductId equals tpp.TierProductId
                             where tp.TierId == tierId
                             select new { tp, tpp }).AsEnumerable().Select(x => Tuple.Create(x.tp, x.tpp));
                List<Tuple<TierProduct, TierProductPrice>> tiertuple = query.ToList();

                return tiertuple; 
            }
        }
        
        public static void UpdateTierProductPrices(int tierId, int productItemId, decimal price)
        {
            EndtCommerceEntities ece = new EndtCommerceEntities();
            TierProduct tierprod = ece.TierProducts.Where(tp => tp.ProductItemId == productItemId && tp.TierId == tierId).SingleOrDefault();
            if(tierprod == null)
            {
                tierprod = new TierProduct();
                ece.TierProducts.AddObject(tierprod);
            }
            tierprod.TierId = tierId;
            tierprod.ProductItemId = productItemId;
            ece.SaveChanges();

            int tipid = tierprod.TierProductId;

            TierProductPrice tierprodprice = ece.TierProductPrices.Where(x => x.TierProductId == tipid).SingleOrDefault();
            if(tierprodprice == null)
            {
                tierprodprice = new TierProductPrice();
                ece.TierProductPrices.AddObject(tierprodprice);
            }
            tierprodprice.TierProductId = tipid;
            tierprodprice.Price = price;
            ece.SaveChanges();
        }

        public static List<Product> GetAllProductByCategoryId(int categoryId)
        {
            EndtCommerceEntities ece = new EndtCommerceEntities();
            var query = (from prd in ece.Products
                         where prd.CategoryId == categoryId && prd.IsActive == true
                         select prd).ToList();
            
            //ece.GetAllProductsByCategoryId(categoryId, customerId).ToList();
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
                using (EndtCommerceEntities ece = new EndtCommerceEntities())
                {
                    var query = from pi in ece.ProductItems
                                join p in ece.Products on pi.ProductId equals p.ProductId
                                join pf in ece.ProductFilters on pi.ProductFilterId equals pf.ProductFilterId

                                join f1 in ece.Filters on pf.PrimaryFilterId equals f1.FilterId into p1
                                from f1 in p1.DefaultIfEmpty() // left join
                                join ft1 in ece.FilterTypes on f1.FilterTypeId equals ft1.FilterTypeId

                                join f2 in ece.Filters on pf.SecondaryFilterId equals f2.FilterId into p2
                                from f2 in p2.DefaultIfEmpty()// left join
                                join ft2 in ece.FilterTypes on f2.FilterTypeId equals ft2.FilterTypeId

                                where p.IsActive == true //&& pi.ProductItemId > 1224
                                select new BO.ProductItemInfo
                                {
                                    ProductId = p.ProductId,
                                    ProductName = p.ProductTitle,
                                    ProductUnit = p.Unit,
                                    ItemId = pi.ProductItemId,
                                    ProductSKU = pi.ProductSKU,
                                    PrimaryFilterTypeId = f1.FilterTypeId,
                                    PrimaryFilterType = ft1.FilterTypeName,
                                    PrimaryFilterId = f1.FilterId,
                                    PrimaryFilterValue = f1.FilterValue,
                                    SecondaryFilterTypeId = f2.FilterTypeId,
                                    SecondaryFilterType = ft2.FilterTypeName,
                                    SecondaryFilterId = f2.FilterId,
                                    SecondaryFilterValue = f2.FilterValue
                                };
                    iteminfos = query.OrderBy(x => x.ItemId).ToList<BO.ProductItemInfo>();                

                    HttpContext.Current.Cache.Insert("iteminfos", iteminfos, null, DateTime.UtcNow.AddHours(CacheHours), System.Web.Caching.Cache.NoSlidingExpiration);                                        
                }
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
            var query = filters.AsEnumerable<Filter>().Where(p => p.FilterTypeId == filterTypeId && p.IsActive == true);            
            if (filterTypeId > 1 && filterValue.Trim() != string.Empty)       
                query = query.Where(p=> p.FilterValue == filterValue);

            return query.ToList<Filter>();
        }
        
        public static void InsertORUpdateFilter(Filter filter)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                if (filter.FilterId > 0)
                {
                    var stub = new Filter { FilterId = filter.FilterId };
                    ece.Filters.Attach(stub);
                    ece.Filters.ApplyCurrentValues(filter);
                }
                else
                {
                    ece.Filters.AddObject(filter);
                    ece.SaveChanges();
                }               
            }
        }

    }
}
