using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using _3EndTBusinessLayer;
using _3EndTDataLayer;
using _3EndTBusinessLayer.BusinessObject;

namespace _3EndTCommercePresentation
{
    public partial class SignUp : System.Web.UI.Page
    {
        //public static string Password { get; set; }
        //public static long ShippingAddressId { get; set; }
        //static List<Address> shippingAddresses = new List<Address>();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        RandomPassword();
        //        lblPassword.Text = Password;
        //    }

        //}
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.Page.Validate();
        //    if (!this.Page.IsValid)
        //        return;
        //    string UserName = txtUserId.Text.Trim();
        //    int RoleTypeId = (int)Enums.UserRole.Customer;
        //    string FirstName = txtFirstName.Text.Trim();
        //    string LastName = txtLastName.Text.Trim();
        //    int TierId;
        //    bool IsActive = true;
        //    bool IsEmailSend = false;
        //    bool IsSpecial = false;
        //    string CompanyName = txtCompanyName.Text.Trim();
        //    string ParentCompanyName = txtParentCompanyName.Text.Trim();
        //    string CompanyBillingAddress = txtBillingAddress.Text.Trim();
        //    string FederalId = txtFederalId.Text.Trim();
        //    string Contact = txtContact.Text.Trim();
        //    string FaxNo = txtFaxNumber.Text.Trim();
        //    string EmailId = txtEmailId.Text.Trim();
            
        //    Customer customer = new Customer();
        //    //User user = new User();
        //    Company company = new Company();

        //    Tier tier = TierManager.GetDefaultTier();
        //    TierId = tier.TierId;

        //    customer.FirstName = FirstName;
        //    customer.LastName = LastName;
        //    //customer.TierId = TierId;
        //    //customer.IsSpecial = IsSpecial;
        //    customer.IsEmailSend = IsEmailSend;

        //    customer.UserName = UserName;
        //    customer.RoleId = RoleTypeId;
        //    customer.Password = Password;
        //    //customer.Users.Add(user);

        //    company.CompanyName = CompanyName;
        //   // company.ParentCompanyName = ParentCompanyName;
        //    //TODO: Fix address
        //   // company.BillingAddress =CompanyBillingAddress;
        //    company.FederalId = FederalId;
        //    company.PhoneNumber = Contact;
        //    company.FaxNumber =FaxNo;
        //    company.EMailId = EmailId;
           
            
        
        //    if (UserManager.CheckIfUserNameAlreadyExist(customer))
        //    {
        //        lblMessage.Text = "User Name Already Exists.";
        //        return;
        //    }
        //    if (CustomerManager.InsertCustomer(customer))
        //    {
        //        lblMessage.Text = "Data Saved";
               
        //    }
        //    if (shippingAddresses.Count().Equals(0))
        //    {
        //        lblMessage.Text = "Add Shipping Address";
        //        return;
        //    }

        //    if (CompanyManager.CheckIfCompanyNameAlreadyExist(company))
        //    {
        //        lblMessage.Text = "Company Name Already Exists.";
        //        return;
        //    }
        //    //if (CompanyManager.CheckIfSubCompanyNameAlreadyExist(company))
        //    //{
        //    //    lblMessage.Text = "Sub-Company Name Already Exists.";
        //    //    return;
        //    //}
        //    if (CompanyManager.CreateUser(customer,company, shippingAddresses))
        //    {
               
        //        EmailManager.SendEmailMessage(customer);
        //        lblMessage.Text = "Account Created Successfully.";
        //        ResetControls();
                
        //    }
        //    else
        //    {
        //        lblMessage.Text = "Data Save Failed";
        //    }
          
            
        //}
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ResetControls();
        //}
        //public void RandomPassword()
        //{
        //    var chars = "@#$%&*^ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    var random = new Random();
        //    var result = new string(
        //    Enumerable.Repeat(chars, 10)
        //          .Select(s => s[random.Next(s.Length)])
        //          .ToArray());
        //    Password = result.ToString();
        //    Boolean isDuplicate = true;
        //    while (isDuplicate)
        //    {
        //        isDuplicate = UserManager.IsPasswordExist(Password);
        //        if (isDuplicate)
        //            Password = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray()).ToString();
        //    }
        //}
        //protected void ResetControls()
        //{
        //    this.txtFirstName.Text = string.Empty;
        //    this.txtLastName.Text = string.Empty;
        //    this.txtUserId.Text = string.Empty;
        //    txtCompanyName.Text = string.Empty;
        //    txtParentCompanyName.Text = string.Empty;
        //    txtBillingAddress.Text = string.Empty;
        //    txtFederalId.Text = string.Empty;
        //    txtContact.Text = string.Empty;
        //    txtFaxNumber.Text = string.Empty;
        //    txtEmailId.Text = string.Empty;
        //    shippingAddresses.Clear();
        //    LoadShippingAddress();
            

        //}
        //protected void gvShippingAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("cmdedit"))
        //    {
        //        //ShippingAddressId = Int64.Parse(e.CommandArgument.ToString());
        //        //ShippingAddress shippingAddress = CompanyManager.GetShippingAddressByID(ShippingAddressId);
        //        //txtShiippingName.Text = shippingAddress.ShippingAddressName;
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(@"<script type='text/javascript'>");
        //        sb.Append("$('#editModal').modal('show');");
        //        sb.Append(@"</script>");
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        //                   "ModalScript", sb.ToString(), false);

        //    }
        //}
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    //ShippingAddress shippingAddress = shippingAddresses.Where(x => x.ShippingAddressId == ShippingAddressId).FirstOrDefault();
        //    //shippingAddress.ShippingAddressName = txtShiippingName.Text.Trim();
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.Append(@"<script type='text/javascript'>");
        //    sb.Append("$('#editModal').modal('hide');");
        //    sb.Append(@"</script>");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        //               "ModalScript", sb.ToString(), false);
        //    //LoadShippingAddress();
        //}
        //protected void btnAddNewShippingAddress_Click(object sender, EventArgs e)
        //{

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.Append(@"<script type='text/javascript'>");
        //    sb.Append("$('#addModal').modal('show');");
        //    sb.Append(@"</script>");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        //               "ModalScript", sb.ToString(), false);


        //}
        //protected void gvShippingAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //grdTier.PageIndex = e.NewPageIndex;
        //    //LoadTiers();
        //}
        //protected void btnAddRecord_Click(object sender, EventArgs e)
        //{
        //    string ShippingAddressName = txtShippingAddressName.Text.Trim();
        //    bool IsPrimary=rdoIsPrimary.Checked;
        //    CompanyShippingAddress dbShippingAddress = new CompanyShippingAddress();
        //    //dbShippingAddress.ShippingAddressName = ShippingAddressName;
        //    if (rdoIsPrimary.Checked)
        //    {
        //        dbShippingAddress.IsPrimary = IsPrimary;
        //    }
        //    else
        //    {
        //        dbShippingAddress.IsPrimary = false;
        //    }
        //    if (CheckIfSippingAddressAlreadyExistInTheList(dbShippingAddress))
        //    {
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        sb.Append(@"<script type='text/javascript'>");
        //        sb.Append("$('#addModal').modal('hide');");
        //        sb.Append(@"</script>");
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        //                   "ModalScript", sb.ToString(), false);
        //        lblDispaly.Text = "Shipping Address Already Exists.";
        //        return;
        //    }
        //    if (AppendShippingAddressToList(dbShippingAddress))
        //    {

        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        sb.Append(@"<script type='text/javascript'>");
        //        sb.Append("$('#addModal').modal('hide');");
        //        sb.Append(@"</script>");
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        //                   "ModalScript", sb.ToString(), false);
        //        //lblMessage.Text = "Shipping Address Added";
        //        LoadShippingAddress();
        //        //ShippingAddressId = dbShippingAddress.ShippingAddressId;


        //    }

        //}
        //protected void LoadShippingAddress()
        //{

        //    gvShippingAddress.DataSource = shippingAddresses;
        //    gvShippingAddress.DataBind();
        //}
        //public bool AppendShippingAddressToList(Address shippingAddress)
        //{
        //   // shippingAddresses.Add(shippingAddress);
        //    return true;
        //}



        //public bool CheckIfSippingAddressAlreadyExistInTheList(Address shippingAddress)
        //{
        //    //if (shippingAddresses.Where(x => x.ShippingAddressName == shippingAddress.ShippingAddressName).FirstOrDefault() == null)
        //    //    return false;
        //    //else return true;
        //    return false;
        //}

    }
}