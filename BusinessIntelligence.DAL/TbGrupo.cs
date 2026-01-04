using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupo : Conexao
    {
        public List<DTO.TbGrupo> ListarGrupos()
        {
            return AuxConsultas<DTO.TbGrupo>.Lista("SPSGrupo", ConnectionStringDW, null);
        }

        public List<DTO.GrupoHierarquia> HierarquiaGrupos()
        {
            return AuxConsultas<DTO.GrupoHierarquia>.Lista("SPSGrupoHierarquia", ConnectionStringDW, null);
        }

        public DTO.TbGrupo ObterGrupo(int grupo_id)
        {
            return AuxConsultas<DTO.TbGrupo>.Entidade(
                "SPSGrupoPeloId", 
                ConnectionStringDW, 
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter { ParameterName = "@GrupoId", Value = grupo_id } });
        }
    }
}