using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;

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
            var cats = SQLHelper.GetCategories();
            if (showOnlyActive)
                cats = cats.Where(x => x.IsActive == true).ToList();
            return cats;
        }


       public static List<Category> GetTopCategories(bool isService = false)
       {
            var cats = SQLHelper.GetCategories();
            return cats.Where(x => (x.ParentCategoryId == 0 || x.ParentCategoryId == null) && x.IsActive == true 
               && x.IsService == isService).ToList();
       }

       public static List<Category> GetAllSubCategories()
       {
            var cats = SQLHelper.GetCategories();

            var query = cats.Where(x => x.ParentCategoryId != null && x.ParentCategoryId > 0 && x.IsActive == true)
               .OrderBy(x => x.ParentCategoryId).ThenBy(y => y.CategoryId);
           return query.ToList();
       }


        public static Category GetCategoryById(int pCategoryId)
        {
            var cat = SQLHelper.GetCategoryById(pCategoryId);           
            return cat;
        }

        public static bool UpdateCategory(Category dbCategory)
        {

            try
            {
                var retval = SQLHelper.UpdateCategory(dbCategory);
                if (retval > 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Category> GetAllSubCategoryByParentCategoryId(int categoryId)
        {
            var cats = SQLHelper.GetCategories();
            var subCategories = cats.Where(x => x.ParentCategoryId == categoryId && x.IsActive == true).ToList();
            return subCategories;
        }



       //public static bool SaveBulkCategory(List<Category> newCategories)
       //{
       //    EndtCommerceEntities ECE = new EndtCommerceEntities();
       //    foreach (Category c in newCategories)
       //    {
       //        Category dbCategory = ECE.Categories.Where(x => x.CategoryName == c.CategoryName).FirstOrDefault();
       //        if (dbCategory == null)
       //        {
       //            ECE.Categories.AddObject(c);
       //        }
       //        else
       //        {
       //            c.CategoryId = dbCategory.CategoryId;
       //        }
       //    }
       //    ECE.SaveChanges();
       //    return true;
       //}
    }
}
