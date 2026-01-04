using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimMaillingFiltrosTabela:Base
    {
        public DimMaillingFiltrosTabela()
        {
            MaillingFiltrosTabelaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimMaillingFiltrosTabela"
            , ProcedureInserir = "SPIDimMaillingFiltrosTabela"
            , ProcedureRemover = "SPDDimMaillingFiltrosTabela"
            , ProcedureListarTodos = "SPSDimMaillingFiltrosTabela"
            , ProcedureSelecionar = "SPSDimMaillingFiltrosTabelaByMaillingFiltrosTabelaId")]
		public int MaillingFiltrosTabelaId { get; set; }
		public string Nome { get; set; }
    }
}
