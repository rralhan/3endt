using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer
{
    public class PurchaseMaster
    {
        public static int InsertPurchaseMaster(PurchaseOrderMaster poMaster)
        {
            EndtCommerceEntities ece = new EndtCommerceEntities();
            ece.PurchaseOrderMasters.AddObject(poMaster);
            ece.SaveChanges();
            return poMaster.PurchaseOrderId;
        }
        public static string GetConfirmationNumber(string company)
        {
            var chars = "0123456789abcdefghijklmno";
            var random = new Random();
            string result = company.Replace(" ","").Substring(0, 5) + new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            EndtCommerceEntities ece = new EndtCommerceEntities();
            if (ece.PurchaseOrderMasters.Any(p => p.ConfirmationNumber == result))
                result = GetConfirmationNumber(company);      
        
            return result;
        }
        public static void InsertPurchaseDetail(PurchaseOrderDetail poDetail)
        {
            EndtCommerceEntities ece = new EndtCommerceEntities();
            if(!ece.PurchaseOrderDetails.Any(p => p.PurchaseOrderId == poDetail.PurchaseOrderId && p.ProductItemId == poDetail.ProductItemId))            
            {
                ece.PurchaseOrderDetails.AddObject(poDetail);
                ece.SaveChanges();
            }
            
        }
    }
}
