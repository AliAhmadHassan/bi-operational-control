using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimUsuario : IDimUsuario
    {
        DAL.DimUsuario usuarioDAO;

        public DimUsuario()
        {
            usuarioDAO = new DAL.DimUsuario();
        }

        public List<DTO.DimUsuario> Select()
        {
            return usuarioDAO.Select();
        }

        public DTO.DimUsuario SelectById(int Id)
        {
            return usuarioDAO.SelectById(Id);
        }

        public DTO.DimUsuario SelectByCobnetId(int id)
        {
            return new DAL.DimUsuario().SelectByCobnetId(id);
        }

        public void Remover(DTO.DimUsuario Entidade)
        {
            usuarioDAO.Remover(Entidade);
        }

        public void Cadastro(DTO.DimUsuario Entidade)
        {
            usuarioDAO.Cadastro(Entidade);
        }

        public List<DTO.DimUsuario> SelectByGrupoId(int GrupoId)
        {
            return usuarioDAO.SelectByGrupoId(GrupoId);
        }

        public void ImportaTotalIP()
        {
            string settingGrupo = System.Configuration.ConfigurationManager.AppSettings["Grupo"];
            string settingCredor = System.Configuration.ConfigurationManager.AppSettings["Credor"];

            List<int> grupoIds = new List<int>();


            foreach (string id in settingGrupo.Split(','))
                grupoIds.Add(int.Parse(id.Trim()));

            List<DTO.Discador.TotalIP.Usuarios> TotalIPUsuarios = new BLL.Discador.TotalIP.Usuarios().getByArrayIdGrupos(grupoIds);

            foreach (DTO.Discador.TotalIP.Usuarios usuarioTotalIp in TotalIPUsuarios)
            {
                Cadastro(new DTO.DimUsuario()
                {
                    UsuarioId = usuarioTotalIp.id,
                    CobNetUsId = int.Parse(usuarioTotalIp.nome.Split('-')[0].Trim()),
                    Nome = usuarioTotalIp.nome.Split('-')[1].Trim(),
                    Ramal = usuarioTotalIp.ramal,
                    GrupoId = grupoIds.FirstOrDefault()
                });
            }

        }
    }
}
