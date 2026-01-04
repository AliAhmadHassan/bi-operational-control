using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbFeriado
    {
        public void Incluir(DTO.TbFeriado feriado)
        {
            new DAL.TbFeriado().Incluir(feriado);
        }

        public void Atualizar(DTO.TbFeriado feriado)
        {
            new DAL.TbFeriado().Atualizar(feriado);
        }

        public void Deletar(int feriado_id)
        {
            new DAL.TbFeriado().Deletar(feriado_id);
        }

        public List<DTO.TbFeriado> Listar()
        {
            return new DAL.TbFeriado().Listar();
        }

        public DTO.TbFeriado ListarPeloId(int feriado_id)
        {
            return new DAL.TbFeriado().ListarPeloId(feriado_id);
        }
    }
}
