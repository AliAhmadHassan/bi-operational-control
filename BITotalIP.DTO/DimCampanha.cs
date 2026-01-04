using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimCampanha:Base
    {
        public DimCampanha()
        {
            CampanhaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimCampanha"
            , ProcedureInserir = "SPIDimCampanha"
            , ProcedureRemover = "SPDDimCampanha"
            , ProcedureListarTodos = "SPSDimCampanha"
            , ProcedureSelecionar = "SPSDimCampanhaByCampanhaId")]
		public int CampanhaId { get; set; }
		public string Descricao { get; set; }
    }
}
