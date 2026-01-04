using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class TbNotificacao
    {
        public int NotificacaoId { get; set; }

        public int NotificacaoTipoId { get; set; }

        public DateTime DataHora { get; set; }

        public int UsuarioId { get; set; }

        public int SupervisorId { get; set; }

        public bool Pendente { get; set; }

        public int MotivoId { get; set; }

        public string Observacao { get; set; }

        public DateTime DataHoraMotivo { get; set; }

        public int GrupoCobrancaId { get; set; }

    }
}
