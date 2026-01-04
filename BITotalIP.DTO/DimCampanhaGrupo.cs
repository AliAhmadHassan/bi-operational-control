using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimCampanhaGrupo:Base
    {
        public DimCampanhaGrupo()
        {
            CampanhaGrupoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimCampanhaGrupo"
            , ProcedureInserir = "SPIDimCampanhaGrupo"
            , ProcedureRemover = "SPDDimCampanhaGrupo"
            , ProcedureListarTodos = "SPSDimCampanhaGrupo"
            , ProcedureSelecionar = "SPSDimCampanhaGrupoByCampanhaGrupoId")]
		public int CampanhaGrupoId { get; set; }
		public int CampanhaId { get; set; }
		public int GrupoId { get; set; }
    }
}
