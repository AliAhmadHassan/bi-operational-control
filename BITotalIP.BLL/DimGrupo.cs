using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimGrupo:IDimGrupo
    {
        DAL.DimGrupo grupoDAL;

        public DimGrupo()
        {
            grupoDAL = new DAL.DimGrupo();
        }

        public List<DTO.DimGrupo> Select()
        {
            return grupoDAL.Select();
        }

        public DTO.DimGrupo SelectById(int Id)
        {
            return grupoDAL.SelectById(Id);
        }

        public void Remover(DTO.DimGrupo Entidade)
        {
            grupoDAL.Remover(Entidade);
        }

        public void Cadastro(DTO.DimGrupo Entidade)
        {
            grupoDAL.Cadastro(Entidade);
        }

        public List<DTO.DimGrupo> SelectByCredorId(int CredorId)
        {
            return grupoDAL.SelectByCredorId(CredorId);
        }

        public void ImportaTotalIP()
        {
            string settingGrupo = System.Configuration.ConfigurationManager.AppSettings["Grupo"];
            int settingCredor = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Credor"]);

            List<int> grupoIds = new List<int>();

            foreach (string id in settingGrupo.Split(','))
                grupoIds.Add(int.Parse(id.Trim()));

            foreach (var item in new DAL.Discador.TotalIP.Grupos().getByArrayIdGrupos(grupoIds))
            {

                Cadastro(new DTO.DimGrupo()
                {
                    GrupoId = item.id,
                    Nome = item.nome,
                    CredorId = settingCredor
                });
            }
        }
    }
}
