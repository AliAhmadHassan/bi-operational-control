using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.DTO;

namespace BusinessIntelligence.DAL
{
    public class ParqueGrafico : Conexao
    {
        public List<DTO.ParqueGraficoPivotFaixaAtrasoValor> ParqueGraficoPivotFaixaAtrasoValor(int ano, int mes, params int[] carteira_id)
        {
            string query = @" Select
	                        non empty crossjoin(
		                        [Dim Faixa Atraso].[Faixa Dois].[Faixa Dois],
		                        [Faixa Valor Id Saldo].[Faixa Dois].[Faixa Dois]
	                        )on rows,
	                        {
		                        [Measures].[Quantidade Boletos],
		                        [Measures].[Quantidade Pagamentos],
		                        [Measures].[Valor Pago], [Measures].[Eficiencia]
	                        }on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoPivotFaixaAtrasoValor>(cmd.ExecuteCellSet());

        }

        public List<DTO.ParqueGraficoVencimento> ParqueGraficoVencimento(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Vencimento].[Data].[Data]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoVencimento>(cmd.ExecuteCellSet());

        }

        public List<ParqueGraficoGerados> ParqueGraficoGerado(int ano, int mes, int[] carteira_id)
        {
            string query = @"Select NON Empty{[Cadastro].[Data].[Data]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Cadastro].[Ano].&[" + ano.ToString() + "] , [Cadastro].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoGerados>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoPesquisaEletronica> ParqueGraficoPesquisaEletronica(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Tratado Por].[Tratado Por].[Tratado Por]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoPesquisaEletronica>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoTipoEndereco> ParqueGraficoTipoEndereco(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Tipo Endereco].[Tipo Endereco].[Tipo Endereco]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                         where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoTipoEndereco>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoFaixaAtraso> ParqueGraficoFaixaAtraso(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Faixa Atraso].[Faixa Um].[Faixa Um]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago] 
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoFaixaAtraso>(cmd.ExecuteCellSet());

        }

        public List<DTO.ParqueGraficoFaixaValorSaldo> ParqueGraficoFaixaValorSaldo(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Faixa Valor Id Saldo].[Faixa Um].[Faixa Um]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoFaixaValorSaldo>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoFaixaValorPago> ParqueGraficoFaixaValorPago(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Faixa Valor Id Pago].[Faixa Um].[Faixa Um]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Dt Pagamento].[Ano].&[" + ano.ToString() + "] , [Dt Pagamento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoFaixaValorPago>(cmd.ExecuteCellSet());

        }

        public List<DTO.ParqueGraficoScoreSerasa> ParqueGraficoScoreSerasa(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Serasa].[Faixa Um].[Faixa Um]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoScoreSerasa>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoRegraParqueGrafico> ParqueGraficoRegraParqueGrafico(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Regra Parque Grafico].[Regra Parque Grafico Id].[Regra Parque Grafico Id]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoRegraParqueGrafico>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoProduto> ParqueGraficoProtudo(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim Produto].[Produto].[Produto]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoProduto>(cmd.ExecuteCellSet());
        }

        public List<DTO.ParqueGraficoUF> ParqueGraficoUF(int ano, int mes, params int[] carteira_id)
        {
            string query = @"Select NON Empty{[Dim CEP].[UF].[UF]} on rows,
	                         {[Measures].[Quantidade Boletos]
	                        , [Measures].[Quantidade Pagamentos]
	                        , [Measures].[Valor Pago]
                            , [Measures].[Eficiencia]} on columns
                        from CubeParqueGrafico
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] ,{";

            foreach (var c in carteira_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                return AuxiliarParse.RetornaDadosEntidade<DTO.ParqueGraficoUF>(cmd.ExecuteCellSet());

        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaDataCadastro(int ano, int mes, int dia, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPelaDataCadastro",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaDataVencimento(int ano, int mes, int dia, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloDiaVencimento",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaRegraParqueGrafico(int ano, int mes, string regra, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPelaRegra",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Regra", Value = regra},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloTipoEndereco(int ano, int mes, string tipoendereco, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloTipoEndereco",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@TipoEndereco", Value = tipoendereco},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloTratadoPor(int ano, int mes, string tratadopor, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloTratadoPor",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@TratadoPor", Value = tratadopor},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaFaixaAtraso(int ano, int mes, string faixaatraso, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPelaFaixaAtraso",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@FaixaAtraso", Value = faixaatraso},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaFaixaValor(int ano, int mes, string faixavalor, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPelaFaixaValor",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@FaixaValor", Value = faixavalor},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloDiaVencimento(int ano, int mes, int dia, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloDiaVencimento",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloScore(int ano, int mes, string score, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloScore",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Score", Value = score},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloProduto(int ano, int mes, string produto, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPeloProduto",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Produto", Value = produto},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaUF(int ano, int mes, string uf, string credores)
        {
            return AuxConsultas<DTO.ParqueGraficoAnalitico>.Lista(
              "SPSFatoParqueGraficoPelaUF",
              ConnectionStringDW,
              new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@UF", Value = uf},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Credor", Value = credores}
              });
        }
    }
}