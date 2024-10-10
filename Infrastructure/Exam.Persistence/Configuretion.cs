using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistance
{
    static class Configuretion
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Exam.MVC"));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.json");

                    //configurationManager.AddJsonFile("appsettings.Production.json");
                }

                return configurationManager.GetConnectionString("SqlConnection");
            }
        }
    }
    //    public static string ConnectionString 
    //    { get
    //        {
    //            ConfigurationManager configurationManager = new();
    //            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/VillaBakuApi.Api"));
    //            configurationManager.AddJsonFile("appsettings.json");
    //            return configurationManager.GetConnectionString("PostgreSQL");
    //        } }


}
