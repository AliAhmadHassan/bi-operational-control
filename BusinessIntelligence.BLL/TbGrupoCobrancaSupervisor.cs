using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoCobrancaSupervisor
    {
        public void Cadastrar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            new DAL.TbGrupoCobrancaSupervisor().Cadastrar(grupocobranca);
        }

        public void Deletar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            new DAL.TbGrupoCobrancaSupervisor().Deletar(grupocobranca);
        }

        public void Atualizar(DTO.TbGrupoCobrancaSupervisor grupocobranca)
        {
            new DAL.TbGrupoCobrancaSupervisor().Atualizar(grupocobranca);
        }

        public List<DTO.TbGrupoCobrancaSupervisor> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return new DAL.TbGrupoCobrancaSupervisor().SelecionarPeloGrupoCrobrancaId(id);
        }

        public List<DTO.TbGrupoCobrancaSupervisor> SelecionarPeloGrupoSupervisorId(int id)
        {
            return new DAL.TbGrupoCobrancaSupervisor().SelecionarPeloGrupoSupervisorId(id);
        }
    }
}
