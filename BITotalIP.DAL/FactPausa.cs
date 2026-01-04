using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class FactPausa:Base<DTO.FactPausa>
    {
        public List<DTO.FactPausa> SelectByUsuarioId(int UsuarioId)
        {
            return AuxConsultas<DTO.FactPausa>.Lista("SPSFactPausaByUsuarioId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@UsuarioId", UsuarioId));
        }
        public List<DTO.FactPausa> SelectByUsuarioStatusId(int UsuarioStatusId)
        {
            return AuxConsultas<DTO.FactPausa>.Lista("SPSFactPausaByUsuarioStatusId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@UsuarioStatusId", UsuarioStatusId));
        }
        public List<DTO.FactPausa> SelectByDataId(int DataId)
        {
            return AuxConsultas<DTO.FactPausa>.Lista("SPSFactPausaByDataId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@DataId", DataId));
        }
        public List<DTO.FactPausa> SelectByHoraId(int HoraId)
        {
            return AuxConsultas<DTO.FactPausa>.Lista("SPSFactPausaByHoraId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@HoraId", HoraId));
        }
    }
}
