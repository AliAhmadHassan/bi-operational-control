using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.Mailling.DAL
{
    public class Base: BITotalIP.DAL.Base<BITotalIP.Mailling.DTO.Base>
    {
        override
        public Mailling.DTO.Base SelectById(int Id)
        {
            return BITotalIP.DAL.AuxConsultas<Mailling.DTO.Base>.Entidade("SPSBaseById", strConn(DTO.Base.TipoConexao.Teste), new SqlParameter("@Id", Id));
        }
        public List<Mailling.DTO.Base> SelectByIdLote(int IdLote)
        {
            return BITotalIP.DAL.AuxConsultas<Mailling.DTO.Base>.Lista("SPSBaseByIdLote", strConn(DTO.Base.TipoConexao.Teste), new SqlParameter("@IdLote", IdLote));
        }
    }
}
