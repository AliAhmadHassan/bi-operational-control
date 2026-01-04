using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class TbNotificacaoTipo
    {
        public int NotificacaoTipoId { get; set; }

        public string Descricao { get; set; }

        public byte[] Icone { get; set; }
    }


}