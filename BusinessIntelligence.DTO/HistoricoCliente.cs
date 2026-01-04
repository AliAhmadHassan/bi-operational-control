using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class HistoricoCliente : Base
    {
        [AtributoBind(true, 0)]
        public int OperadorID { get; set; }

        [AtributoBind(true, 1)]
        public string NomeOperador { get; set; }

        [AtributoBind("Fact Historico Count")]
        public int QtdHistorico { get; set; }
    }

    public class HistoricoClienteAcionamentos : HistoricoCliente
    {
        public int TotalAcionamentos { get; set; }
    }

    public class HistoricoClienteAcionamentosAcordos : HistoricoClienteAcionamentos
    {
        public int TotalAcordos { get; set; }
    }
}
