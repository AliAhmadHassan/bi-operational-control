using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class DimStatusCobranca
    {
        public DTO.DimStatusCobranca ListarPelaDescricao(string descricao)
        {
            return new DAL.DimStatusCobranca().ListarPelaDescricao(descricao);
        }
    }
}
