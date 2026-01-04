using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IDimMaillingFiltros:IBase<DTO.DimMaillingFiltros>
    {
		List<DTO.DimMaillingFiltros> SelectByMaillingId(int MaillingId);
		List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosTabelaId(int MaillingFiltrosTabelaId);
		List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosCampoId(int MaillingFiltrosCampoId);
    }
}