using _3EndTDataLayer;
using _3EndTDataLayer.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTBusinessLayer
{
    public class OrderManager
    {
        public static int InsertOrder(Order order)
        {
            var retval = SQLHelper.InsertOrder(order);
            return order.OrderId.HasValue ? order.OrderId.Value : 0;
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
