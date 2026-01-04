using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimDiscador:Base
    {
        public DimDiscador()
        {
            DiscadorId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimDiscador"
            , ProcedureInserir = "SPIDimDiscador"
            , ProcedureRemover = "SPDDimDiscador"
            , ProcedureListarTodos = "SPSDimDiscador"
            , ProcedureSelecionar = "SPSDimDiscadorByDiscadorId")]
		public int DiscadorId { get; set; }
		public string Nome { get; set; }
    }
}
