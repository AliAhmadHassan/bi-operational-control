using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class DimCredor
    {
        public List<DTO.DimCredor> ListarCredores()
        {
            return new DAL.DimCredor().ListarCredores();
        }

        public List<DTO.DimCredor> ListarCredoresPeloGrupo(int grupo_id)
        {
            return new DAL.DimCredor().ListarCredoresPeloGrupo(grupo_id);
        }

        public DTO.DimCredor ListarCredoresPeloID(int credor_id)
        {
            return new DAL.DimCredor().ListarCredoresPeloID(credor_id);
        }
        
    }
}
