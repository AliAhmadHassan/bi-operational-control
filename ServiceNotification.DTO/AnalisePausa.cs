using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.DTO
{
    [Serializable()]
    public class AnalisePausa : FactPausa
    {
        public DateTime LimitePausa { get; set; }

        public TimeSpan TotalPausa { get; set; }
    }

    [Serializable()]
    public class AnalisePausaModel
    {
        public Int64 PausaId { get; set; }

        public int UsuarioId { get; set; }

        public int UsuarioStatusId { get; set; }

        public int DataId { get; set; }

        public int HoraId { get; set; }

        public int Duracao { get; set; }

        public DateTime InicioPausa { get; set; }

        public TimeSpan Hora { get; set; }

        public bool EmPausaNoMomento { get; set; }

        public DateTime LimitePausa { get; set; }

        public TimeSpan TotalPausa { get; set; }
    }

    [Serializable()]
    public class AnalisarPausas : List<AnalisePausaModel>
    {

    }
}
