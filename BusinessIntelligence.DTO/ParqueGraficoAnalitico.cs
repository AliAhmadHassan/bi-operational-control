using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class ParqueGraficoAnalitico
    {
        public int ParqueGraficoId { get; set; }

        public long NossoNumero { get; set; }

        public int Atraso { get; set; }

        public decimal Saldo { get; set; }

        public DateTime Vencimento { get; set; }

        public DateTime Prorrogacao { get; set; }

        public int Opcao1Qtd { get; set; }

        public decimal Opcao1Valor { get; set; }

        public int Opcao2Qtd { get; set; }

        public decimal Opcao2Valor { get; set; }

        public int Opcao3Qtd { get; set; }

        public decimal Opcao3Valor { get; set; }

        public int Opcao4Qtd { get; set; }

        public decimal Opcao4Valor { get; set; }

        public int Opcao5Qtd { get; set; }

        public decimal Opcao5Valor { get; set; }

        public string TipoEndereco { get; set; }

        public string  TratadoPor { get; set; }

        public string Regra { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime? Pagamento { get; set; }

        public decimal ValorPago { get; set; }

        public int QtdBoletosImpressos { get; set; }

        public string UF { get; set; }

        public int Cep { get; set; }

    }
}
