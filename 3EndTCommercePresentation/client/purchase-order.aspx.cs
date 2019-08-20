using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System.Web.Security;
using System.IO;
using System.Configuration;
using System.Text;

namespace _3EndTCommercePresentation.client
{
    public partial class purchase_order : System.Web.UI.Page
    {
        public static int CustomerId
        {
            get
            {
                return SessionManager.CustomerId;
            }
        }
        public static int CompanyId
        {
            get
            {
                return SessionManager.CompanyId;
            }
        }
        Company Company = null;
        Address SelectedCompanyShipAddr = null;
        List<Address> CompanyShipAddrs = null;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (CustomerId <= 0)
                Response.Redirect("~/Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Company = CompanyManager.GetCompanyByCompanyId(CompanyId);
            lblConfirmation.ToDisplayNone();
            LoadAddresses();
            if (!IsPostBack)
                BindAddresses();  
        }

        private void LoadAddresses()
        {
            CompanyShipAddrs = CompanyManager.GetAddressesByCompanyId(CompanyId);
            Address billaddress = CompanyManager.GetAddressesByCompanyId(CompanyId, AddressType.Billing).SingleOrDefault();
            if (!string.IsNullOrEmpty(billaddress.AddressLine1))
                LoadAddressLabels(lblBillingAddressName, lblBillingAddress, billaddress);

            if (CompanyShipAddrs != null)
            {
                SelectedCompanyShipAddr = CompanyShipAddrs.Where(x => x.IsPrimary == true).FirstOrDefault();
                LoadAddressLabels(lblShippingAddressName, lblShippingAddress, SelectedCompanyShipAddr);
            }
        }

        private void BindAddresses()
        {
            if (CompanyShipAddrs.Count() > 1)
                divChangeShipping.Style.Add("display", "table-row");

            dlCartItems.DataSource = ShoppingCart.Instance.CartItems;
            dlCartItems.DataBind();

            lvShippingAddressSelection.DataSource = CompanyShipAddrs;
            lvShippingAddressSelection.DataBind();
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PurchaseMaster puchasemaster = new PurchaseMaster();
            // po == purchase order
            PurchaseOrderMaster pomaster = new PurchaseOrderMaster();
            pomaster.CustomerId = CustomerId;
            pomaster.OrderDate = DateTime.Now;
            pomaster.PurchaseOrderNumber = txtPurchaseOrderNumber.Text.Trim();            
            pomaster.BillingAddressId = CompanyManager.GetAddressesByCompanyId(CompanyId, AddressType.Billing).FirstOrDefault().AddressId;
            pomaster.ConfirmationNumber = PurchaseMaster.GetConfirmationNumber(Company.CompanyName);
            pomaster.OrderStatusId = (int)Enums.PurchaseOrderStatus.Accepted;
            if (string.IsNullOrEmpty(hdnSelectedShipping.Value))
                hdnSelectedShipping.Value = SelectedCompanyShipAddr.AddressId.ToString();
            pomaster.CompanyShippingAddressId = Convert.ToInt32(hdnSelectedShipping.Value);
            int orderid = PurchaseMaster.InsertPurchaseMaster(pomaster);

            foreach (CartItem ci in ShoppingCart.Instance.CartItems)
            {
                PurchaseOrderDetail podetail = new PurchaseOrderDetail();
                podetail.PurchaseOrderId = orderid;
                podetail.ProductItemId = ci.ProductItemId;
                podetail.Quantity = ci.Quantity;
                podetail.UnitPrice = ci.UnitPrice;
                podetail.TotalProductPrice = ci.TotalPrice;
                podetail.ProductId = ci.ProductId;
                PurchaseMaster.InsertPurchaseDetail(podetail);
            }
            CreateEmail(pomaster.ConfirmationNumber, pomaster.PurchaseOrderNumber);
            ClearData();
            Response.Redirect( string.Format("/client/order-confirmation.aspx?conf={0}&po={1}",pomaster.ConfirmationNumber,pomaster.PurchaseOrderNumber));
        }

        private void CreateEmail(string confNum, string poNum)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.H3);
                writer.WriteLine("{0} has placed the order ", Company.CompanyName);
                writer.WriteBreak();
                writer.WriteLine("Purchase Order Number: {0}", poNum);
                writer.WriteBreak();
                writer.WriteLine("Confirmation Number: {0}", confNum);
                writer.WriteBreak();
                writer.Write("Order Details: ");
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Ul);

                foreach (var cart in ShoppingCart.Instance.CartItems)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                    writer.Write("Item: {0} -- Quantity: {1}", cart.ProductName, cart.Quantity);
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
            // Return the result.
            string body = stringWriter.ToString();
            string subject = string.Format("Order Recieved Confirmation number: {0}", confNum);

            Enums.EmailSentStatus emailstatus = EmailManager.SendEmail(subject, body, null, 0);

        }

        private void ClearData()
        {
            ShoppingCart.Instance.FlushShoppingCart();
            dlCartItems.DataSource = null;
            dlCartItems.DataBind();

            lblConfirmation.ToDisplayBlock();

            FormsAuthentication.SignOut();
            //Roles.DeleteCookie();
            this.Session.Abandon();
            this.Session.Clear();            
        }

        protected void lvShippingAddressSelection_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "changeshipping")
            {
                if (!string.IsNullOrEmpty(hdnSelectedShipping.Value))
                {
                    int selshipid = Convert.ToInt32(hdnSelectedShipping.Value);
                    if (CompanyShipAddrs != null)
                    {
                        SelectedCompanyShipAddr = CompanyShipAddrs.Where(c => c.AddressId == selshipid).SingleOrDefault<Address>();
                        if (SelectedCompanyShipAddr != null)                        
                            LoadAddressLabels(lblShippingAddressName, lblShippingAddress, SelectedCompanyShipAddr); 
                    }
                }
            }
            
        }

        private void LoadAddressLabels(Label lblAddressName, Label lblAddress,Address addr)
        {
            if (!string.IsNullOrEmpty(addr.AddressLine1))
            {
                lblAddressName.Text = addr.AddressName;
                StringBuilder sb = new StringBuilder();
                sb.Append(addr.AddressLine1);
                if (!string.IsNullOrEmpty(addr.AddressLine2))
                    sb.Append("<br />" + addr.AddressLine2);
                sb.Append("<br />" + addr.City);
                sb.Append("<br />" + addr.State);
                lblAddress.Text = sb.ToString();
            }
        }

        protected void lvShippingAddressSelection_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (SelectedCompanyShipAddr != null)
                {
                    Control cntrl = e.Item.FindControl("rbtnShippingAddress");
                    if (cntrl != null)
                    {
                        RadioButton rbtn = cntrl as RadioButton;
                        if (!string.IsNullOrEmpty(rbtn.Attributes["data-value"])) ;
                        {
                            int datavalue = Convert.ToInt16(rbtn.Attributes["data-value"]);
                            if (SelectedCompanyShipAddr.AddressId == datavalue)
                                rbtn.Checked = true;
                        }
                    }
                    hdnSelectedShipping.Value = SelectedCompanyShipAddr.AddressId.ToString() ;
                }
            }
        }
    }
}
