using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimMaillingFiltrosCampo:IDimMaillingFiltrosCampo
    {
        public List<DTO.DimMaillingFiltrosCampo> Select()
        {
            return new DAL.DimMaillingFiltrosCampo().Select();
        }

        public DTO.DimMaillingFiltrosCampo SelectById(int Id)
        {
            return new DAL.DimMaillingFiltrosCampo().SelectById(Id);
        }

        public void Remover(DTO.DimMaillingFiltrosCampo Entidade)
        {
            new DAL.DimMaillingFiltrosCampo().Remover(Entidade);
        }

        public void Cadastro(DTO.DimMaillingFiltrosCampo Entidade)
        {
            new DAL.DimMaillingFiltrosCampo().Cadastro(Entidade);
        }
    }
}
