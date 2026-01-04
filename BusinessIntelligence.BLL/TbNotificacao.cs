using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbNotificacao
    {
        public void Cadastrar(DTO.TbNotificacao notificacao)
        {
            new DAL.TbNotificacao().Cadastrar(notificacao);
        }

        public void Atualizar(DTO.TbNotificacao notificacao)
        {
            new DAL.TbNotificacao().Atualizar(notificacao);
        }

        public void CadastrarNotificacaoHistorico(int usuario_id, int notificacao_id)
        {
            new DAL.TbNotificacao().CadastrarNotificacaoHistorico(usuario_id, notificacao_id);
        }

        public DTO.TbNotificacao SelecionarPeloId(int id)
        {
            return new DAL.TbNotificacao().SelecionarPeloId(id);
        }

        public List<DTO.TbNotificacao> Listar()
        {
            return new DAL.TbNotificacao().Listar();
        }

        public List<DTO.TbNotificacao> ListarPendentes(int us_id)
        {
            return new DAL.TbNotificacao().ListarPendentes(us_id);
        }
    }
}
