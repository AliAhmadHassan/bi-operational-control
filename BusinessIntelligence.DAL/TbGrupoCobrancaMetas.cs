using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoCobrancaMetas : Conexao
    {
        public void Cadastrar(DTO.TbGrupoCobrancaMeta grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbGrupoCobrancaMeta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@Descricao", grupocobranca.Descricao);
                    cmd.Parameters.AddWithValue("@Cash", grupocobranca.Cash);
                    cmd.Parameters.AddWithValue("@Refin", grupocobranca.Refin);
                    cmd.Parameters.AddWithValue("@CashCorrecao", grupocobranca.CashCorrecao);
                    cmd.Parameters.AddWithValue("@RefinCorrecao", grupocobranca.RefinCorrecao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDTbGrupoCobrancaMeta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaMetaId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbGrupoCobrancaMeta grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUTbGrupoCobrancaMeta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@Descricao", grupocobranca.Descricao);
                    cmd.Parameters.AddWithValue("@Cash", grupocobranca.Cash);
                    cmd.Parameters.AddWithValue("@Refin", grupocobranca.Refin);
                    cmd.Parameters.AddWithValue("@CashCorrecao", grupocobranca.CashCorrecao);
                    cmd.Parameters.AddWithValue("@RefinCorrecao", grupocobranca.RefinCorrecao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMetaPeloId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaMeta>.Lista("SPSTbGrupoCobrancaMetaByGrupoCobrancaMetaId", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaMetaId", Value = id });
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMetaPeloGrupoId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaMeta>.Lista("SPSTbGrupoCobrancaMetaPeloGrupo", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaId", Value = id });
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMeta()
        {
            return AuxConsultas<DTO.TbGrupoCobrancaMeta>.Lista("SPSTbGrupoCobrancaMeta", ConnectionStringDW, null);
        }
    }
}