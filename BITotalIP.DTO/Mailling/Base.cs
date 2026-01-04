using System;
using System.Collections.Generic;

namespace BITotalIP.Mailling.DTO
{
    public class Base: BITotalIP.DTO.Base
    {
        public Base()
        {
            Id = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUBase"
            , ProcedureInserir = "SPIBase"
            , ProcedureRemover = "SPDBase"
            , ProcedureListarTodos = "SPSBase"
            , ProcedureSelecionar = "SPSBaseById")]
		public int Id { get; set; }
		public int IdLote { get; set; }
		public int IdHistorico { get; set; }
		public int IdAcordo { get; set; }
		public int IdDevedor { get; set; }
		public int IdUsuario { get; set; }
		public string CPFCNPJ { get; set; }
		public DateTime DataHistorico { get; set; }
		public DateTime DataAcordo { get; set; }
		public DateTime DataTela { get; set; }
    }
}
