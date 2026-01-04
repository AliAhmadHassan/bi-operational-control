using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimBase:Base<DTO.DimBase>
    {
        public List<DTO.DimBase> SelectByMaillingId(int MaillingId)
        {
            return AuxConsultas<DTO.DimBase>.Lista("SPSDimBaseByMaillingId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@MaillingId", MaillingId));
        }
    }
}
