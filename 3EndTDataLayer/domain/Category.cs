using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Category : BaseDomain
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryLevel { get; set; }
        public int? ParentCategoryId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsService { get; set; }
    }
}
