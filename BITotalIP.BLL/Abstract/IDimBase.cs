using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IDimBase:IBase<DTO.DimBase>
    {
		List<DTO.DimBase> SelectByMaillingId(int MaillingId);
    }
}