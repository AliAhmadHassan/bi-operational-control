using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL.Discador.TotalIP
{
    public class Usuarios
    {
        public List<DTO.Discador.TotalIP.Usuarios> getByArrayIdGrupos(List<int> ids)
        {
            return new DAL.Discador.TotalIP.Usuarios().getByArrayIdGrupos(ids);

        }
    }
}
