using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace BITotalIP.DAL.Discador.TotalIP
{
    public class Campanhas : Conexao
    {
        public List<DTO.Discador.TotalIP.Campanhas> getByArrayIds(List<int> ids)
        {
            return AuxConsultasPostgre<DTO.Discador.TotalIP.Campanhas>.Lista(@"
Select *
from campanhas
where id in ("+ Auxiliar.retornaConcatenado(ids) + @")
", this.strConn(DTO.Base.TipoConexao.PostGreFinal4), System.Data.CommandType.Text, null);
        }

        
    }
}
