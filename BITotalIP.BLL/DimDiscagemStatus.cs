using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimDiscagemStatus:IDimDiscagemStatus
    {
        DAL.DimDiscagemStatus discagemStatusDAL;

        public DimDiscagemStatus()
        {
            discagemStatusDAL = new DAL.DimDiscagemStatus();
        }

        public List<DTO.DimDiscagemStatus> Select()
        {
            return discagemStatusDAL.Select();
        }

        public DTO.DimDiscagemStatus SelectById(int Id)
        {
            return discagemStatusDAL.SelectById(Id);
        }

        public void Remover(DTO.DimDiscagemStatus Entidade)
        {
            discagemStatusDAL.Remover(Entidade);
        }

        public void Cadastro(DTO.DimDiscagemStatus Entidade)
        {
            discagemStatusDAL.Cadastro(Entidade);
        }
    }
}
