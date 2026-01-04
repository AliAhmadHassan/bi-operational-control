using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimUsuario:Base
    {
        public DimUsuario()
        {
            UsuarioId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimUsuario"
            , ProcedureInserir = "SPIDimUsuario"
            , ProcedureRemover = "SPDDimUsuario"
            , ProcedureListarTodos = "SPSDimUsuario"
            , ProcedureSelecionar = "SPSDimUsuarioByUsuarioId")]
		public int UsuarioId { get; set; }
		public string Nome { get; set; }
		public string Ramal { get; set; }
		public int CobNetUsId { get; set; }
		public TimeSpan InicioExpediente { get; set; }
		public TimeSpan FimExpediente { get; set; }
		public int GrupoId { get; set; }
    }
}
