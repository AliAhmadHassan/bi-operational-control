using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimCredor:IDimCredor
    {
        public List<DTO.DimCredor> Select()
        {
            return new DAL.DimCredor().Select();
        }

        public DTO.DimCredor SelectById(int Id)
        {
            return new DAL.DimCredor().SelectById(Id);
        }

        public void Remover(DTO.DimCredor Entidade)
        {
            new DAL.DimCredor().Remover(Entidade);
        }

        public void Cadastro(DTO.DimCredor Entidade)
        {
            new DAL.DimCredor().Cadastro(Entidade);
        }
    }
}
