using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DimHora
    {
        public int HoraID { get; set; }
        public TimeSpan idHora { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
    }
}
