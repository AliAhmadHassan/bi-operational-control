using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class TbHistoricoFeedback
    {
        public int HistoricoFeedbackId { get; set; }

        public int FeedbackId { get; set; }

        public DateTime DataHora { get; set; }

        public int IdSupervisor { get; set; }

        public int UsuarioId { get; set; }

        public int GrupoId { get; set; }

        public int CampanhaId { get; set; }

        public string Observacao { get; set; }
    }
}
