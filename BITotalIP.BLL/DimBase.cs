using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimBase:IDimBase
    {
        public List<DTO.DimBase> Select()
        {
            return new DAL.DimBase().Select();
        }

        public DTO.DimBase SelectById(int Id)
        {
            return new DAL.DimBase().SelectById(Id);
        }

        public void Remover(DTO.DimBase Entidade)
        {
            new DAL.DimBase().Remover(Entidade);
        }

        public void Cadastro(DTO.DimBase Entidade)
        {
            new DAL.DimBase().Cadastro(Entidade);
        }

        public List<DTO.DimBase> SelectByMaillingId(int MaillingId)
        {
            return new DAL.DimBase().SelectByMaillingId(MaillingId);
        }

        public void ImportaAreaTeste(int MaillingId)
        {

            foreach (var item in new Mailling.DAL.Base().SelectByIdLote(MaillingId))
            {
                Cadastro(new DTO.DimBase()
                {
                    BaseId = item.Id,
                    CpfCnpj = item.CPFCNPJ,
                    MaillingId = item.IdLote
                });
            }

        }
    }
}
