using System;
using System.Collections.Generic;

namespace BITotalIP.Mailling.DTO
{
    public class Lote:BITotalIP.DTO.Base
    {
        public Lote()
        {
            Id = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULote"
            , ProcedureInserir = "SPILote"
            , ProcedureRemover = "SPDLote"
            , ProcedureListarTodos = "SPSLote"
            , ProcedureSelecionar = "SPSLoteById")]
		public int Id { get; set; }
		public string Descricao { get; set; }
		public DateTime DataLote { get; set; }
		public int IdUsuario { get; set; }
		public int Discador { get; set; }
    }
}
