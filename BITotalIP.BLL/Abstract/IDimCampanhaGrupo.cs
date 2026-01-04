using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IDimCampanhaGrupo:IBase<DTO.DimCampanhaGrupo>
    {
		List<DTO.DimCampanhaGrupo> SelectByCampanhaId(int CampanhaId);
		List<DTO.DimCampanhaGrupo> SelectByGrupoId(int GrupoId);
        void ImportaTotalIP();
    }
}