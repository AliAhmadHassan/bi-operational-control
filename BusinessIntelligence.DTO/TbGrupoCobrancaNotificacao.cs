using System;
using System.Collections.Generic;

namespace BusinessIntelligence.DTO
{
    public class TbGrupoCobrancaNotificacao
    {
		public int GrupoCobrancaId { get; set; }
		public int UsuarioId { get; set; }
        public bool PodeEditar { get; set; }
        public string Email { get; set; }

    }
}
