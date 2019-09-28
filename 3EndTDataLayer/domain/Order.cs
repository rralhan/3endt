using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EndTDataLayer.domain
{
    public class Order : BaseDomain
    {
        public int? OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public string ConfirmationNumber { get; set; }

        public DateTime? ConfirmationSendDate { get; set; }

        public DateTime? DateShipped { get; set; }

        public string Comments { get; set; }

        public decimal? ShippingCost { get; set; }

        public int OrderStatusId { get; set; }

        public int CompanyShippingAddressId { get; set; }

        public int BillingAddressId { get; set; }
    }
    public class OrderDetail : BaseDomain
    {
        public int? OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public int PurchaseOrderId { get; set; }

        public decimal TotalProductPrice { get; set; }

        public int ProductItemId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

    }
    public class OrderStatus : BaseDomain
    {
        public int OrderStatusId { get; set; }

        public bool IsActive { get; set; }

        public string Status { get; set; }

    }

}
