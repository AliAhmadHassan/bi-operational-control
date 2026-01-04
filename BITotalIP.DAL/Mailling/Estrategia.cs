using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.Mailling.DAL
{
    public class Estrategia: BITotalIP.DAL.Base<BITotalIP.Mailling.DTO.Estrategia>
    {
        override
        public Mailling.DTO.Estrategia SelectById(int Id)
        {
            return BITotalIP.DAL.AuxConsultas<Mailling.DTO.Estrategia>.Entidade("SPSEstrategiaById", strConn(DTO.Base.TipoConexao.Teste), new SqlParameter("@Id", Id));
        }

        public List<Mailling.DTO.Estrategia> SelectByIdLote(int IdLote)
        {
            return BITotalIP.DAL.AuxConsultas<Mailling.DTO.Estrategia>.Lista("SPSEstrategiaByIdLote", strConn(DTO.Base.TipoConexao.Teste), new SqlParameter("@IdLote", IdLote));
        }
    }
}
