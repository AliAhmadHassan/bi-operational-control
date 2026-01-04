using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimMaillingFiltrosCampo:Base
    {
        public DimMaillingFiltrosCampo()
        {
            MaillingFiltrosCampoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimMaillingFiltrosCampo"
            , ProcedureInserir = "SPIDimMaillingFiltrosCampo"
            , ProcedureRemover = "SPDDimMaillingFiltrosCampo"
            , ProcedureListarTodos = "SPSDimMaillingFiltrosCampo"
            , ProcedureSelecionar = "SPSDimMaillingFiltrosCampoByMaillingFiltrosCampoId")]
		public int MaillingFiltrosCampoId { get; set; }
		public string Nome { get; set; }
    }
}
