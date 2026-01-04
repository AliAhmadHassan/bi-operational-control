using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DiscadorUsuariosPausas
    {
        public int UsuarioId { get; set; }

        public string Status { get; set; }

        public string Nome { get; set; }

        public string Ramal { get; set; }

        public TimeSpan PausasObrigatorias { get; set; }

        public TimeSpan DemaisPausas { get; set; }

    }
}
