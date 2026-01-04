using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoCobrancaMeta
    {
        public void Cadastrar(DTO.TbGrupoCobrancaMeta grupocobranca)
        {
            new DAL.TbGrupoCobrancaMetas().Cadastrar(grupocobranca);
        }

        public void Deletar(int id)
        {
            new DAL.TbGrupoCobrancaMetas().Deletar(id);
        }

        public void Atualizar(DTO.TbGrupoCobrancaMeta grupocobranca)
        {
            new DAL.TbGrupoCobrancaMetas().Atualizar(grupocobranca);
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMetaPeloId(int id)
        {
           return new DAL.TbGrupoCobrancaMetas().SelecionarGrupoCobrancaMetaPeloId(id);
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMeta()
        {
            return new DAL.TbGrupoCobrancaMetas().SelecionarGrupoCobrancaMeta();
        }

        public List<DTO.TbGrupoCobrancaMeta> SelecionarGrupoCobrancaMetaPeloGrupoId(int id)
        {
            return new DAL.TbGrupoCobrancaMetas().SelecionarGrupoCobrancaMetaPeloGrupoId(id);
        }
    }
}