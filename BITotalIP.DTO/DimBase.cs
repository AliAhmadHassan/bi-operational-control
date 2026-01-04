using System;
using System.Collections.Generic;

namespace BITotalIP.DTO
{
    public class DimBase:Base
    {
        public DimBase()
        {
            BaseId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDimBase"
            , ProcedureInserir = "SPIDimBase"
            , ProcedureRemover = "SPDDimBase"
            , ProcedureListarTodos = "SPSDimBase"
            , ProcedureSelecionar = "SPSDimBaseByBaseId")]
		public Int64 BaseId { get; set; }
		public string Nome { get; set; }
		public string CpfCnpj { get; set; }
		public string Telefone { get; set; }
		public int MaillingId { get; set; }
    }
}
