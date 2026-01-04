using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimCampanha:IDimCampanha
    {
        public List<DTO.DimCampanha> Select()
        {
            return new DAL.DimCampanha().Select();
        }

        public DTO.DimCampanha SelectById(int Id)
        {
            return new DAL.DimCampanha().SelectById(Id);
        }

        public void Remover(DTO.DimCampanha Entidade)
        {
            new DAL.DimCampanha().Remover(Entidade);
        }

        public void Cadastro(DTO.DimCampanha Entidade)
        {
            new DAL.DimCampanha().Cadastro(Entidade);
        }

        public void ImportaTotalIP()
        {
            string settingCampanha = System.Configuration.ConfigurationManager.AppSettings["Campanha"];
            int settingCredor = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Credor"]);

            List<int> campanhaIds = new List<int>();

            foreach (string id in settingCampanha.Split(','))
                campanhaIds.Add(int.Parse(id.Trim()));

            foreach (var item in new DAL.Discador.TotalIP.Campanhas().getByArrayIds(campanhaIds))
            {

                Cadastro(new DTO.DimCampanha()
                {
                    CampanhaId = item.id,
                    Descricao = item.nome
                });
            }
        }
    }
}
