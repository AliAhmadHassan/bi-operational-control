using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimMaillingFiltros : IDimMaillingFiltros
    {
        public List<DTO.DimMaillingFiltros> Select()
        {
            return new DAL.DimMaillingFiltros().Select();
        }

        public DTO.DimMaillingFiltros SelectById(int Id)
        {
            return new DAL.DimMaillingFiltros().SelectById(Id);
        }

        public void Remover(DTO.DimMaillingFiltros Entidade)
        {
            new DAL.DimMaillingFiltros().Remover(Entidade);
        }

        public void Cadastro(DTO.DimMaillingFiltros Entidade)
        {
            new DAL.DimMaillingFiltros().Cadastro(Entidade);
        }

        public List<DTO.DimMaillingFiltros> SelectByMaillingId(int MaillingId)
        {
            return new DAL.DimMaillingFiltros().SelectByMaillingId(MaillingId);
        }

        public List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosTabelaId(int MaillingFiltrosTabelaId)
        {
            return new DAL.DimMaillingFiltros().SelectByMaillingFiltrosTabelaId(MaillingFiltrosTabelaId);
        }

        public List<DTO.DimMaillingFiltros> SelectByMaillingFiltrosCampoId(int MaillingFiltrosCampoId)
        {
            return new DAL.DimMaillingFiltros().SelectByMaillingFiltrosCampoId(MaillingFiltrosCampoId);
        }

        public void ImportaAreaTeste(int MaillingId)
        {
            foreach (var item in new Mailling.DAL.Estrategia().SelectByIdLote(MaillingId))
            {
                DTO.DimMaillingFiltrosTabela maillingFiltrosTabela = new DTO.DimMaillingFiltrosTabela()
                {
                    Nome = item.Tabela
                };
                new DimMaillingFiltrosTabela().Cadastro(maillingFiltrosTabela);

                DTO.DimMaillingFiltrosCampo maillingFiltrosCampo = new DTO.DimMaillingFiltrosCampo()
                {
                    Nome = item.Campo
                };
                new DimMaillingFiltrosCampo().Cadastro(maillingFiltrosCampo);

                Cadastro(new DTO.DimMaillingFiltros()
                {
                    MaillingFiltrosTabelaId = maillingFiltrosTabela.MaillingFiltrosTabelaId,
                    MaillingFiltrosCampoId = maillingFiltrosCampo.MaillingFiltrosCampoId,
                    De = item.De,
                    Ate = item.Ate,
                    Valor = item.Valor,
                    VerdadeiroFalso = item.VerdadeiroFalso,
                    MaillingId = item.IdLote
                });
            }
        }
    }
}
