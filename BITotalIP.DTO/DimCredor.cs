using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimCredor:Base
    {
        public DimCredor()
        {
            CredorId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimCredor"
            , ProcedureInserir = "SPIDimCredor"
            , ProcedureRemover = "SPDDimCredor"
            , ProcedureListarTodos = "SPSDimCredor"
            , ProcedureSelecionar = "SPSDimCredorByCredorId")]
		public int CredorId { get; set; }
		public string Nome { get; set; }
    }
}
