using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class CarteiraAnaliticoVencimento
    {
        public int AcordoID { get; set; }

        public string Credor { get; set; }

        public string Segmento { get; set; }

        public string Produto { get; set; }

        public Int64 Devedor { get; set; }

        public string Operador { get; set; }

        public decimal ValorAcordo { get; set; }

        public decimal ValorParcela { get; set; }

        public int Plano { get; set; }

        public DateTime Vencimento { get; set; }

        public DateTime? Pagamento { get; set; }

    }
}
    