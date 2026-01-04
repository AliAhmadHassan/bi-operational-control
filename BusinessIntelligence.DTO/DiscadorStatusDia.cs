using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DiscadorStatusDia : Base
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Ramal { get; set; }

        public int GrupooId { get; set; }

        public string Descricao { get; set; }

        public bool Obrigatorio { get; set; }

        public int HoraId { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan idHora { get; set; }

        public int Duracao { get; set; }

    }
}
