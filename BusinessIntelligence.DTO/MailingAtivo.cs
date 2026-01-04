using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class MailingAtivo
    {
        public int MaillingId { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public string Nome { get; set; }

        public int CampanhaId { get; set; }

        public string NomeCampanha { get; set; }

    }
}
