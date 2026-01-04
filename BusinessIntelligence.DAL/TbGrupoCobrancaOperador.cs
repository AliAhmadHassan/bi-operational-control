using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoCobrancaOperador : Conexao
    {
        public void Cadastrar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbGrupoCobrancaOperador", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@OperadorId", grupocobranca.OperadorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDTbGrupoCobrancaOperador", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@OperadorId", grupocobranca.OperadorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUTbGrupoCobrancaOperador", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@OperadorId", grupocobranca.OperadorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbGrupoCobrancaOperador> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaOperador>.Lista("SPSTbGrupoCobrancaOperadorByGrupoCobrancaId", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaId", Value = id });
        }

        public List<DTO.TbGrupoCobrancaOperador> SelecionarPeloGrupoOperadorId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaOperador>.Lista("SPSTbGrupoCobrancaOperadorByOperadorId", ConnectionStringDW, new SqlParameter() { ParameterName = "@OperadorId", Value = id });
        }
    }
}
