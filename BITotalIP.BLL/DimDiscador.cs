using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimDiscador:IDimDiscador
    {
        public List<DTO.DimDiscador> Select()
        {
            return new DAL.DimDiscador().Select();
        }

        public DTO.DimDiscador SelectById(int Id)
        {
            return new DAL.DimDiscador().SelectById(Id);
        }

        public void Remover(DTO.DimDiscador Entidade)
        {
            new DAL.DimDiscador().Remover(Entidade);
        }

        public void Cadastro(DTO.DimDiscador Entidade)
        {
            new DAL.DimDiscador().Cadastro(Entidade);
        }
    }
}
