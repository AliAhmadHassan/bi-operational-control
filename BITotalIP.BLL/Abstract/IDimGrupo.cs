using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IDimGrupo:IBase<DTO.DimGrupo>
    {
		List<DTO.DimGrupo> SelectByCredorId(int CredorId);
    }
}