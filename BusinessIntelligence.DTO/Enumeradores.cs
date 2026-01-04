using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{

    public enum EnumTbNotificacaoTipo
    {
        MetaCashNaoAtingida = 1,
        MetaRefinNaoAtingida = 2,
        AtrasoEntrada = 3,
        AtrasoSaída = 4,
        EstouroDePausa = 5,
        PausaFeedback = 6,
        Atraso_ComLogin = 7,
        Atraso_SemLogin = 8,
        Falta = 9,
        SaidaAntecipada = 10,
        Pausa10 = 11,
        PausaAlmoço = 12,
        PausaBanheiro = 13,
        PausaBreak = 14,
        PausaMonitoria = 15,
        PausaRetorno = 16,
        Pausa20 = 17,
        Pausa30 = 18,
        PausaAdministrativa = 19, 
        Segunda_Pausa10 = 20,
        Pausa15 = 21,
        QuinzeMinDeslogado = 22,
        TrintaMinDeslogado = 24,
        NaoDefinido = 25
    }

}
