using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class Discador
    {
        public List<DTO.DiscadorMailing> ListarStatusDiscagem(int id_mailing)
        {
            return new DAL.Discador().ListarStatusDiscagem(id_mailing);
        }

        public List<DTO.DiscadorMailing> ListarStatusDiscagemPelaCampanha(int id_campanha)
        {
            return new DAL.Discador().ListarStatusDiscagemPelaCampanha(id_campanha);
        }

        public List<DTO.DiscadorMailing> ListarAlo(int id_mailing)
        {
            return new DAL.Discador().ListarAlo(id_mailing);
        }

        public List<DTO.DiscadorMailing> ListarLocalizado(int id_mailing)
        {
            return new DAL.Discador().ListarLocalizado(id_mailing);
        }

        public List<DTO.DiscadorMailing> ListarCpc(int id_mailing)
        {
            return new DAL.Discador().ListarCpc(id_mailing);
        }

        public List<DTO.DiscadorStatusDia> ListarUsuariosStatusDia(int ano, int mes, int dia)
        {
            return new DAL.Discador().ListarUsuariosStatusDia(ano, mes, dia);
        }

        public List<DTO.MailingAtivo> ListarMailingAtivos()
        {
            return new DAL.Discador().ListarMailingAtivos();
        }
    }
}
