using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DTO.Discador.TotalIP
{
    public class Pausas
    {
        public Int64 id_usuario { get; set; }
        public string ramal { get; set; }
        public int id_status { get; set; }
        public string status { get; set; }
        public DateTime data { get; set; }
        public int tempo { get; set; }
    }
}
