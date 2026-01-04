using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class DimHora : Conexao
    {
        public List<DTO.DimHora> Select()
        {
            return AuxConsultas<DTO.DimHora>.Lista("SPSHora", ConnectionStringDW, null);
        }
    }
}
