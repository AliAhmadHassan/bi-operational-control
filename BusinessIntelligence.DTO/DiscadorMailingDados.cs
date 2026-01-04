using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DiscadorMailingDados
    {
        public int MaillingId { get; set; }

        public string MailingDescricao { get; set; }

        public int CampanhaId { get; set; }

        public string NomeCampanha { get; set; }

        public int QtdAlo { get; set; }

        public int QtdLocalizado { get; set; }

        public int QtdCpc { get; set; }

        public int Total { get; set; }

    }
}
