using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class Conexao
    {
        protected static string ConnectionStringCubo = ConfigurationManager.ConnectionStrings["ConnectionStringCubo"].ConnectionString;
        protected static string ConnectionStringDiscadorCubo = ConfigurationManager.ConnectionStrings["ConnectionStringDiscadorCubo"].ConnectionString;

        protected static string ConnectionStringDW = ConfigurationManager.ConnectionStrings["ConnectionStringDW"].ConnectionString;
        protected static string DiscadorDW = ConfigurationManager.ConnectionStrings["DiscadorDW"].ConnectionString;
    }
}
