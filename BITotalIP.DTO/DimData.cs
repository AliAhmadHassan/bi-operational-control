using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimData:Base
    {
        public DimData()
        {
            DataID = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimData"
            , ProcedureInserir = "SPIDimData"
            , ProcedureRemover = "SPDDimData"
            , ProcedureListarTodos = "SPSDimData"
            , ProcedureSelecionar = "SPSDimDataByDataID")]
		public int DataID { get; set; }
		public DateTime Data { get; set; }
		public Int16 Ano { get; set; }
		public string DataCurta { get; set; }
		public string DiaSemana { get; set; }
		public Int16 DiaMes { get; set; }
		public string MesNome { get; set; }
		public Int16 MesNumero { get; set; }
		public Int16 Trimestre { get; set; }
		public Int16 Semestre { get; set; }
    }
}
