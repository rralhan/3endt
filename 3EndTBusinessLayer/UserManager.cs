using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3EndTDataLayer;

namespace _3EndTBusinessLayer
{
    public class UserManager
    {
        public static void GetUsers()
        {

        }
        public static Boolean CheckIfUserNameAlreadyExist(Customer dbuser)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            Customer dbusers = ECE.Customers.Where(x => x.UserName.ToLower().Equals(dbuser.UserName.ToLower())).FirstOrDefault<Customer>();
            if (dbusers == null) return false;
            else return true;
        }

        public static bool IsPasswordExist(string Password)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            Customer user = ECE.Customers.Where(x => x.Password == Password).FirstOrDefault();
            if (user == null)
                return false;

            return true;
        }
        public static Customer ValidateUser(string UserName, string Password)
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            Customer user = new Customer();
            user = ECE.Customers.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
            return user;
        }

        public static List<Customer> GetUserDetails()
        {
            EndtCommerceEntities ECE = new EndtCommerceEntities();
            List<Customer> AllCategory = ECE.Customers.ToList();
            return AllCategory;
        }

    }
}
