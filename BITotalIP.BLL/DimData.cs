using BITotalIP.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.BLL
{
    public class DimData:IDimData
    {
        static SortedList<DateTime, DTO.DimData> aux = new SortedList<DateTime, DTO.DimData>();

        public List<DTO.DimData> Select()
        {
            return new DAL.DimData().Select();
        }

        public DTO.DimData SelectById(int Id)
        {
            return new DAL.DimData().SelectById(Id);
        }

        public void Remover(DTO.DimData Entidade)
        {
            new DAL.DimData().Remover(Entidade);
        }

        public void Cadastro(DTO.DimData Entidade)
        {
            new DAL.DimData().Cadastro(Entidade);
        }

        public DTO.DimData SelectByData(DateTime Data)
        {
            if (!aux.ContainsKey(Data.Date))
                aux.Add(Data.Date, new DAL.DimData().SelectByData(Data));

            return aux[Data.Date];
        }
    }
}
