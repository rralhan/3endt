using _3endt.Configuration.ConfigModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3endt.Configuration.Interface
{
    public interface IAppConfiguration
    {
        ConnectionStrings ConnectionString { get; }
    }
}
