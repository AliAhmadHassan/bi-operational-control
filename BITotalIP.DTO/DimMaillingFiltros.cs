using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimMaillingFiltros:Base
    {
        public DimMaillingFiltros()
        {
            MaillingFiltrosId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimMaillingFiltros"
            , ProcedureInserir = "SPIDimMaillingFiltros"
            , ProcedureRemover = "SPDDimMaillingFiltros"
            , ProcedureListarTodos = "SPSDimMaillingFiltros"
            , ProcedureSelecionar = "SPSDimMaillingFiltrosByMaillingFiltrosId")]
		public int MaillingFiltrosId { get; set; }
		public int MaillingId { get; set; }
		public int MaillingFiltrosTabelaId { get; set; }
		public int MaillingFiltrosCampoId { get; set; }
		public string De { get; set; }
		public string Ate { get; set; }
		public string Valor { get; set; }
		public bool VerdadeiroFalso { get; set; }
    }
}
