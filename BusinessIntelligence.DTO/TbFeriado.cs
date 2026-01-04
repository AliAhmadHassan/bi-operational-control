using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class TbFeriado
    {
        public int FeriadoID { get; set; }

        public string Descricao { get; set; }

        public DateTime? Data { get; set; }

        public bool Ativo { get; set; }

    }
}
