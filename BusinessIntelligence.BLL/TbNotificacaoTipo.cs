using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
   public  class TbNotificacaoTipo
    {
        public void Cadastrar(DTO.TbNotificacaoTipo tipo_notificacao)
        {
            new DAL.TbNotificacaoTipo().Cadastrar(tipo_notificacao);
        }

        public void Atualizar(DTO.TbNotificacaoTipo tipo_notificacao)
        {
            new DAL.TbNotificacaoTipo().Cadastrar(tipo_notificacao);
        }

        public DTO.TbNotificacaoTipo SelecionarPeloId(int id)
        {
            return new DAL.TbNotificacaoTipo().SelecionarPeloId(id);
        }

        public List<DTO.TbNotificacaoTipo> Listar()
        {
            return new DAL.TbNotificacaoTipo().Listar();
        }

        public void Deletar(int id)
        {
            new DAL.TbNotificacaoTipo().Listar();
        }
    }
}