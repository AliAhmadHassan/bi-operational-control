using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.DTO
{
    public class DimUsuarioStatus : BITotalIP.DTO.DimUsuarioStatus
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
    }
}
