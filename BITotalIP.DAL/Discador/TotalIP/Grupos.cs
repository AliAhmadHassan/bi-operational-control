using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL.Discador.TotalIP
{
    public class Grupos:Conexao
    {
        public List<DTO.Discador.TotalIP.Grupos> getByArrayIdGrupos(List<int> ids)
        {
            return AuxConsultasPostgre<DTO.Discador.TotalIP.Grupos>.Lista(@"
SELECT distinct *
FROM grupos_de_atendimento
where Id in (" + Auxiliar.retornaConcatenado(ids) + ")"
, this.strConn(DTO.Base.TipoConexao.PostGreFinal4), System.Data.CommandType.Text, null);
        }
    }
}
