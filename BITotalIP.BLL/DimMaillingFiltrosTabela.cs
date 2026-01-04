using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimMaillingFiltrosTabela:IDimMaillingFiltrosTabela
    {
        public List<DTO.DimMaillingFiltrosTabela> Select()
        {
            return new DAL.DimMaillingFiltrosTabela().Select();
        }

        public DTO.DimMaillingFiltrosTabela SelectById(int Id)
        {
            return new DAL.DimMaillingFiltrosTabela().SelectById(Id);
        }

        public void Remover(DTO.DimMaillingFiltrosTabela Entidade)
        {
            new DAL.DimMaillingFiltrosTabela().Remover(Entidade);
        }

        public void Cadastro(DTO.DimMaillingFiltrosTabela Entidade)
        {
            new DAL.DimMaillingFiltrosTabela().Cadastro(Entidade);
        }
    }
}
