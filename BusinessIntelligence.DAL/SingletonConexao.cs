using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class SingletonConexao : Conexao
    {
        private SingletonConexao() { }

        private static AdomdConnection instance;

        public static AdomdConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdomdConnection(Conexao.ConnectionStringCubo);
                    instance.Open();
                }
                else
                {
                    if (instance.State == System.Data.ConnectionState.Closed || instance.State == System.Data.ConnectionState.Broken)
                    {
                        instance.Dispose();
                        instance = null;

                        instance = new AdomdConnection(Conexao.ConnectionStringCubo);
                        instance.Open();
                    }
                }

                return instance;
            }
        }
    }
}
