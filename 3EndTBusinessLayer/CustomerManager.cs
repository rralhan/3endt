using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3EndTDataLayer;
using System.Reflection;
using System.Data.Objects.DataClasses;
using _3EndTBusinessLayer.BusinessObject;

namespace _3EndTBusinessLayer
{
    public class CustomerManager
    {
        public static bool InsertCustomer(Customer customer)
        {
            bool retval = false;
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            try
            {
                ECE.AddToCustomers(customer);
                ECE.SaveChanges();
                retval = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }
        public static bool UpdateIsEmailMessageSend(Customer dbCustomer)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            try
            {
                Customer Customer = ECE.Customers.Where(x => x.CustomerId == dbCustomer.CustomerId).FirstOrDefault();

                Customer.IsEmailSend = true;
                ECE.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static Customer GetAllCustomerById(int id)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            Customer Customer = ECE.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return Customer;
        }
        public static List<Customer> GetAllCustomers()
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<Customer> Customer = ECE.Customers.Where(c => c.RoleId != (int)Enums.UserRole.Administrator).ToList<Customer>();
            return Customer;
        }
        public static List<Customer> GetAllCustomerWithTierName()
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<Customer> Customers = ECE.Customers.ToList();
            return Customers;
        }

        public static bool UpdateCustomer(Customer customer)
        {
            try
            {
                EndtCommerceEntities ece = new EndtCommerceEntities();
                var query = ece.Customers.Where(x => x.CustomerId == customer.CustomerId);
                if (query != null && query.Count() > 0)
                {
                    Customer dbcust = query.FirstOrDefault<Customer>();
                    System.Reflection.PropertyInfo[] props = customer.GetType().GetProperties();
                    foreach (PropertyInfo pi in props)
                    {
                        if (pi.CanWrite)
                        {
                            EdmScalarPropertyAttribute[] attrs = (EdmScalarPropertyAttribute[])
                                 pi.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false);

                            foreach (EdmScalarPropertyAttribute attr in attrs)
                            {
                                if (attr.EntityKeyProperty)
                                    continue;

                                pi.SetValue(dbcust, pi.GetValue(customer));
                            }
                        }
                    }
                    ece.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static Boolean CheckIfCustomerAlreadyExist(Customer dbCustomer)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            Customer Customer = ECE.Customers.Where(x => x.FirstName.ToLower() == dbCustomer.FirstName.ToLower() && x.LastName.ToLower() == dbCustomer.LastName.ToLower() && x.CustomerId != dbCustomer.CustomerId).FirstOrDefault();
            if (Customer == null) return false;
            else return true;

        }

        public static List<Customer> GetCustomerNotInTier(int TierId)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<Customer> Tier = ECE.Customers.Where(x => x.Company.TierId != TierId).ToList();
            return Tier;
        }
        public static List<Customer> GetAllSpecialCustomer()
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<Customer> Customer = ECE.Customers.Where(x => x.Company.IsSpecial == true).ToList();
            return Customer;
        }

        public static List<GetCustomerTierProductListPriceByCustomerId_Result> GetAllCustomerTierProductPriceByCustomerId(int id)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<GetCustomerTierProductListPriceByCustomerId_Result> TierProductPrice = ECE.GetCustomerTierProductListPriceByCustomerId(id).ToList();
            return TierProductPrice;
        }

    }
}
