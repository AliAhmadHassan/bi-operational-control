using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimGrupo:Base
    {
        public DimGrupo()
        {
            GrupoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimGrupo"
            , ProcedureInserir = "SPIDimGrupo"
            , ProcedureRemover = "SPDDimGrupo"
            , ProcedureListarTodos = "SPSDimGrupo"
            , ProcedureSelecionar = "SPSDimGrupoByGrupoId")]
		public int GrupoId { get; set; }
		public string Nome { get; set; }
		public int CredorId { get; set; }
    }
}
