using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.Mailling.DAL
{
    public class Lote: BITotalIP.DAL.Base<BITotalIP.Mailling.DTO.Lote>
    {
        override
        public Mailling.DTO.Lote SelectById(int Id)
        {
            return BITotalIP.DAL.AuxConsultas<Mailling.DTO.Lote>.Entidade("SPSLoteById", strConn(DTO.Base.TipoConexao.Teste), new SqlParameter("@Id", Id));
        }
    }
}
