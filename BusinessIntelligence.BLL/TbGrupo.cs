using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupo
    {
        public List<DTO.TbGrupo> ListarGrupos()
        {
            return new DAL.TbGrupo().ListarGrupos();
        }

        public DTO.TbGrupo ObterGrupo(int grupo_id)
        {
            return new DAL.TbGrupo().ObterGrupo(grupo_id);
        }

        public List<DTO.GrupoHierarquia> HierarquiaGrupos()
        {
            return new DAL.TbGrupo().HierarquiaGrupos();
        }
    }
}