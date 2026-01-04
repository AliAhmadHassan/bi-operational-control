using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL.Discador.TotalIP
{
    public class Usuarios : Conexao
    {
        public List<DTO.Discador.TotalIP.Usuarios> getByArrayIdGrupos(List<int> ids)
        {
            return AuxConsultasPostgre<DTO.Discador.TotalIP.Usuarios>.Lista(@"
SELECT distinct usuarios.*
FROM grupos_de_atendimento_usuarios
	inner join usuarios on usuarios.Id = grupos_de_atendimento_usuarios.usuario_id
where grupo_de_atendimento_id in ("+ Auxiliar.retornaConcatenado(ids) + ")"
, this.strConn(DTO.Base.TipoConexao.PostGreFinal4), System.Data.CommandType.Text, null);
        }


    }
}
