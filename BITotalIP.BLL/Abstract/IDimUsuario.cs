using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IDimUsuario:IBase<DTO.DimUsuario>
    {
		List<DTO.DimUsuario> SelectByGrupoId(int GrupoId);
        void ImportaTotalIP();
    }
}