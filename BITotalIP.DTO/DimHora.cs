using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimHora:Base
    {
        public DimHora()
        {
            HoraID = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimHora"
            , ProcedureInserir = "SPIDimHora"
            , ProcedureRemover = "SPDDimHora"
            , ProcedureListarTodos = "SPSDimHora"
            , ProcedureSelecionar = "SPSDimHoraByHoraID")]
		public int HoraID { get; set; }
		public TimeSpan idHora { get; set; }
		public int Hora { get; set; }
		public int Minuto { get; set; }
		public int Segundo { get; set; }
    }
}
