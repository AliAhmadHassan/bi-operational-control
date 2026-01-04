using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class CarteiraSituacao : Base
    {
        [AtributoBind(true, 0)]
        public string Situacao { get; set; }

        [AtributoBind("Fact Carteira Count")]
        public int QtdContratos { get; set; }

        [AtributoBind("Devedor Id Count")]
        public int QtdClientes { get; set; }

        [AtributoBind("Saldo Contrato")]
        public double SaldoContrato { get; set; }

        [AtributoBind("Eficiencia")]
        public double Eficiencia { get; set; }
    }
}
