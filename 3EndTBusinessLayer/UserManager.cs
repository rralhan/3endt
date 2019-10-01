using System;
using System.Collections.Generic;
using System.Linq;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;

namespace _3EndTBusinessLayer
{
    public class UserManager
    {
        public static bool InsertUser(User user)
        {
            var retval = SQLHelper.InsertUser(user);
            if (retval > 0)
                return true;
            return false;
        }

        public static List<User> GetAllCustomers(bool showActiveOnly = true)
        {
            var users = SQLHelper.GetUsers();
            if (showActiveOnly)
                users = users.Where(x => x.IsActive == true).ToList();
            users = users.Where(c => c.RoleId != (int)Enums.UserRole.Administrator).ToList<User>();
            return users;
        }

        public static bool UpdateCustomer(User user)
        {
            var retval = SQLHelper.UpdateUser(user);
            if (retval > 0)
                return true;
            return false;
        }

        public static Boolean CheckIfUserNameAlreadyExist(User user)
        {
            var users = SQLHelper.GetUsers();
            var dbusers = users.Where(x => x.UserName.ToLower().Equals(user.UserName.ToLower())).FirstOrDefault<User>();
            if (dbusers == null)
                return false;
            return true;
        }

        public static bool IsPasswordExist(string Password)
        {
            var users = SQLHelper.GetUsers();
            User user = users.Where(x => x.Password == Password).FirstOrDefault();
            if (user == null)
                return false;
            return true;
        }

        public static User ValidateUser(string UserName, string Password)
        {
            var users = SQLHelper.GetUsers();
            var user = users.Where(x => x.UserName == UserName && x.Password == Password && x.IsActive == true).FirstOrDefault();
            return user;
        }

        //public static List<Customer> GetUserDetails()
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    List<Customer> AllCategory = ECE.Customers.ToList();
        //    return AllCategory;
        //}

    }
}
