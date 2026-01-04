using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class OperacaoAnaliticoAcordo
    {
        public int AcordoID { get; set; }

        public string Credor { get; set; }

        public string Segmento { get; set; }

        public string Produto { get; set; }

        public long Devedor { get; set; }

        public string Usuario { get; set; }

        public DateTime Cadastro { get; set; }

        public int Plano { get; set; }

        public Decimal ValorParcela { get; set; }

        public Decimal ValorAcordo { get; set; }

        public Decimal VlPago { get; set; }

        public DateTime? Cancelamento { get; set; }

        public DateTime Vencimento { get; set; }

        public DateTime? Pagamento { get; set; }
    }
}
