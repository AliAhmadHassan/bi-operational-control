using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbNotificacaoMotivo
    {
        public void Cadastrar(DTO.TbNotificacaoMotivo motivo_notificacao)
        {
            new DAL.TbNotificacaoMotivo().Cadastrar(motivo_notificacao);
        }

        public void Atualizar(DTO.TbNotificacaoMotivo motivo_notificacao)
        {
            new DAL.TbNotificacaoMotivo().Atualizar(motivo_notificacao);
        }

        public DTO.TbNotificacaoMotivo SelecionarPeloId(int id)
        {
            return new DAL.TbNotificacaoMotivo().SelecionarPeloId(id);
        }

        public List<DTO.TbNotificacaoMotivo> Listar()
        {
            return new DAL.TbNotificacaoMotivo().Listar();
        }

        public void Deletar(int id)
        {
            new DAL.TbNotificacaoMotivo().Deletar(id);
        }
    }
}
