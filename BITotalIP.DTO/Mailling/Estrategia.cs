using System;
using System.Collections.Generic;

namespace BITotalIP.Mailling.DTO
{
    public class Estrategia: BITotalIP.DTO.Base
    {
        public Estrategia()
        {
            Id = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUEstrategia"
            , ProcedureInserir = "SPIEstrategia"
            , ProcedureRemover = "SPDEstrategia"
            , ProcedureListarTodos = "SPSEstrategia"
            , ProcedureSelecionar = "SPSEstrategiaById")]
		public int Id { get; set; }
		public int IdLote { get; set; }
		public string Tabela { get; set; }
		public string Campo { get; set; }
		public string De { get; set; }
		public string Ate { get; set; }
		public string Valor { get; set; }
		public bool VerdadeiroFalso { get; set; }
    }
}
