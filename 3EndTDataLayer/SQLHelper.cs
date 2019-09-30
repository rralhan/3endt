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
           ,CreatedDate
           ,IsActive)
     VALUES
           (@Name
           ,@FederalId
           ,@CreatedDate
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
                return cn.Execute(sqlStr, addr); ;
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
    }

}
