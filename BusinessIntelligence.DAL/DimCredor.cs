using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class DimCredor : Conexao
    {
        public List<DTO.DimCredor> ListarCredores()
        {
            return AuxConsultas<DTO.DimCredor>.Lista("SPSCredor", ConnectionStringDW, null);
        }

        public List<DTO.DimCredor> ListarCredoresPeloGrupo(int grupo_id)
        {
            return AuxConsultas<DTO.DimCredor>.Lista(
                "SPSCredoresPeloGrupo", 
                ConnectionStringDW, 
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter { ParameterName = "@GrupoID", Value = grupo_id } });
        }

        public DTO.DimCredor ListarCredoresPeloID(int credor_id)
        {
            return AuxConsultas<DTO.DimCredor>.Entidade(
                "SPCreadorPeloID",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter { ParameterName = "@CredorID", Value = credor_id } });
        }
    }
}