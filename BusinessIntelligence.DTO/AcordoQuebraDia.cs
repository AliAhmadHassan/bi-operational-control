using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class AcordoQuebraDia : Base
    {
        [AtributoBind(true, 0)]
        public string Operador { get; set; }

        [AtributoBind("Fact Acordo Count")]
        public int QtdAcordo { get; set; }

        [AtributoBind("Valor Acordo")]
        public double ValorAcordo { get; set; }

        [AtributoBind("Valor Parcela")]
        public double ValorParcela { get; set; }

        [AtributoBind("Vl Pago")]
        public double ValorPago { get; set; }
    }
}
