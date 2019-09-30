using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3EndTDataLayer;
using System.Reflection;
using System.Data.Objects.DataClasses;
using System.Data;
using System.Web;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer.domain;

namespace _3EndTBusinessLayer
{
    public class CompanyManager
    {
        #region ParentCompany

        public static Boolean CheckIfParentExists(string name)
        {
            var parentCompanies = SQLHelper.GetParentCompanies();
            var query = parentCompanies.Where(x => x.Name.ToLower() == name.ToLower());
            if ((query != null) && (query.Count<ParentCompany>() > 0))
                return true;
            else
                return false;

        }

        public static bool InsertParentCompany(ParentCompany pComp)
        {
            var retval = SQLHelper.InsertParentCompany(pComp);
            if (retval > 0)
                return true;
            return false;
        }

        public static List<ParentCompany> GetParentCompanies(bool showActiveOnly = true)
        {
            var parentCompanies = SQLHelper.GetParentCompanies();
            if (showActiveOnly)
                parentCompanies = parentCompanies.Where(x => x.IsActive == true).ToList();
            return parentCompanies;
        }

        public static ParentCompany GetParentCompanyById(int pid)
        {
            return SQLHelper.GetParentCompanyById(pid);
        }

        #endregion


        #region Company

        public static List<Company> GetAllCompanies(bool showOnlyActive = true)
        {
            var cmps = SQLHelper.GetCompanies();
            if (showOnlyActive)
                cmps = cmps.Where(x => x.IsActive == true).ToList();
            return cmps;
        }

        public static bool CheckIfCompanyExists(string cname, string cmpFedId)
        {
            var cmps = SQLHelper.GetCompanies();
            var query = cmps.Where(x => x.CompanyName.ToLower() == cname.ToLower() && x.FederalId == cmpFedId);
            if ((query != null) && (query.Count<Company>() > 0)) return true;
            else return false;
        }

        public static bool InsertCompany(Company company)
        {
            var retval = SQLHelper.InsertCompany(company);
            if (retval > 0)
                return true;
            return false;
        }

        public static bool UpdateCompany(Company company)
        {
            var retval = SQLHelper.UpdateCompany(company);
            if (retval > 0)
                return true;
            return false;
        }

        public static Company GetCompanyByCompanyId(int companyId)
        {
            return SQLHelper.GetCompanyById(companyId);
        }



        /// <summary>
        /// To Remove
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public static Boolean CheckIfCompanyNameAlreadyExist(Company company)
        {
            var cmps = SQLHelper.GetCompanies();
            Company dbCompany = cmps.Where(x => x.CompanyName.ToLower() == company.CompanyName.ToLower()).FirstOrDefault();
            if (dbCompany == null)
                return false;
            else
                return true;
        }



        //public static List<GetCustomers_CompannyInfo_Result> GetCustomersCompanyDetails()
        //{
        //    using (EndtCommerceEntities ece = new EndtCommerceEntities())
        //    {
        //        List<GetCustomers_CompannyInfo_Result> CustomerCompantDetails = ece.GetCustomers_CompannyInfo().ToList();
        //        return CustomerCompantDetails; 
        //    }
        //}
        #endregion

        #region Addresses
        public static bool InsertAddress(Address addr)
        {
            var retval = SQLHelper.InsertAddress(addr);
            if (retval > 0)
                return true;
            return false;
        }
        public static Address GetAddressByID(int addrId)
        {
            return SQLHelper.GetAddressById(addrId);
        }

        public static bool UpdateAddress(Address newAddr)
        {
            var retval = SQLHelper.UpdateAddress(newAddr);
            if (retval > 0)
                return true;
            return false;
        }

        public static List<Address> GetAddressesByCompanyId(int companyId, bool addressType = AddressType.Shipping)
        {
            var addresses = SQLHelper.GetAddresses();

            var query = from addr in addresses
                        where addr.CompanyId == companyId && addr.IsActive == true && addr.Type == addressType
                        select addr;
            if (query != null)
                addresses = query.ToList();

            return addresses;
        }

        public static List<CompanyAddress> GetCompanyAddresses(bool addressType = AddressType.Shipping)
        {
            var addresses = SQLHelper.GetAddresses();
            var companies = SQLHelper.GetCompanies();
            if (addresses != null && companies != null)
            {
                var dbShippingAddress = from addr in addresses
                                        join comp in companies on addr.CompanyId equals comp.CompanyId
                                        where addr.IsActive == true && addr.Type == addressType && comp.IsActive
                                        select new CompanyAddress
                                        {
                                            CompanyId = comp.CompanyId.Value,
                                            AddressId = addr.AddressId.Value,
                                            Address1 = addr.AddressLine1,
                                            Address2 = addr.AddressLine2,
                                            AddressName = addr.AddressName,
                                            CompanyName = comp.CompanyName,
                                            ZipCode = addr.ZipCode,
                                            AddressType = addr.Type,
                                            City = addr.City,
                                            State = addr.State
                                        };
                return dbShippingAddress.ToList<CompanyAddress>();
            }
            return null;
        }

        public static Boolean CheckIfAddressAlreadyExists(Address newAddr)
        {
            var addrList = SQLHelper.GetAddresses();
            IEnumerable<Address> query = (from addr in addrList
                                          where addr.AddressLine1 == newAddr.AddressLine1 && addr.CompanyId == newAddr.CompanyId
                         && addr.City == newAddr.City && addr.State == newAddr.State && addr.Type == newAddr.Type && addr.IsActive == true
                                          select addr);
            if (newAddr.Type.Equals(AddressType.Billing))
            {
                query = (from addr in addrList
                         where addr.CompanyId == newAddr.CompanyId && addr.Type == newAddr.Type
                         select addr);
            }
            if (query.Count() <= 0) return false;
            else
            {
                newAddr.AddressId = query.SingleOrDefault<Address>().AddressId;
                return true;
            }

        }

        public static DataSet GetStates()
        {
            DataSet ds = new DataSet();
            string filePath = HttpContext.Current.Request.MapPath("/admin/states.xml");
            ds.ReadXml(filePath);

            return ds;
        }
        #endregion


    }
}
