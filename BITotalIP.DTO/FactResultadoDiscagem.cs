using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class FactResultadoDiscagem:Base
    {
        public FactResultadoDiscagem()
        {
            ResultadoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUFactResultadoDiscagem"
            , ProcedureInserir = "SPIFactResultadoDiscagem"
            , ProcedureRemover = "SPDFactResultadoDiscagem"
            , ProcedureListarTodos = "SPSFactResultadoDiscagem"
            , ProcedureSelecionar = "SPSFactResultadoDiscagemByResultadoId")]
		public Int64 ResultadoId { get; set; }
		public int CampanhaId { get; set; }
		public int MaillingId { get; set; }
		public int BaseId { get; set; }
		public int DiscagemStatusId { get; set; }
		public int DataId { get; set; }
		public int HoraId { get; set; }
    }
}
