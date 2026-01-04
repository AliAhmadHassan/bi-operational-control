using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimUsuario : Base<DTO.DimUsuario>
    {
        public List<DTO.DimUsuario> SelectByGrupoId(int GrupoId)
        {
            return AuxConsultas<DTO.DimUsuario>.Lista("SPSDimUsuarioByGrupoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@GrupoId", GrupoId));
        }

        public DTO.DimUsuario SelectByCobnetId(int Id)
        {
            return AuxConsultas<DTO.DimUsuario>.Entidade("SPSDimUsuarioByCobnetId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CobNetUsId", Id));
        }
    }
}
