using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbNotificacaoTipo : Conexao
    {
        public void Cadastrar(DTO.TbNotificacaoTipo tipo_notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPINotificacaoTipo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Descricao", tipo_notificacao.Descricao);
                    cmd.Parameters.AddWithValue("@Icone", tipo_notificacao.Icone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbNotificacaoTipo tipo_notificacao)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUNotificacaoTipo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NotificacaoTipoId", tipo_notificacao.NotificacaoTipoId);
                    cmd.Parameters.AddWithValue("@Descricao", tipo_notificacao.Descricao);
                    cmd.Parameters.AddWithValue("@Icone", tipo_notificacao.Icone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DTO.TbNotificacaoTipo SelecionarPeloId(int id)
        {
            return AuxConsultas<DTO.TbNotificacaoTipo>.Entidade("SPSNotificacaoTipoPeloId", ConnectionStringDW, new SqlParameter() { ParameterName = "@Id", Value = id });
        }

        public List<DTO.TbNotificacaoTipo> Listar()
        {
            return AuxConsultas<DTO.TbNotificacaoTipo>.Lista("SPSNotificacaoTipo", ConnectionStringDW, null);
        }

        public void Deletar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDNotificacaoTipo", conn))
                {
                    cmd.Parameters.AddWithValue("@NotificacaoTipoId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}