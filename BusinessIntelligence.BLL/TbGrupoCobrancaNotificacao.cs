using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoCobrancaNotificacao
    {
        public void Cadastrar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            new DAL.TbGrupoCobrancaNotificacao().Cadastrar(grupocobranca);
        }

        public void Deletar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            new DAL.TbGrupoCobrancaNotificacao().Deletar(grupocobranca);
        }

        public void Atualizar(DTO.TbGrupoCobrancaNotificacao grupocobranca)
        {
            new DAL.TbGrupoCobrancaNotificacao().Atualizar(grupocobranca);
        }

        public List<DTO.TbGrupoCobrancaNotificacao> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return new DAL.TbGrupoCobrancaNotificacao().SelecionarPeloGrupoCrobrancaId(id);
        }

        public List<DTO.TbGrupoCobrancaNotificacao> SelecionarPeloGrupoUsuarioId(int id)
        {
            return new DAL.TbGrupoCobrancaNotificacao().SelecionarPeloGrupoUsuarioId(id);
        }
    }
}
