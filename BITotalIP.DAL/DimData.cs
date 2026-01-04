using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimData:Base<DTO.DimData>
    {
        public DTO.DimData SelectByData(DateTime Data)
        {
            return AuxConsultas<DTO.DimData>.Entidade("SPSDimDataByData", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@Data", System.Data.SqlDbType.Date)
            {
                Value = Data
            });
        }
    }
}
