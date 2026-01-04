using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbNotificacaoMotivo : Conexao
    {
        public void Cadastrar(DTO.TbNotificacaoMotivo motivo_notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPINotificacaoMotivo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Descricao", motivo_notificacao.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbNotificacaoMotivo motivo_notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUNotificacaoTipo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Descricao", motivo_notificacao.Descricao);
                    cmd.Parameters.AddWithValue("@MotivoId", motivo_notificacao.MotivoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DTO.TbNotificacaoMotivo SelecionarPeloId(int id)
        {
            return AuxConsultas<DTO.TbNotificacaoMotivo>.Entidade("SPSNotificacaoMotivoPeloId", ConnectionStringDW, new SqlParameter() { ParameterName = "@Id", Value = id });
        }

        public List<DTO.TbNotificacaoMotivo> Listar()
        {
            return AuxConsultas<DTO.TbNotificacaoMotivo>.Lista("SPSNotificacaoMotivo", ConnectionStringDW, null);
        }

        public void Deletar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDNotificacaoMotivo", conn))
                {
                    cmd.Parameters.AddWithValue("@MotivoId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}