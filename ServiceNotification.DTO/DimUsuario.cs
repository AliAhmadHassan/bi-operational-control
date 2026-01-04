using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.DTO
{
    [Serializable()]
    public class DimUsuario : BITotalIP.DTO.DimUsuario
    {
        public bool NotificadoAtraso { get; set; }
        public bool NotificadoAtrasoComLogin { get; set; }
        public bool NotificadoSaidaAntecipado { get; set; }
        public bool NotificadoFalta { get; set; }
        public bool NotificadoDeslogado { get; set; }
        public bool NotificadoPausasObrigatorias { get; set; }

        public TimeSpan InicioExpediente_Tolerancia { get; set; }
        public TimeSpan FimExpediente_Tolerancia { get; set; }

        public AnalisePausaModel AnalisePausaModel_Anterior { get; set; }
    }
}
