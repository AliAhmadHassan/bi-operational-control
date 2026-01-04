using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimMailling:IDimMailling
    {
        public List<DTO.DimMailling> Select()
        {
            return new DAL.DimMailling().Select();
        }

        public DTO.DimMailling SelectById(int Id)
        {
            return new DAL.DimMailling().SelectById(Id);
        }

        public void Remover(DTO.DimMailling Entidade)
        {
            new DAL.DimMailling().Remover(Entidade);
        }

        public void Cadastro(DTO.DimMailling Entidade)
        {
            new DAL.DimMailling().Cadastro(Entidade);
        }

        public void ImportaAreaTeste(int MaillingId)
        {
            Mailling.DTO.Lote lote = new Mailling.DAL.Lote().SelectById(MaillingId);

            DTO.DimData data = new DimData().SelectByData(lote.DataLote);
            DTO.DimHora hora = new DimHora().SelectByIdHora(lote.DataLote);

            Cadastro(new DTO.DimMailling()
            {
                DataId = data.DataID,
                Descricao = lote.Descricao,
                DiscadorId = lote.Discador,
                MaillingId = lote.Id
            });

        }

        public void InativaMaillingAnteriores(List<int> CampanhaIds)
        {
            new DAL.DimMailling().InativaMaillingAnteriores(CampanhaIds);
        }
    }
}
