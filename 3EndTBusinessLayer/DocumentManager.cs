using _3EndTDataLayer;
using _3EndTDataLayer.domain;
using System.Collections.Generic;
using System.Linq;

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
            if (!CheckIfDocumentExists(doc))
            {
                var retval = SQLHelper.InsertDocument(doc);
                if (retval > 0)
                    return true;
                return false;
            }
            return false;
        }
        internal static bool CheckIfDocumentExists(Document doc)
        {
            var docs = SQLHelper.GetDocuments();
            if (docs != null && docs.Count() > 0)
            {
                var query = docs.Any(x => x.Key == doc.Key);
                return query;
            }
            return false;
        }
        public static List<Document> GetAllDocuments(bool showActiveOnly=true)
        {
            var docs = SQLHelper.GetDocuments();
            if (showActiveOnly)
                docs = docs.Where(x => x.IsActive == true).ToList();
            return docs;
        }
    }
}
