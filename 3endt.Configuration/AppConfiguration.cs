using _3endt.Configuration.ConfigModel;
using _3endt.Configuration.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3endt.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration(IConfiguration configuration)
        {
            ConnectionString = new ConnectionStrings()
            {
                DefaultDbConnection = configuration.GetConnectionString("3endtDB")
            };
        }
        public ConnectionStrings ConnectionString { get; set; }
    }
}
