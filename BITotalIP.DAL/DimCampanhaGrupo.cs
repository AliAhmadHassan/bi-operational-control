using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DAL
{
    public class DimCampanhaGrupo:Base<DTO.DimCampanhaGrupo>
    {
        public List<DTO.DimCampanhaGrupo> SelectByCampanhaId(int CampanhaId)
        {
            return AuxConsultas<DTO.DimCampanhaGrupo>.Lista("SPSDimCampanhaGrupoByCampanhaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CampanhaId", CampanhaId));
        }
        public List<DTO.DimCampanhaGrupo> SelectByGrupoId(int GrupoId)
        {
            return AuxConsultas<DTO.DimCampanhaGrupo>.Lista("SPSDimCampanhaGrupoByGrupoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@GrupoId", GrupoId));
        }
    }
}
