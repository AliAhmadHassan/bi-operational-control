using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoUsuarioDiscador : Conexao
    {
        public List<DTO.TbGrupoUsuarioDiscador> GrupoOperadores(int ano, int mes, int dia)
        {
            return AuxConsultas<DTO.TbGrupoUsuarioDiscador>.Lista(
                "SPSGrupoOperadores",
                DiscadorDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                });
        }
    }
}
