using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL.Discador.TotalIP
{
    public class Pausas : Conexao
    {
        public List<DTO.Discador.TotalIP.Pausas> getByUsuario(List<int> ids)
        {
             return AuxConsultasPostgre<DTO.Discador.TotalIP.Pausas>.Lista(@"
SELECT distinct *
FROM pausas
where id_usuario in (" + Auxiliar.retornaConcatenado(ids) + @")
    and data > current_date
order by data"
, this.strConn(DTO.Base.TipoConexao.PostGreFinal4), System.Data.CommandType.Text, null);
        }
    }
}
