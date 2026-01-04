using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimHora:IDimHora
    {
        static SortedList<TimeSpan, DTO.DimHora> aux = new SortedList<TimeSpan, DTO.DimHora>();

        public List<DTO.DimHora> Select()
        {
            return new DAL.DimHora().Select();
        }

        public DTO.DimHora SelectById(int Id)
        {
            return new DAL.DimHora().SelectById(Id);
        }

        public void Remover(DTO.DimHora Entidade)
        {
            new DAL.DimHora().Remover(Entidade);
        }

        public void Cadastro(DTO.DimHora Entidade)
        {
            new DAL.DimHora().Cadastro(Entidade);
        }

        public DTO.DimHora SelectByIdHora(DateTime hora)
        {
            TimeSpan auxTime = TimeSpan.FromSeconds((long)hora.TimeOfDay.TotalSeconds);

            if (!aux.ContainsKey(auxTime))
                aux.Add(auxTime, new DAL.DimHora().SelectByIdHora(hora));

            return aux[auxTime];
        }
    }
}
