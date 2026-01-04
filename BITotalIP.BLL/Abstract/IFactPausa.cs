using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IFactPausa:IBase<DTO.FactPausa>
    {
		List<DTO.FactPausa> SelectByUsuarioId(int UsuarioId);
		List<DTO.FactPausa> SelectByUsuarioStatusId(int UsuarioStatusId);
		List<DTO.FactPausa> SelectByDataId(int DataId);
		List<DTO.FactPausa> SelectByHoraId(int HoraId);
    }
}