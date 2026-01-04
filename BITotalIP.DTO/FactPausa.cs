using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{

    [Serializable()]
    public class FactPausa:Base
    {
        public FactPausa()
        {
            PausaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUFactPausa"
            , ProcedureInserir = "SPIFactPausa"
            , ProcedureRemover = "SPDFactPausa"
            , ProcedureListarTodos = "SPSFactPausa"
            , ProcedureSelecionar = "SPSFactPausaByPausaId")]
		public Int64 PausaId { get; set; }
		public int UsuarioId { get; set; }
		public int UsuarioStatusId { get; set; }
		public int DataId { get; set; }
		public int HoraId { get; set; }
		public int Duracao { get; set; }
    }
}
