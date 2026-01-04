using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimDiscagemStatus:Base
    {
        public DimDiscagemStatus()
        {
            DiscagemStatusId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimDiscagemStatus"
            , ProcedureInserir = "SPIDimDiscagemStatus"
            , ProcedureRemover = "SPDDimDiscagemStatus"
            , ProcedureListarTodos = "SPSDimDiscagemStatus"
            , ProcedureSelecionar = "SPSDimDiscagemStatusByDiscagemStatusId")]
		public int DiscagemStatusId { get; set; }
		public string Descricao { get; set; }
		public bool Alo { get; set; }
		public bool Localizado { get; set; }
		public bool CPC { get; set; }
    }
}
