using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoCobranca : Conexao
    {
        public int Cadastrar(DTO.TbGrupoCobranca grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbGrupoCobranca", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ativo", grupocobranca.Ativo);
                    cmd.Parameters.AddWithValue("@Descricao", grupocobranca.Descricao);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDTbGrupoCobranca", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbGrupoCobranca grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUTbGrupoCobranca", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ativo", grupocobranca.Ativo);
                    cmd.Parameters.AddWithValue("@Descricao", grupocobranca.Descricao);
                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DTO.TbGrupoCobranca SelecionarPeloId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobranca>.Entidade("SPSTbGrupoCobrancaByGrupoCobrancaId", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaId ", Value = id });
        }

        public List<DTO.TbGrupoCobranca> Listar()
        {
            return AuxConsultas<DTO.TbGrupoCobranca>.Lista("SPSTbGrupoCobranca", ConnectionStringDW, null);
        }
    }
}
