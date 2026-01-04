using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessIntelligence.DAL
{
    public class TbFeriado : Conexao
    {
        public void Incluir(DTO.TbFeriado feriado)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPIFeriado", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Data", feriado.Data);
                    cmd.Parameters.AddWithValue("Descricao", feriado.Descricao);
                    cmd.Parameters.AddWithValue("Ativo", feriado.Ativo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbFeriado feriado)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUFeriado", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Data", feriado.Data);
                    cmd.Parameters.AddWithValue("@Descricao", feriado.Descricao);
                    cmd.Parameters.AddWithValue("@Ativo", feriado.Ativo);
                    cmd.Parameters.AddWithValue("@FeriadoID", feriado.FeriadoID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int feriado_id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDFeriado", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeriadoID", feriado_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbFeriado> Listar()
        {
            return AuxConsultas<DTO.TbFeriado>.Lista("SPSListarFeriados", ConnectionStringDW, null);
        }

        public DTO.TbFeriado ListarPeloId(int feriado_id)
        {
            return AuxConsultas<DTO.TbFeriado>.Entidade("SPSListarFeriadosPeloId", ConnectionStringDW, new SqlParameter() {ParameterName = "@FeriadoID", Value = feriado_id });
        }
    }
}
