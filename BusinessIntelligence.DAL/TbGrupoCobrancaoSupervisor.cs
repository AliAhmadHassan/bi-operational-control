using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class TbGrupoCobrancaSupervisor : Conexao
    {
        public void Cadastrar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPITbGrupoCobrancaSupervisor", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@SupervisorId", grupocobranca.SupervisorId);
                    cmd.Parameters.AddWithValue("@Email", grupocobranca.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDTbGrupoCobrancaSupervisor", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@SupervisorId", grupocobranca.SupervisorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUTbGrupoCobrancaSupervisor", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GrupoCobrancaId", grupocobranca.GrupoCobrancaId);
                    cmd.Parameters.AddWithValue("@SupervisorId", grupocobranca.SupervisorId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbGrupoCobrancaSupervisor> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaSupervisor>.Lista("SPSTbGrupoCobrancaSupervisorByGrupoCobrancaId", ConnectionStringDW, new SqlParameter() { ParameterName = "@GrupoCobrancaId", Value = id });
        }

        public List<DTO.TbGrupoCobrancaSupervisor> SelecionarPeloGrupoSupervisorId(int id)
        {
            return AuxConsultas<DTO.TbGrupoCobrancaSupervisor>.Lista("SPSTbGrupoCobrancaSupervisorByGrupoSupervisorId", ConnectionStringDW, new SqlParameter() { ParameterName = "@SupervisorId", Value = id });
        }
    }
}