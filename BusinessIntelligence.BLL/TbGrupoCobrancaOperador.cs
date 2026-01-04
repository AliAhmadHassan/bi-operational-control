using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbGrupoCobrancaOperador
    {
        public void Cadastrar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            new DAL.TbGrupoCobrancaOperador().Cadastrar(grupocobranca);
        }

        public void Deletar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            new DAL.TbGrupoCobrancaOperador().Deletar(grupocobranca);
        }

        public void Atualizar(DTO.TbGrupoCobrancaOperador grupocobranca)
        {
            new DAL.TbGrupoCobrancaOperador().Atualizar(grupocobranca);
        }

        public List<DTO.TbGrupoCobrancaOperador> SelecionarPeloGrupoCrobrancaId(int id)
        {
            return new DAL.TbGrupoCobrancaOperador().SelecionarPeloGrupoCrobrancaId(id);
        }

        public List<DTO.TbGrupoCobrancaOperador> SelecionarPeloGrupoOperadorId(int id)
        {
            return new DAL.TbGrupoCobrancaOperador().SelecionarPeloGrupoOperadorId(id);
        }
    }
}
