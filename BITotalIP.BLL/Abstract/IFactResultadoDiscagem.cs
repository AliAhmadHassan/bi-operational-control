using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Abstract
{
    public interface IFactResultadoDiscagem:IBase<DTO.FactResultadoDiscagem>
    {
        Int64 selectMaxId();
    }
}