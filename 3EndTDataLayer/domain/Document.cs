using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Document: BaseDomain
    {
        public int? DocumentId { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Url { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
