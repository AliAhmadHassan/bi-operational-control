using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class TbGrupoUsuarioDiscador
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public int Ramal { get; set; }

        public int CobNetUsId { get; set; }

        public TimeSpan InicioExpediente { get; set; }

        public TimeSpan FimExpediente { get; set; }

        public int GrupoId { get; set; }

        public bool Obrigatorio { get; set; }

        public int Duracao { get; set; }

    }
}