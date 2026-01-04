using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimUsuarioStatus:IDimUsuarioStatus
    {
        public List<DTO.DimUsuarioStatus> Select()
        {
            return new DAL.DimUsuarioStatus().Select();
        }

        public DTO.DimUsuarioStatus SelectById(int Id)
        {
            return new DAL.DimUsuarioStatus().SelectById(Id);
        }

        public void Remover(DTO.DimUsuarioStatus Entidade)
        {
            new DAL.DimUsuarioStatus().Remover(Entidade);
        }

        public void Cadastro(DTO.DimUsuarioStatus Entidade)
        {
            new DAL.DimUsuarioStatus().Cadastro(Entidade);
        }
    }
}
