using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class ParqueGraficoPesquisaEletronica : Base
    {
        [AtributoBind(true, 0)]
        public string EmpresaTratamento { get; set; }

        [AtributoBind("Quantidade Boletos")]
        public int QtdBoletos { get; set; }

        [AtributoBind("Quantidade Pagamentos")]
        public int QtdPagamentos { get; set; }

        [AtributoBind("Valor Pago")]
        public double ValorPago { get; set; }

        [AtributoBind("Eficiencia")]
        public double Eficiencia { get; set; }
    }
}

