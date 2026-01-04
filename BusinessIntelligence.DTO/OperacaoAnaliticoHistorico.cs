using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class OperacaoAnaliticoHistorico
    {
        public int HistId { get; set; }

        public string Contr_Contrato { get; set; }

        public string Ocorrencia { get; set; }

        public DateTime DataCadastro { get; set; }

        public TimeSpan HoraCadastro { get; set; }

        public bool Localizado { get; set; }

        public bool Acionamento { get; set; }

        public bool Positivo { get; set; }

    }
}
