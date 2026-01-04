using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimGrupo:Base<DTO.DimGrupo>
    {
        public List<DTO.DimGrupo> SelectByCredorId(int CredorId)
        {
            return AuxConsultas<DTO.DimGrupo>.Lista("SPSDimGrupoByCredorId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CredorId", CredorId));
        }
    }
}
