using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class DimSituacao
    {
        public DTO.DimSituacao ListarPelaDescricao(string descricao)
        {
            return new DAL.DimSituacao().ListarPelaDescricao(descricao);
        }
    }
}
