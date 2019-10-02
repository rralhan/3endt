using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3EndTDataLayer.domain;
using Dapper;


namespace _3EndTDataLayer
{
    public class SQLHelper
    {
        #region Category
        static string _connStr = ConfigurationManager.ConnectionStrings["EndtCommerceEntities"].ConnectionString;
        public static List<Category> GetCategories()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Categories";
                var catList = cn.Query<Category>(sqlStr).ToList();
                return catList;
            }
        }

        public static Category GetCategoryById(int categoryId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Categories where CategoryId=@CategoryId";
                var ct = cn.QueryFirst<Category>(sqlStr, new
                {
                    CategoryId = categoryId
                });
                return ct;
            }
        }

        public static int InsertCategory(Category cmp)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.Categories
           (CategoryName
           ,CategoryLevel
           ,ParentCategoryId
           ,ImageUrl
           ,IsService                 
           ,IsActive)
     VALUES
           (@CategoryName
           ,@CategoryLevel
           ,@ParentCategoryId
           ,@ImageUrl
           ,@IsService            
           ,@IsActive);";
                return cn.Execute(sqlStr, cmp);
            }
        }

        public static int UpdateCategory(Category cat)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE [dbo].[Categories]
SET CategoryName = @CategoryName
	,CategoryLevel = @CategoryLevel
	,ParentCategoryId = @ParentCategoryId
	,ImageUrl = @ImageUrl
	,IsService = @IsService
	,ModifiedDate = @ModifiedDate
	,IsActive = @IsActive
WHERE CategoryId = @CategoryId";
                return cn.Execute(sqlStr, cat); ;
            }
        }
        #endregion

        #region Company
        public static List<Company> GetCompanies()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {                
                cn.Open();
                
                var sqlStr = "Select * from Companies";
                var cmpList = cn.Query<Company>(sqlStr).ToList();
                return cmpList;
            }
        }

        public static int InsertCompany(Company cmp)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO [dbo].[Companies] (
	TierId
	,CompanyName
	,FederalId
	,IsSpecial
	,PhoneNumber
	,FaxNumber
	,Email
	,ParentCompanyId
	,IsActive
	)
VALUES (
	@TierId
	,@CompanyName
	,@FederalId
	,@IsSpecial
	,@PhoneNumber
	,@FaxNumber
	,@Email
	,@ParentCompanyId
	,@IsActive
	);";
                return cn.Execute(sqlStr, cmp); ;
            }
        }

        public static int UpdateCompany(Company cmp)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE [dbo].[Companies]
SET TierId = @TierId
	,CompanyName = @CompanyName
	,FederalId = @FederalId
	,IsSpecial = @IsSpecial
	,PhoneNumber = @PhoneNumber
	,FaxNumber = @FaxNumber
	,Email = @Email
    ,IsActive = @IsActive
    ,ModifiedDate = @ModifiedDate
WHERE CompanyId = @CompanyId";
                return cn.Execute(sqlStr, cmp); ;
            }
        }

        public static Company GetCompanyById(int companyId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Companies where CompanyId=@CompanyId";
                var ct = cn.QueryFirst<Company>(sqlStr, new
                {
                    CompanyId = companyId
                });
                return ct;
            }
        }

        public static List<ParentCompany> GetParentCompanies()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from ParentCompanies";
                var cmpList = cn.Query<ParentCompany>(sqlStr).ToList();
                return cmpList;
            }
        }

        public static int InsertParentCompany(ParentCompany cmp)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.ParentCompanies
           (Name
           ,FederalId       
           ,IsActive)
     VALUES
           (@Name
           ,@FederalId        
           ,@IsActive);";
                return cn.Execute(sqlStr, cmp);
            }
        }

        public static ParentCompany GetParentCompanyById(int parentCompanyId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from ParentCompanies where ParentCompanyId=@CompanyId";
                var ct = cn.QueryFirst<ParentCompany>(sqlStr, new
                {
                    CompanyId = parentCompanyId
                });
                return ct;
            }
        }

        #endregion

        #region Address

        public static List<Address> GetAddresses()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Addresses";
                var addrList = cn.Query<Address>(sqlStr).ToList();
                return addrList;
            }
        }

        public static int InsertAddress(Address addr)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"
INSERT INTO dbo.Addresses
           (CompanyId
           ,AddressName
           ,AddressLine1
           ,AddressLine2
           ,City
           ,State
           ,Zipcode
           ,IsPrimary
           ,Type
           ,IsActive)
     VALUES
           (@CompanyId
           ,@AddressName
           ,@AddressLine1
           ,@AddressLine2
           ,@City
           ,@State
           ,@Zipcode
           ,@IsPrimary
           ,@Type
           ,@IsActive)
";
                return cn.Execute(sqlStr, addr);
            }
        }

        public static Address GetAddressById(int addressId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Addresses where AddressId=@AddressId";
                var ct = cn.QueryFirst<Address>(sqlStr, new
                {
                    AddressId = addressId
                });
                return ct;
            }
        }

        public static int UpdateAddress(Address addr)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE dbo.Addresses
   SET CompanyId = @CompanyId
      ,AddressName = @AddressName
      ,AddressLine1 = @AddressLine1
      ,AddressLine2 = @AddressLine2
      ,City = @City
      ,State = @State
      ,Zipcode = @Zipcode
      ,IsPrimary = @IsPrimary
      ,Type = @Type 
      ,ModifiedDate = @ModifiedDate
      ,IsActive = @IsActive
 WHERE AddressId=@AddressId";
                return cn.Execute(sqlStr, addr); ;
            }
        }
        #endregion

        #region User
        public static int InsertUser(User user)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"
INSERT INTO dbo.Users
           (RoleId
           ,FirstName
           ,LastName
           ,IsEmailSend
           ,UserName
           ,Password
           ,EMailId
           ,PhoneNumber
           ,FaxNumber
           ,CompanyId            
           ,IsActive)
     VALUES
           (@RoleId
           ,@FirstName
           ,@LastName
           ,@IsEmailSend
           ,@UserName
           ,@Password
           ,@EMailId
           ,@PhoneNumber
           ,@FaxNumber
           ,@CompanyId
           ,@IsActive)
";
                return cn.Execute(sqlStr, user);
            }

        }

        public static List<User> GetUsers()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Users";
                var userList = cn.Query<User>(sqlStr).ToList();
                return userList;
            }
        }

        public static int UpdateUser(User user)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE dbo.Users
   SET RoleId = @RoleId
      ,FirstName = @FirstName
      ,LastName = @LastName
      ,IsEmailSend = @IsEmailSend
      ,UserName = @UserName
      ,Password = @Password
      ,EMailId = @EMailId
      ,PhoneNumber = @PhoneNumber
      ,FaxNumber = @FaxNumber
      ,CompanyId = @CompanyId   
      ,ModifiedDate = @ModifiedDate
      ,IsActive = @IsActive
 WHERE UserId=@UserId";
                return cn.Execute(sqlStr, user);
            }
        }

        #endregion

        #region Document
        public static List<Document> GetDocuments()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Documents";
                var docList = cn.Query<Document>(sqlStr).ToList();
                return docList;
            }
        }

        public static int InsertDocument(Document doc)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.Documents
           (Key
           ,Title
           ,FilePath
           ,Url
           ,IsActive)
     VALUES
           (@Key
           ,@Title
           ,@FilePath
           ,@Url
           ,@IsActive);";
                return cn.Execute(sqlStr, doc);
            }
        }
        #endregion

        #region Tier

        public static List<Tier> GetTiers()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Tiers";
                var tierList = cn.Query<Tier>(sqlStr).ToList();
                return tierList;
            }
        }

        public static Tier GetTierById(int tierId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Tiers where TierId=@TierId";
                var ct = cn.QueryFirst<Tier>(sqlStr, new
                {
                    TierId = tierId
                });
                return ct;
            }
        }

        public static int InsertTier(Tier tier)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"
INSERT INTO dbo.Tiers
           (TierName
           ,IsActive
           ,IsDefault
           )
     VALUES
           (@TierName
           ,@IsActive
           ,@IsDefault
           )";
                return cn.Execute(sqlStr, tier);
            }
        }

        public static int UpdateTier(Tier tier)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE dbo.Tiers
   SET TierName = @TierName
      ,IsActive = @IsActive
      ,IsDefault = @IsDefault
      ,CreatedDate = @CreatedDate
      ,ModifiedDate = @ModifiedDate
 WHERE TierId=@TierId";
                return cn.Execute(sqlStr, tier);
            }
        }

        #endregion

        #region Order
        public static int InsertOrder(Order order)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.Orders
           (UserId
           ,OrderStatusId
           ,BillingAddressId
           ,CompanyShippingAddressId
           ,PurchaseOrderNumber
           ,ConfirmationNumber
           ,ConfirmationSendDate
           ,DateShipped
           ,Comments
           ,ShippingCost
           ,IsActive)
     VALUES
           (@UserId
           ,@OrderStatusId
           ,@BillingAddressId
           ,@CompanyShippingAddressId
           ,@PurchaseOrderNumber
           ,@ConfirmationNumber
           ,@ConfirmationSendDate
           ,@DateShipped
           ,@Comments
           ,@ShippingCost
           ,@IsActive);";
                return cn.Execute(sqlStr, order);
            }
        }

        public static List<Order> GetOrders()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Orders";
                var orderList = cn.Query<Order>(sqlStr).ToList();
                return orderList;
            }
        }

        public static List<OrderDetail> GetOrderDetails()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from OrderDetails";
                var orderList = cn.Query<OrderDetail>(sqlStr).ToList();
                return orderList;
            }
        }

        public static int InsertOrderDetail(OrderDetail orderDtl)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.OrderDetails
           (OrderId
           ,ProductId
           ,ProductItemId
           ,Quantity
           ,TotalProductPrice
           ,UnitPrice
           ,CreatedDate           
           ,IsActive)
     VALUES
           (@OrderId
           ,@ProductId
           ,@ProductItemId
           ,@Quantity
           ,@TotalProductPrice
           ,@UnitPrice
           ,@CreatedDate       
           ,@IsActive);";
                return cn.Execute(sqlStr, orderDtl);
            }
        }


        #endregion

        #region Product

        public static List<Product> GetProducts()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from Products";
                var prdList = cn.Query<Product>(sqlStr).ToList();
                return prdList;
            }
        }

        public static int InsertProduct(Product prd)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"INSERT INTO dbo.Products
           (CategoryId
           ,ProductTitle
           ,Description
           ,Unit
           ,ImageUrl
           ,CreatedDate
           ,IsActive)
     VALUES
           (@CategoryId
           ,@ProductTitle
           ,@Description
           ,@Unit
           ,@ImageUrl
           ,@CreatedDate
           ,@IsActive);";
                return cn.Execute(sqlStr, prd);
            }
        }

        public static Product GetProductById(int productId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = "Select * from Products where ProductId=@ProductId";
                var ct = cn.QueryFirst<Product>(sqlStr, new
                {
                    ProductId = productId
                });
                return ct;
            }
        }

        public static int DeleteProduct(int productId)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE [dbo].[Products]
SET IsActive = @IsActive
WHERE ProductId = @ProductId";
                return cn.Execute(sqlStr, new { ProductId = productId, IsActive = false });
            }
        }



        public static List<ProductItem> GetProductItems()
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();

                var sqlStr = "Select * from GetProductItems";
                var prdList = cn.Query<ProductItem>(sqlStr).ToList();
                return prdList;
            }
        }

        public static int UpdateProductItem(ProductItem pi)
        {
            using (SqlConnection cn = new SqlConnection(_connStr))
            {
                cn.Open();
                var sqlStr = @"UPDATE dbo.Addresses
   SET CompanyId = @CompanyId
      ,AddressName = @AddressName
      ,AddressLine1 = @AddressLine1
      ,AddressLine2 = @AddressLine2
      ,City = @City
      ,State = @State
      ,Zipcode = @Zipcode
      ,IsPrimary = @IsPrimary
      ,Type = @Type 
      ,ModifiedDate = @ModifiedDate
      ,IsActive = @IsActive
 WHERE AddressId=@AddressId";
                return cn.Execute(sqlStr, pi);
            }
        }



        #endregion

    }
}
