using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.BLL
{
    public class DimUsuarioStatus
    {
        SortedList<int, ServiceNotification.DTO.DimUsuarioStatus> lstUsuarioStatus = new SortedList<int, DTO.DimUsuarioStatus>();
        DateTime ultimaAtualizacao;

        public ServiceNotification.DTO.DimUsuarioStatus getById(int id)
        {
            ServiceNotification.DTO.DimUsuarioStatus dimUsuarioStatus = null;

            try
            {
                if (ultimaAtualizacao.AddDays(1) < DateTime.Now)
                {
                    AtualizaLista();
                    ultimaAtualizacao = DateTime.Now;
                }

                dimUsuarioStatus = lstUsuarioStatus[id];
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            return dimUsuarioStatus;
        }

        private void AtualizaLista()
        {
            lstUsuarioStatus.Clear();
            foreach (BITotalIP.DTO.DimUsuarioStatus dimUsuarioStatus in new BITotalIP.BLL.DimUsuarioStatus().Select())
            {
                ServiceNotification.DTO.DimUsuarioStatus aux = dimUsuarioStatus.GetModels<ServiceNotification.DTO.DimUsuarioStatus>();

                if (aux.Obrigatorio)
                {
                    aux.Inicio = aux.Duracao;
                    aux.Fim = TimeSpan.FromSeconds(aux.Duracao.TotalSeconds * (1 + double.Parse(System.Configuration.ConfigurationManager.AppSettings["ToleranciaPausa"])));
                }
                else
                {
                    aux.Inicio = TimeSpan.Zero;
                    aux.Fim = TimeSpan.FromSeconds(aux.Duracao.TotalSeconds * (1 + double.Parse(System.Configuration.ConfigurationManager.AppSettings["ToleranciaPausa"])));
                }
                lstUsuarioStatus.Add(dimUsuarioStatus.UsuarioStatusId, aux);
            }
        }
    }
}
