using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BITotalIP.DAL
{
    public class Conexao
    {
        private string ConnectionStringCore = "Data Source=192.168.0.5\\mssqlserver2008;Initial Catalog=DiscadorDW;Persist Security Info=True;User ID=sa;Password=Admin357/";
        private string ConnectionStringTeste = "Data Source=192.168.21.94;Initial Catalog=TotalIP;Persist Security Info=True;User ID=sa;Password=Admin357/";
        private string ConnectionStringPostGreFinal4 = String.Format("Server={0};Port={1};" +
                    "User Id={2};Database={3};",
                    "172.16.20.4",                  //"Host", 
                    "5432",                         //"Porta", 
                    "integracao",                   //"Usuario", 
                    "totalipdb");                   //"DataBaseName"

        protected string strConn(DTO.Base.TipoConexao tipoConexao)
        {
            string ConnectionString = string.Empty;

            switch (tipoConexao)
            {
                case DTO.Base.TipoConexao.Core:
                    ConnectionString = ConnectionStringCore;
                    break;
                case DTO.Base.TipoConexao.Teste:
                    ConnectionString = ConnectionStringTeste;
                    break;
                case DTO.Base.TipoConexao.PostGreFinal4:
                    ConnectionString = ConnectionStringPostGreFinal4;
                    break;
            }
            return ConnectionString;
        }

    }
}
