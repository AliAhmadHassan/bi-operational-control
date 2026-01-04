using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.DTO;

namespace BusinessIntelligence.DAL
{
    public class Producao : Conexao
    {
        public List<DTO.ProducaoHoraHora> ProducaoHoraHora(int ano, int mes, int dia, string operadores)
        {
            return AuxConsultas<DTO.ProducaoHoraHora>.Lista(
                "SPSProducaoHoraHora",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Operadores", Value = operadores}
                });
        }

        public List<ProducaoHoraHora> ProducaoHoraHoraTodosOperadores(int ano, int mes, int dia, string operador)
        {
            return AuxConsultas<DTO.ProducaoHoraHora>.Lista(
                  "SPSProducaoHoraHoraTodosOperadores",
                  ConnectionStringDW,
                  new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Operador", Value = operador}
                  });
        }

        public List<ProducaoHoraHora> ProducaoHoraHoraPorOperador(int ano, int mes, int dia, int hora, int operador)
        {
            return AuxConsultas<DTO.ProducaoHoraHora>.Lista(
               "SPSProducaoHoraHoraPorOperador",
               ConnectionStringDW,
               new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Hora", Value = hora},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Operador", Value = operador}
               });
        }
    }
}
