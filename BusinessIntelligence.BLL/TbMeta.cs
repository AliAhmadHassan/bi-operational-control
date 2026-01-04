using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class TbMeta
    {
        public void Incluir(DTO.TbMeta meta)
        {
            new DAL.TbMeta().Incluir(meta);
        }

        public void Atualizar(DTO.TbMeta meta)
        {
            new DAL.TbMeta().Atualizar(meta);
        }

        public void Deletar(int usuario_id)
        {
            new DAL.TbMeta().Deletar(usuario_id);
        }

        public List<DTO.TbMeta> Listar(string operadores)
        {
            return new DAL.TbMeta().Listar(operadores);
        }

    }
}
