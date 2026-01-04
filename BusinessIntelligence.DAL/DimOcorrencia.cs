using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class DimOcorrencia : Conexao
    {
        public List<DTO.DimOcorrencia> ListarOcorrenciasAcordo()
        {
            return AuxConsultas<DTO.DimOcorrencia>.Lista(
                "SPSOcorrenciaAcordo",
                ConnectionStringDW, null);
        }
    }
}
