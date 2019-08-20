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

namespace _3EndTBusinessLayer
{
    public class CompanyManager
    {
         #region ParentCompany

        public static Boolean CheckIfParentExists(string name)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var query = ece.ParentCompanies.Where(x => x.Name.ToLower() == name.ToLower());
                if ((query != null) && (query.Count<ParentCompany>() > 0)) return true;
                else return false;
            }
        }

        public static void InsertParentCompany(ParentCompany pComp)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                ece.AddToParentCompanies(pComp);
                ece.SaveChanges();
            }
        }

        public static List<ParentCompany> GetAllParentCompanies()
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                return ece.ParentCompanies.ToList<ParentCompany>();
            }
        }

        public static ParentCompany GetParentCompanyById(int pid)
        {

            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var query = ece.ParentCompanies.Where(p => p.ParentCompanyId == pid);
                if (query != null && query.Count() > 0)
                {
                    return query.FirstOrDefault<ParentCompany>();
                }
                return null;
            }
        }

        #endregion


        #region Company

        public static List<Company> GetAllCompanies()
        {         
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                List<Company> comps = ece.Companies.Where(x => x.IsActive == true).ToList();
                return comps; 
            }
        }

        public static Boolean CheckIfCompanyExists(string cname,string cmpFedId)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var query = ece.Companies.Where(x => x.CompanyName.ToLower() == cname.ToLower() && x.FederalId == cmpFedId);
                if ((query != null) && (query.Count<Company>() > 0)) return true;
                else return false; 
            }
        }

        public static void InsertCompany(Company company)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                ece.Companies.AddObject(company);
                ece.SaveChanges(); 
            }
        }

        public static void UpdateCompany(Company company)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var stub = new Company {CompanyId=company.CompanyId };
                ece.Companies.Attach(stub);
                ece.Companies.ApplyCurrentValues(company);
                ece.SaveChanges();
            }
        }

        public static Company GetCompanyByCompanyId(int CompanyId)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                Company company = ece.Companies.Where(x => x.CompanyId == CompanyId).FirstOrDefault();
                return company; 
            }
        }



        /// <summary>
        /// To Remove
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public static Boolean CheckIfCompanyNameAlreadyExist(Company company)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                Company dbCompany = ece.Companies.Where(x => x.CompanyName.ToLower() == company.CompanyName.ToLower()).FirstOrDefault();
                if (dbCompany == null) return false;
                else return true; 
            }

        }
        

       
        public static List<GetCustomers_CompannyInfo_Result> GetCustomersCompanyDetails()
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                List<GetCustomers_CompannyInfo_Result> CustomerCompantDetails = ece.GetCustomers_CompannyInfo().ToList();
                return CustomerCompantDetails; 
            }
        }
        #endregion

        #region Addresses
        public static void InsertAddress(Address addr)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                ece.AddToAddresses(addr);
                ece.SaveChanges();
            }
        }
        public static Address GetAddressByID(long addrId)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                Address dbShipping = ece.Addresses.Where(x => x.AddressId == addrId).FirstOrDefault();
                return dbShipping;
            }
        }

        public static void UpdateAddress(Address newAddr)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                //Lets try to update everything
                var dbshipaddr = (from addr in ece.Addresses
                                  where addr.CompanyId == newAddr.CompanyId && addr.AddressId == newAddr.AddressId && addr.Type == newAddr.Type
                                  select addr).FirstOrDefault<Address>();

                dbshipaddr.AddressLine1 = newAddr.AddressLine1;
                dbshipaddr.AddressLine2 = newAddr.AddressLine2;
                dbshipaddr.City = newAddr.City;
                dbshipaddr.IsPrimary = newAddr.IsPrimary;
                dbshipaddr.IsActive = newAddr.IsActive;
                dbshipaddr.State = newAddr.State;
                dbshipaddr.Zipcode = newAddr.Zipcode;
                dbshipaddr.Type = newAddr.Type;
                ece.SaveChanges();
            }

                  

        }
        public static List<Address> GetAddressesByCompanyId(int companyId,bool addressType=AddressType.Shipping)
        {
            List<Address> dbcompshippaddress = null;
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var query = from addr in ece.Addresses
                            where addr.CompanyId == companyId && addr.IsActive == true && addr.Type == addressType
                            select addr;
                if (query != null)
                    dbcompshippaddress = query.ToList();

                return dbcompshippaddress;
            }
        }
        
        public static List<CompanyAddress> GetCompanyAddresses(bool addressType=AddressType.Shipping)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                var dbShippingAddress = from addr in ece.Addresses
                                        join comp in ece.Companies on addr.CompanyId equals comp.CompanyId
                                        where addr.IsActive == true && addr.Type == addressType && comp.IsActive
                                        select new CompanyAddress
                                        {
                                            CompanyId = comp.CompanyId,
                                            AddressId = addr.AddressId,
                                            Address1 = addr.AddressLine1,
                                            Address2 = addr.AddressLine2,
                                            AddressName = addr.AddressName,
                                            CompanyName = comp.CompanyName,
                                            ZipCode = addr.Zipcode,
                                            AddressType = addr.Type,
                                            City = addr.City,
                                            State = addr.State
                                        };

                return dbShippingAddress.ToList<CompanyAddress>();
            }
        }

        public static Boolean CheckIfAddressAlreadyExists(Address newAddr)
        {
            using (EndtCommerceEntities ece = new EndtCommerceEntities())
            {
                IEnumerable<Address> query = (from addr in ece.Addresses
                             where addr.AddressLine1 == newAddr.AddressLine1 && addr.CompanyId == newAddr.CompanyId
                             && addr.City == newAddr.City && addr.State == newAddr.State  && addr.Type==newAddr.Type
                             select addr);
                if (newAddr.Type.Equals(AddressType.Billing))
                {
                    query = (from addr in ece.Addresses
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
        }

        public static DataSet GetStates()
        {
            DataSet ds = new DataSet();
            string filePath = HttpContext.Current.Request.MapPath("/admin/states.xml");
            ds.ReadXml(filePath);

            return ds;
        }
        #endregion


       
        /// <summary>
        /// To Remove
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="company"></param>
        /// <param name="shippingAddresses"></param>
        /// <returns></returns>
        public static bool CreateUser(Customer customer, Company company, List<Address> shippingAddresses)
        {      
            try
            {
                using (EndtCommerceEntities ece = new EndtCommerceEntities())
                {
                    foreach (Address shippingAddress in shippingAddresses)
                    {
                        ece.AddToAddresses(shippingAddress);
                        ece.SaveChanges();
                    }
                    ece.AddToCompanies(company);
                    ece.SaveChanges();
                    return true; 
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
