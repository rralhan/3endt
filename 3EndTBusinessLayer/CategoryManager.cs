using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3EndTDataLayer;
namespace _3EndTBusinessLayer
{
   public  class CategoryManager
    {
       

       public static bool InsertCategory(Category Cata)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           try
           {
               ECE.AddToCategories(Cata);
               ECE.SaveChanges();
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }


       public static Boolean CheckIfCategoryAlreadyExist(Category cat)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           Category dbCategory = ECE.Categories.Where(x => x.CategoryName.ToLower() == cat.CategoryName.ToLower()).FirstOrDefault();
           if (dbCategory == null) return false;
           else return true;
       }

       public static List<Category> GetAllCategories(bool showOnlyActive = true)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           var retval = ECE.Categories.AsEnumerable();
           if (showOnlyActive)
               retval = retval.Where(x => x.IsActive == true).AsEnumerable();
           return retval.ToList();
       }


       public static List<Category> GetTopCategories(bool isService = false)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           return ECE.Categories.Where(x => (x.ParentCategoryId == 0 || x.ParentCategoryId == null) && x.IsActive == true 
               && x.IsService == isService).ToList();
       }

       public static List<Category> GetAllSubCategories()
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();

           //var query = (from a in ECE.Categories
           //              where !(from b in ECE.Categories
           //                     select b.ParentCategoryId)
           //                         .Contains(a.CategoryId)
           //              select a).OrderBy(x=>x.ParentCategoryId).ThenBy(y=>y.CategoryId);

           var query = ECE.Categories.Where(x => x.ParentCategoryId != null && x.ParentCategoryId > 0 && x.IsActive == true)
               .OrderBy(x => x.ParentCategoryId).ThenBy(y => y.CategoryId);
           return query.ToList();
       }
      

       public static Category GetCategoryById(int pCategoryId)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           Category cat = ECE.Categories.Where(x => x.CategoryId == pCategoryId).FirstOrDefault();
           return cat;
       }
       public static bool UpdateCategory(Category dbCategory)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           try
           {
               Category cata = ECE.Categories.Where(x => x.CategoryId == dbCategory.CategoryId).FirstOrDefault();
               cata.CategoryName = dbCategory.CategoryName;
               cata.ParentCategoryId = dbCategory.ParentCategoryId;
               cata.IsActive = dbCategory.IsActive;
               cata.CategoryLevel = dbCategory.CategoryLevel;
               cata.ImageUrl = dbCategory.ImageUrl;
               cata.IsService = dbCategory.IsService;
               ECE.SaveChanges();
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }

       public static List<Category> GetAllSubCategoryByParentCategoryId( int categoryId)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           List<Category> subCategories = ECE.Categories.Where(x => x.ParentCategoryId == categoryId && x.IsActive == true).ToList();
           return subCategories;
       }



       public static bool SaveBulkCategory(List<Category> newCategories)
       {
           EndtCommerceEntities ECE = new EndtCommerceEntities();
           foreach (Category c in newCategories)
           {
               Category dbCategory = ECE.Categories.Where(x => x.CategoryName == c.CategoryName).FirstOrDefault();
               if (dbCategory == null)
               {
                   ECE.Categories.AddObject(c);
               }
               else
               {
                   c.CategoryId = dbCategory.CategoryId;
               }
           }
           ECE.SaveChanges();
           return true;
       }
    }
}
