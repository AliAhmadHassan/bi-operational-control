using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoCobrancaNotificacao : Conexao
    {
        public void Cadastrar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbGrupoCobrancaNotificacao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@UsuarioId", grupocobranca.UsuarioId);
                    cmd.Parameters.AddWithValue("@PodeEditar", grupocobranca.PodeEditar);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDTbGrupoCobrancaNotificacao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@UsuarioId", grupocobranca.UsuarioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUTbGrupoCobrancaNotificacao", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@UsuarioId", grupocobranca.UsuarioId);
                    cmd.Parameters.AddWithValue("@PodeEditar", grupocobranca.PodeEditar);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbGrupoCobrancaNotificacao> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaNotificacao>.Lista("SPSTbGrupoCobrancaNotificacaoByGrupoCobrancaId", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaId", Value = id });
        }

        public List<DTO.TbGrupoCobrancaNotificacao> SelecionarPeloGrupoUsuarioId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaNotificacao>.Lista("SPSTbGrupoCobrancaNotificacaoByUsuarioId", ConnectionStringDW, new SqlParameter() { ParameterName = "@UsuarioId", Value = id });
        }
    }
}