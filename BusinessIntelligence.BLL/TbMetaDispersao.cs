using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbMetaDispersao
    {
        public void Incluir(DTO.TbMetaDispersao meta)
        {
            new DAL.TbMetaDispersao().Incluir(meta);
        }

        public List<DTO.TbMetaDispersao> Listar(string carteiras)
        {
           return new DAL.TbMetaDispersao().Listar(carteiras);
        }
    }
}
