using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer
{
    public class DocumentManager
    {
        public static string GenerateUniqueKey(string title, string fileName)
        {
            string retval = string.Empty;
            retval = string.Format("{0}_{1}", title.Trim().Replace(" ", string.Empty), fileName.Trim().Replace(" ", string.Empty));
            return retval;
        }

        public static bool InsertDocumentRecord(Document doc)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            if (!CheckIfDocumentExists(ECE, doc))
            {
                ECE.Documents.AddObject(doc);
                ECE.SaveChanges();
                return true;
            }
            return false;
        }
        internal static bool CheckIfDocumentExists(EndtCommerceEntities ECE, Document doc)
        {
            if (ECE.Documents != null && ECE.Documents.Count() > 0)
            {
                var query = ECE.Documents.Any(x => x.Key == doc.Key);
                return query;
            }
            return false;
        }
        public static List<Document> GetAllDocuments()
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            return ECE.Documents.Where(x => x.IsActive == true).ToList();
        }
    }
}
