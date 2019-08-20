using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3EndTBusinessLayer.BusinessObject
{

    public class Settings
    {
        /// <summary>
        /// Constant string "UploadPath" which is used in appSettings in web configuration file.
        /// </summary>
        private const string _UploadPath = "UploadPath";
        /// <summary>
        /// Returns a path of the folder where files are uploaded.
        /// </summary>
        public static string UploadPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[_UploadPath].ToString();
            }
        }

        /// <summary>
        /// constant string "EndtCommerceEntities" created in web configuration file as ConnectionString Name.
        /// </summary>
        private const string _ConnectionString = "EndtCommerceEntities";
        /// <summary>
        /// Returns a connection string named as "EndtCommerceEntities" in the web configuration file. 
        /// </summary>
        public static String ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[_ConnectionString].ToString();
            }
        }
    }
}
