using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.BLL
{
    public class FactPausa
    {
        public List<ServiceNotification.DTO.FactPausa> getResult()
        {
            List<ServiceNotification.DTO.FactPausa> lstFactPausa = new List<DTO.FactPausa>();

            ServiceNotification.Msmq.ServiceMsmq serviceMsmq = new Msmq.ServiceMsmq();

            var serviceMsmqTransaction = serviceMsmq.BeginTransaction();

            bool nulo = false;
            while (!nulo)
            {
                BITotalIP.DTO.FactPausa factPausa = serviceMsmq.Dequeue<BITotalIP.DTO.FactPausa>(System.Configuration.ConfigurationManager.AppSettings["filaPausa"], serviceMsmqTransaction);

                if (factPausa != null)
                {
                    ServiceNotification.DTO.FactPausa aux = factPausa.GetModels<ServiceNotification.DTO.FactPausa>();
                    aux.Hora = ServiceNotification.BLL.DimHora.getById(aux.HoraId).idHora;
                    lstFactPausa.Add(aux);
                }
                else
                    nulo = true;
            }

            serviceMsmq.CommmitTransaction();

            return lstFactPausa;
        }

        public ServiceNotification.DTO.FactPausa getNext()
        {
            //Fila
            ServiceNotification.Msmq.ServiceMsmq serviceMsmq = new Msmq.ServiceMsmq();

            //Transação
            var serviceMsmqTransaction = serviceMsmq.BeginTransaction();
            BITotalIP.DTO.FactPausa factPausa = serviceMsmq.Dequeue<BITotalIP.DTO.FactPausa>(System.Configuration.ConfigurationManager.AppSettings["filaPausa"], serviceMsmqTransaction);
            if (factPausa == null) return null;

            //Pausa
            ServiceNotification.DTO.FactPausa aux = factPausa.GetModels<ServiceNotification.DTO.FactPausa>();
            aux.Hora = ServiceNotification.BLL.DimHora.getById(aux.HoraId).idHora;

            //Transação
            serviceMsmq.CommmitTransaction();

            return aux;
        }
    }
}
