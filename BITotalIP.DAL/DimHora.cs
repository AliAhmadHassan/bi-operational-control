using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimHora:Base<DTO.DimHora>
    {
        public DTO.DimHora SelectByIdHora(DateTime hora)
        {
            return AuxConsultas<DTO.DimHora>.Entidade("SPSDimHoraByIdHora", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@idHora", System.Data.SqlDbType.DateTime)
            {
                Value = hora
            });
        }
    }
}
