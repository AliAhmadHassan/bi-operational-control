using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DimOcorrencia
    {
        public int OcorrenciaID { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public bool ConsideraAcionamento { get; set; }

        public bool ClienteLocalizado { get; set; }

        public bool ContatoPositivo { get; set; }

        public int CredorID { get; set; }

    }
}
