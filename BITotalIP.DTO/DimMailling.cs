using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimMailling:Base
    {
        public DimMailling()
        {
            MaillingId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimMailling"
            , ProcedureInserir = "SPIDimMailling"
            , ProcedureRemover = "SPDDimMailling"
            , ProcedureListarTodos = "SPSDimMailling"
            , ProcedureSelecionar = "SPSDimMaillingByMaillingId")]
		public int MaillingId { get; set; }
		public string Descricao { get; set; }
		public int DataId { get; set; }
		public int DiscadorId { get; set; }
    }
}
