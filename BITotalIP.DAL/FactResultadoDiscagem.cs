using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class FactResultadoDiscagem:Base<DTO.FactResultadoDiscagem>
    {
        public Int64 selectMaxId()
        {
            return AuxConsultas<Int64>.Scalar("SPSFactResultadoDiscagemMaxId", this.strConn(DTO.Base.TipoConexao.Core), null);
        }
    }
}
