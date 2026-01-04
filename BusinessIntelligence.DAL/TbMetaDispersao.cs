using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbMetaDispersao : Conexao
    {
        public void Incluir(DTO.TbMetaDispersao meta)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPIMetaDispersao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarteiraID", meta.CarteiraID);
                    cmd.Parameters.AddWithValue("@TotalClientes", meta.TotalClientes);
                    cmd.Parameters.AddWithValue("@TotalLocalizados", meta.TotalLocalizados);
                    cmd.Parameters.AddWithValue("@TotalContatos", meta.TotalContatos);
                    cmd.Parameters.AddWithValue("@TotalAcordos", meta.TotalAcordos);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbMetaDispersao> Listar(string carteiras)
        {
            return AuxConsultas<DTO.TbMetaDispersao>.Lista("SPSTbMetaDispersao", ConnectionStringDW, new SqlParameter() { ParameterName = "@CarteiraID", Value = carteiras });
        }
    }
}
