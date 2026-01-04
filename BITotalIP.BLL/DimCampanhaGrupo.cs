using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimCampanhaGrupo : IDimCampanhaGrupo
    {
        new DAL.DimCampanhaGrupo campanhaGrupoDAL;

        public DimCampanhaGrupo()
        {
            campanhaGrupoDAL = new DAL.DimCampanhaGrupo();
        }

        public List<DTO.DimCampanhaGrupo> Select()
        {
            return campanhaGrupoDAL.Select();
        }

        public DTO.DimCampanhaGrupo SelectById(int Id)
        {
            return campanhaGrupoDAL.SelectById(Id);
        }

        public void Remover(DTO.DimCampanhaGrupo Entidade)
        {
            campanhaGrupoDAL.Remover(Entidade);
        }

        public void Cadastro(DTO.DimCampanhaGrupo Entidade)
        {
            campanhaGrupoDAL.Cadastro(Entidade);
        }

        public List<DTO.DimCampanhaGrupo> SelectByCampanhaId(int CampanhaId)
        {
            return campanhaGrupoDAL.SelectByCampanhaId(CampanhaId);
        }

        public List<DTO.DimCampanhaGrupo> SelectByGrupoId(int GrupoId)
        {
            return campanhaGrupoDAL.SelectByGrupoId(GrupoId);
        }

        public void ImportaTotalIP()
        {
            string settingGrupo = System.Configuration.ConfigurationManager.AppSettings["Grupo"];
            string settingCampanha = System.Configuration.ConfigurationManager.AppSettings["Campanha"];

            List<int> grupoIds = new List<int>();
            List<int> campanhaIds = new List<int>();

            foreach (string id in settingGrupo.Split(','))
                grupoIds.Add(int.Parse(id.Trim()));

            foreach (string id in settingCampanha.Split(','))
                campanhaIds.Add(int.Parse(id.Trim()));

            for (int i = 0; i < grupoIds.Count; i++)
                for (int j = 0; j < campanhaIds.Count; j++)
                {
                    Cadastro(new DTO.DimCampanhaGrupo()
                    {
                        CampanhaId = campanhaIds[j],
                        GrupoId = grupoIds[i]
                    });
                }

        }
    }
}
