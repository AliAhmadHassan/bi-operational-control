using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessIntelligence.DAL
{
    public class TbMeta : Conexao
    {
        public void Incluir(DTO.TbMeta meta)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPIMetaOperadores", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Meta1", meta.Meta1);
                    cmd.Parameters.AddWithValue("@Meta2", meta.Meta2);
                    cmd.Parameters.AddWithValue("@Meta3", meta.Meta3);
                    cmd.Parameters.AddWithValue("@Meta4", meta.Meta4);
                    cmd.Parameters.AddWithValue("@Meta5", meta.Meta5);
                    cmd.Parameters.AddWithValue("@MetaRefin1", meta.MetaRefin1);
                    cmd.Parameters.AddWithValue("@MetaRefin2", meta.MetaRefin2);
                    cmd.Parameters.AddWithValue("@MetaRefin3", meta.MetaRefin3);
                    cmd.Parameters.AddWithValue("@MetaRefin4", meta.MetaRefin4);
                    cmd.Parameters.AddWithValue("@MetaRefin5", meta.MetaRefin5);
                    cmd.Parameters.AddWithValue("@UsuarioID", meta.UsuarioID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(DTO.TbMeta meta)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPUMetaOperadores", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Meta1", meta.Meta1);
                    cmd.Parameters.AddWithValue("@Meta2", meta.Meta2);
                    cmd.Parameters.AddWithValue("@Meta3", meta.Meta3);
                    cmd.Parameters.AddWithValue("@Meta4", meta.Meta4);
                    cmd.Parameters.AddWithValue("@Meta5", meta.Meta5);
                    cmd.Parameters.AddWithValue("@MetaRefin1", meta.MetaRefin1);
                    cmd.Parameters.AddWithValue("@MetaRefin2", meta.MetaRefin2);
                    cmd.Parameters.AddWithValue("@MetaRefin3", meta.MetaRefin3);
                    cmd.Parameters.AddWithValue("@MetaRefin4", meta.MetaRefin4);
                    cmd.Parameters.AddWithValue("@MetaRefin5", meta.MetaRefin5);
                    cmd.Parameters.AddWithValue("@UsuarioID", meta.UsuarioID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int usuario_id)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.ConnectionStringDW))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SPDMetaOperadores", conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", usuario_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DTO.TbMeta> Listar(string operadores)
        {
            return AuxConsultas<DTO.TbMeta>.Lista("SPSMetaOperadores", ConnectionStringDW, new SqlParameter() { ParameterName = "@Operadores", Value = operadores });
        }
    }
}