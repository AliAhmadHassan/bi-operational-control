using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class FactResultadoDiscagem:IFactResultadoDiscagem
    {
        public List<DTO.FactResultadoDiscagem> Select()
        {
            return new DAL.FactResultadoDiscagem().Select();
        }

        public DTO.FactResultadoDiscagem SelectById(int Id)
        {
            return new DAL.FactResultadoDiscagem().SelectById(Id);
        }

        public void Remover(DTO.FactResultadoDiscagem Entidade)
        {
            new DAL.FactResultadoDiscagem().Remover(Entidade);
        }

        public void Cadastro(DTO.FactResultadoDiscagem Entidade)
        {
            new DAL.FactResultadoDiscagem().Cadastro(Entidade);
        }

        public void ImportaTotalIP()
        {
            DimDiscagemStatus discagemStatusServico = new DimDiscagemStatus();
            DimData dimDataServico = new DimData();
            DimHora dimHoraServico = new DimHora();
            
            DimBase baseServico = new DimBase();
            List<DTO.DimDiscagemStatus> listaDiscagemStatus = new List<DTO.DimDiscagemStatus>();

            string settingCampanha = System.Configuration.ConfigurationManager.AppSettings["Campanha"];
            int settingCredor = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Credor"]);

            List<int> campanhaIds = new List<int>();

            foreach (string id in settingCampanha.Split(','))
                campanhaIds.Add(int.Parse(id.Trim()));

            int qtdProcessado = 0;
            foreach (var item in new DAL.Discador.TotalIP.ResultadoDiscador().getByGreaterThan(campanhaIds, selectMaxId()))
            {
                DTO.DimDiscagemStatus discagemStatus = listaDiscagemStatus.Where(c => c.DiscagemStatusId.Equals(item.id_status)).FirstOrDefault();
                if (discagemStatus == null)
                {
                    discagemStatus = new DTO.DimDiscagemStatus()
                    {
                        DiscagemStatusId = item.id_status,
                        Descricao = item.status
                    };
                    discagemStatusServico.Cadastro(discagemStatus);
                    listaDiscagemStatus.Add(discagemStatus);
                }

                DTO.DimBase _base = baseServico.SelectById(int.Parse(item.identificador1.Split('&')[1].Replace("IdBase=", "")));
                if(_base.BaseId == -1)
                {
                    new DimMailling().InativaMaillingAnteriores(campanhaIds);
                    Mailling.DTO.Base _baseAux = new Mailling.DAL.Base().SelectById(int.Parse(item.identificador1.Split('&')[1].Replace("IdBase=", "")));
                    Console.WriteLine("Processando SubRotina para inclusão do Mailling id: " + _baseAux.IdLote);
                    new DimMailling().ImportaAreaTeste(_baseAux.IdLote);
                    new DimMaillingFiltros().ImportaAreaTeste(_baseAux.IdLote);
                    new DimBase().ImportaAreaTeste(_baseAux.IdLote);
                    _base = baseServico.SelectById(int.Parse(item.identificador1.Split('&')[1].Replace("IdBase=", "")));
                }


                DTO.DimData data = new DimData().SelectByData(item.data);
                DTO.DimHora hora = new DimHora().SelectByIdHora(item.data);

                Cadastro(new DTO.FactResultadoDiscagem()
                {
                    BaseId = (int)_base.BaseId,
                    CampanhaId = item.id_campanha,
                    MaillingId = _base.MaillingId,
                    ResultadoId = item.id,
                    DiscagemStatusId = discagemStatus.DiscagemStatusId,
                    DataId = data.DataID,
                    HoraId = hora.HoraID
                });

                Console.WriteLine("Importado "+ qtdProcessado.ToString() + " id: " + item.id);
                qtdProcessado++;
            }
        }

        public long selectMaxId()
        {
            return new DAL.FactResultadoDiscagem().selectMaxId();
        }
    }
}
