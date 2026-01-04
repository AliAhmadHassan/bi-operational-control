using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimMaillingFiltros:Base<DTO.DimMaillingFiltros>
    {
        public List<DTO.DimMaillingFiltros> SelectByMaillingId(int MaillingId)
        {
            return AuxConsultas<DTO.DimMaillingFiltros>.Lista("SPSDimMaillingFiltrosByMaillingId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@MaillingId", MaillingId));
        }
        public List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosTabelaId(int MaillingFiltrosTabelaId)
        {
            return AuxConsultas<DTO.DimMaillingFiltros>.Lista("SPSDimMaillingFiltrosByMaillingFiltrosTabelaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@MaillingFiltrosTabelaId", MaillingFiltrosTabelaId));
        }
        public List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosCampoId(int MaillingFiltrosCampoId)
        {
            return AuxConsultas<DTO.DimMaillingFiltros>.Lista("SPSDimMaillingFiltrosByMaillingFiltrosCampoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@MaillingFiltrosCampoId", MaillingFiltrosCampoId));
        }
    }
}
