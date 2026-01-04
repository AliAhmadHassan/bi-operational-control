using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class CarteiraAnaliticoSituacao
    {
        public string Contrato { get; set; }

        public Int64 CPF_CNPJ { get; set; }

        public string Status { get; set; }

        public string Produto { get; set; }

        public string Segmento { get; set; }

        public string Credor { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime Conciliacao { get; set; }
    }
}
