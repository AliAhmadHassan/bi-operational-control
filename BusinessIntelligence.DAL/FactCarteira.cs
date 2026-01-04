using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.DTO;

namespace BusinessIntelligence.DAL
{
    public class FactCarteira : Conexao
    {
        public List<DTO.CarteiraAnaliticoSituacao> ListarPelaSituacaoID(int ano, int mes, int dia, string situacao, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoSituacao>.Lista(
                "SPSFatoCarteiraPelaSituacao",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Situacao", Value = situacao },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
                });
        }

        public List<CarteiraAnaliticoScoreSerasa> ListarPeloScore(int ano, int mes, int dia, string score, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoScoreSerasa>.Lista(
                "SPSFatoCarteiraPeloScore",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Score", Value = score },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
                });
        }

        public List<CarteiraAnaliticoUF> ListarPelaUF(int ano, int mes, int dia, string uf, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoUF>.Lista(
                "SPSFatoCarteiraPelaUF",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@UF", Value = uf },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
                });
        }

        public List<DTO.CarteiraAnaliticoStatusCobranca> ListarPelaStatusCobrancaID(string statuscobranca, int ano, int mes, int dia, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoStatusCobranca>.Lista(
                "SPSFatoCarteiraPeloStatusCobranca",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Status", Value = statuscobranca },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                     new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
                });
        }

        public List<DTO.CarteiraAnaliticoVencimento> ListarPeloVencimento(int ano, int mes, int dia, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoVencimento>.Lista(
                "SPSFatoAcordoVencimento",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
                });
        }

        public List<CarteiraAnaliticoFaixaValor> ListarPelaFaixaValor(int ano, int mes, int dia, string faixa, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoFaixaValor>.Lista(
               "SPSFatoCarteiraPelaFaixaValor",
               ConnectionStringDW,
               new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                     new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@FaixaValor", Value = faixa},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
               });
        }

        public List<CarteiraAnaliticoFaixaAtraso> ListarPelaFaixaAtraso(int ano, int mes, int dia, string faixa, string credores_id)
        {
            return AuxConsultas<DTO.CarteiraAnaliticoFaixaAtraso>.Lista(
               "SPSFatoCarteiraPelaFaixaAtraso",
               ConnectionStringDW,
               new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@FaixaAtraso", Value = faixa},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores_id}
               });
        }
    }
}
