using System;
using System.Collections.Generic;

namespace BusinessIntelligence.DTO
{
    public class TbGrupoCobrancaMeta
    {
		public int GrupoCobrancaMetaId { get; set; }
		public int GrupoCobrancaId { get; set; }
		public string Descricao { get; set; }
		public decimal Cash { get; set; }
		public decimal Refin { get; set; }
        public decimal CashCorrecao { get; set; }
        public decimal RefinCorrecao { get; set; }
    }
}