using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.DTO
{
    [Serializable()]
    public class FactPausa: BITotalIP.DTO.FactPausa
    {
        public DateTime InicioPausa { get; set; }
        public TimeSpan Hora { get; set; }
        public bool EmPausaNoMomento { get; set; }
    }
}