using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class FactPausa : IFactPausa
    {
        public List<DTO.FactPausa> Select()
        {
            return new DAL.FactPausa().Select();
        }

        public DTO.FactPausa SelectById(int Id)
        {
            return new DAL.FactPausa().SelectById(Id);
        }

        public void Remover(DTO.FactPausa Entidade)
        {
            new DAL.FactPausa().Remover(Entidade);
        }

        public void Cadastro(DTO.FactPausa Entidade)
        {
            new DAL.FactPausa().Cadastro(Entidade);
        }

        public List<DTO.FactPausa> SelectByUsuarioId(int UsuarioId)
        {
            return new DAL.FactPausa().SelectByUsuarioId(UsuarioId);
        }

        public List<DTO.FactPausa> SelectByUsuarioStatusId(int UsuarioStatusId)
        {
            return new DAL.FactPausa().SelectByUsuarioStatusId(UsuarioStatusId);
        }

        public List<DTO.FactPausa> SelectByDataId(int DataId)
        {
            return new DAL.FactPausa().SelectByDataId(DataId);
        }

        public List<DTO.FactPausa> SelectByHoraId(int HoraId)
        {
            return new DAL.FactPausa().SelectByHoraId(HoraId);
        }

        long ultimoId = 0;
        public void ImportaTotalIP()
        {
            List<int> idsUsuarios = new List<int>();

            string settingGrupo = System.Configuration.ConfigurationManager.AppSettings["Grupo"];
            foreach (string id in settingGrupo.Split(','))
                foreach (var usuario in new DimUsuario().SelectByGrupoId(int.Parse(id.Trim())))
                    idsUsuarios.Add(usuario.UsuarioId);


            DimData dimDataServico = new DimData();
            DimHora dimHoraServico = new DimHora();

            foreach (var item in new DAL.Discador.TotalIP.Pausas().getByUsuario(idsUsuarios))
            {
                DTO.DimData data = new DimData().SelectByData(item.data);
                DTO.DimHora hora = new DimHora().SelectByIdHora(item.data);

                DTO.FactPausa factPausa = new DTO.FactPausa()
                {
                    DataId = data.DataID,
                    HoraId = hora.HoraID,
                    Duracao = item.tempo,
                    UsuarioId = (int)item.id_usuario,
                    UsuarioStatusId = item.id_status
                };

                //Cadastro(factPausa);

                //if(ultimoId < factPausa.PausaId)
                {
                    ServiceNotification.Msmq.ServiceMsmq serviceMsmq = new ServiceNotification.Msmq.ServiceMsmq();

                    var serviceMsmqTransaction = serviceMsmq.BeginTransaction();
                    serviceMsmq.Enqueue<DTO.FactPausa>(factPausa, System.Configuration.ConfigurationManager.AppSettings["filaPausa"], serviceMsmqTransaction);
                    serviceMsmqTransaction.Commit();

                    ultimoId = factPausa.PausaId;
                }
            }
        }
    }
}
