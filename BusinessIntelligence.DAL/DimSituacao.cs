using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class DimSituacao : Conexao
    {
        public DTO.DimSituacao ListarPelaDescricao(string descricao)
        {
            return AuxConsultas<DTO.DimSituacao>.Entidade(
                "SPSIdSituacaoPelaDescricao",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter { ParameterName = "@Descricao", Value = descricao } });
        }


    }
}
