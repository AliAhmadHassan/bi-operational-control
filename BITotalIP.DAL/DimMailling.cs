using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimMailling:Base<DTO.DimMailling>
    {
        public void InativaMaillingAnteriores(List<int> CampanhaIds)
        {
            using (SqlConnection Conn = new SqlConnection(strConn(DTO.Base.TipoConexao.Core)))
            {
                using (SqlCommand cmd = new SqlCommand("SPUDimMaillingInativaMailling", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@CampanhaIds", System.Data.SqlDbType.VarChar, -1)
                        {
                            Value = Auxiliar.retornaConcatenado(CampanhaIds)
                        });
                        Conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}
