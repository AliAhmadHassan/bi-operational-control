using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class DimStatusCobranca : Conexao
    {
        public DTO.DimStatusCobranca ListarPelaDescricao(string descricao)
        {
            return AuxConsultas<DTO.DimStatusCobranca>.Entidade(
                "SPSIdStatusCobrancaPelaDescricao",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter { ParameterName = "@Descricao", Value = descricao } });
        }
    }
}
