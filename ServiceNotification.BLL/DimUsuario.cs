using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceNotification.BLL
{
    public class DimUsuario
    {
        SortedList<int, ServiceNotification.DTO.DimUsuario> lstUsuario = new SortedList<int, DTO.DimUsuario>();
        DateTime ultimaAtualizacao;

        public ServiceNotification.DTO.DimUsuario getById(int id)
        {
            ServiceNotification.DTO.DimUsuario dimUsuario;

            if (ultimaAtualizacao.AddDays(1) < DateTime.Now)
            {
                AtualizaLista();
                ultimaAtualizacao = DateTime.Now;
            }

            dimUsuario = lstUsuario[id];
            return dimUsuario;
        }

        private void AtualizaLista()
        {
            string settingGrupo = System.Configuration.ConfigurationManager.AppSettings["Discador.Grupo"];

            List<int> grupoIds = new List<int>();

            foreach (string id in settingGrupo.Split(','))
                grupoIds.Add(int.Parse(id.Trim()));

            lstUsuario.Clear();
            foreach (BITotalIP.DTO.DimUsuario dimUsuario in new BITotalIP.BLL.DimUsuario().Select())
            {
                if (grupoIds.Contains(dimUsuario.GrupoId))
                {
                    ServiceNotification.DTO.DimUsuario aux = dimUsuario.GetModels<ServiceNotification.DTO.DimUsuario>();
                    aux.InicioExpediente_Tolerancia = TimeSpan.FromMinutes(aux.InicioExpediente.TotalMinutes + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ToleranciaInicioFim_Minutos"]));
                    aux.FimExpediente_Tolerancia = TimeSpan.FromMinutes(aux.FimExpediente.TotalMinutes - Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ToleranciaInicioFim_Minutos"]));

                    lstUsuario.Add(dimUsuario.UsuarioId, aux);
                }
            }
        }

        public List<ServiceNotification.DTO.DimUsuario> getLista()
        {
            List<ServiceNotification.DTO.DimUsuario> lista = new List<DTO.DimUsuario>();

            foreach (var item in lstUsuario)
            {

                lista.Add(item.Value);
            }

            return lista;
        }

        public void setLista(List<ServiceNotification.DTO.DimUsuario> lista)
        {
            lstUsuario.Clear();

            foreach (var item in lista)
                lstUsuario.Add(item.UsuarioId, item);
        }
    }
}
