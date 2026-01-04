using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoCobranca
    {
        public int Cadastrar(DTO.TbGrupoCobranca grupocobranca)
        {
            return new DAL.TbGrupoCobranca().Cadastrar(grupocobranca);
        }

        public void Deletar(int id)
        {
            new DAL.TbGrupoCobranca().Deletar(id);
        }

        public void Atualizar(DTO.TbGrupoCobranca grupocobranca)
        {
            new DAL.TbGrupoCobranca().Atualizar(grupocobranca);
        }

        public DTO.TbGrupoCobranca SelecionarPeloId(int id)
        {
            return new DAL.TbGrupoCobranca().SelecionarPeloId(id);
        }

        public List<DTO.TbGrupoCobranca> Listar()
        {
            return new DAL.TbGrupoCobranca().Listar();
        }
    }
}