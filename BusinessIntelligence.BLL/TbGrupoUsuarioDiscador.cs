using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoUsuarioDiscador
    {
        public List<DTO.TbGrupoUsuarioDiscador> GrupoOperadores(int ano, int mes, int dia)
        {
            return new DAL.TbGrupoUsuarioDiscador().GrupoOperadores(ano, mes, dia);
        }
    }
}