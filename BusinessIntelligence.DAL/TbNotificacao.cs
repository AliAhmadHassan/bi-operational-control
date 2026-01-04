using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbNotificacao : Conexao
    {
        public void Cadastrar(DTO.TbNotificacao notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPINotificacao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DataHora", notificacao.DataHora);
                    cmd.Parameters.AddWithValue("@NotificacaoTipoId", notificacao.NotificacaoTipoId);
                    cmd.Parameters.AddWithValue("@Pendente", notificacao.Pendente);
                    cmd.Parameters.AddWithValue("@SupervisorId", notificacao.SupervisorId);
                    cmd.Parameters.AddWithValue("@UsuarioId", notificacao.UsuarioId);
                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", notificacao.GrupoCobrancaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CadastrarNotificacaoHistorico(int usuario_id, int notificacao_id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbNotificacaoHistorico", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UsuarioId", usuario_id);
                    cmd.Parameters.AddWithValue("@NotificacaoId", notificacao_id);
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUNotificacaoPendenteFinalizar", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NotificacaoId", notificacao_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbNotificacao notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUNotificacao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DataHora", notificacao.DataHora);
                    cmd.Parameters.AddWithValue("@MotivoId", notificacao.MotivoId);
                    cmd.Parameters.AddWithValue("@NotificacaoId", notificacao.NotificacaoId);
                    cmd.Parameters.AddWithValue("@NotificacaoTipoId", notificacao.NotificacaoTipoId);
                    cmd.Parameters.AddWithValue("@Observacao", notificacao.Observacao);
                    cmd.Parameters.AddWithValue("@Pendente", notificacao.Pendente);
                    cmd.Parameters.AddWithValue("@SupervisorId", notificacao.SupervisorId);
                    cmd.Parameters.AddWithValue("@UsuarioId", notificacao.UsuarioId);
                    cmd.Parameters.AddWithValue("@DataHoraMotivo", notificacao.DataHoraMotivo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DTO.TbNotificacao SelecionarPeloId(int id)
        {
            return AuxConsultas<DTO.TbNotificacao>.Entidade("SPSNotificacaoPeloId", ConnectionStringDW, new SqlParameter() { ParameterName = "@Id", Value = id });
        }

        public List<DTO.TbNotificacao> Listar()
        {
            return AuxConsultas<DTO.TbNotificacao>.Lista("SPSNotificacao", ConnectionStringDW, null);
        }

        public List<DTO.TbNotificacao> ListarPendentes(int us_id)
        {
            return AuxConsultas<DTO.TbNotificacao>.Lista("SPSNotificacaoPendente", ConnectionStringDW, new SqlParameter() { ParameterName = "@UsuarioId", Value = us_id });
        }
    }
}
