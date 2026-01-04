using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.BLL
{
    public static class DimHora
    {
        static SortedList<int, ServiceNotification.DTO.DimHora> lstHora = new SortedList<int, DTO.DimHora>();
        static DateTime ultimaAtualizacao;

        public static ServiceNotification.DTO.DimHora getById(int id)
        {
            ServiceNotification.DTO.DimHora dimHora;

            if (ultimaAtualizacao.AddDays(1) < DateTime.Now)
            {
                AtualizaLista();
                ultimaAtualizacao = DateTime.Now;
            }

            dimHora = lstHora[id];
            return dimHora;
        }

        private static void AtualizaLista()
        {
            lstHora.Clear();
            foreach (BITotalIP.DTO.DimHora dimHora in new BITotalIP.BLL.DimHora().Select())
            {
                lstHora.Add(dimHora.HoraID, dimHora.GetModels<ServiceNotification.DTO.DimHora>());
            }
        }
    }
}
