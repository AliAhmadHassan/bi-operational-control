using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL.Discador.TotalIP
{
    public class ResultadoDiscador:Conexao
    {
        public List<DTO.Discador.TotalIP.ResultadoDiscador> getByGreaterThan(List<int> CampanhaIds, Int64 id)
        {
            return AuxConsultasPostgre<DTO.Discador.TotalIP.ResultadoDiscador>.Lista(@"
SELECT *
FROM resultado_discador
where Id > " + id + @"
    and id_Campanha in ("+ Auxiliar.retornaConcatenado(CampanhaIds) + @")
order by Id"

, this.strConn(DTO.Base.TipoConexao.PostGreFinal4), System.Data.CommandType.Text, null);
        }
    }
}
