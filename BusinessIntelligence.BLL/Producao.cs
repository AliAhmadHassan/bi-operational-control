using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class Producao
    {
        public List<DTO.ProducaoHoraHora> ProducaoHoraHora(int ano, int mes, int dia, string operadores)
        {
            return new DAL.Producao().ProducaoHoraHora(ano, mes, dia, operadores);
        }

        public List<DTO.ProducaoHoraHora> ProducaoHoraHoraPorOperador(int ano, int mes, int dia, int hora, int operador)
        {
            return new DAL.Producao().ProducaoHoraHoraPorOperador(ano, mes, dia, hora, operador);
        }
        public List<DTO.ProducaoHoraHora> ProducaoHoraHoraTodosOperadores(int ano, int mes, int dia, string operador)
        {
            return new DAL.Producao().ProducaoHoraHoraTodosOperadores(ano, mes, dia, operador);
        }
    }
}