using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DTO.Discador.TotalIP
{
    public class ResultadoDiscador
    {
        public int id { get; set; }
        public int id_campanha { get; set; }
        public string identificador1 { get; set; }
        public string identificador2 { get; set; }
        public string telefone { get; set; }
        public int id_status { get; set; }
        public string status { get; set; }
        public DateTime data { get; set; }
        public string codigo_ligacao { get; set; }
        public DateTime discar_em { get; set; }
        public DateTime discar_em_operador { get; set; }
    }
}
