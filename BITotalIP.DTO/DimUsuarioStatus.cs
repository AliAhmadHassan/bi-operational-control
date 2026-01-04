using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimUsuarioStatus:Base
    {
        public DimUsuarioStatus()
        {
            UsuarioStatusId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimUsuarioStatus"
            , ProcedureInserir = "SPIDimUsuarioStatus"
            , ProcedureRemover = "SPDDimUsuarioStatus"
            , ProcedureListarTodos = "SPSDimUsuarioStatus"
            , ProcedureSelecionar = "SPSDimUsuarioStatusByUsuarioStatusId")]
		public int UsuarioStatusId { get; set; }
		public string Descricao { get; set; }
		public bool Obrigatorio { get; set; }
        public TimeSpan Duracao { get; set; }
    }
}
