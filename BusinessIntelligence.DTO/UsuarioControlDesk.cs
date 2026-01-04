using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class UsuarioControlDesk
    {
        public int UsID { get; set; }

        public string NomeOperador { get; set; }

        public int IdPausa { get; set; }

        public string DescricaoPausa { get; set; }

        public int TotalPausaObrigatoria { get; set; }

        public int TotalOutrasPausas { get; set; }

        public int IdStatusUsuario { get; set; }

        public string StatusUsuario { get; set; }

        public int IdGrupo { get; set; }

        public string NomeGrupo { get; set; }

        public int IdCampanha { get; set; }

        public string NomeCampanha { get; set; }

    }
}
