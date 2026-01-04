using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class Carteira : Conexao
    {
        public List<DTO.CarteiraFaixaValor> CarteiraFaixaValor(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato],
	                                [Measures].[Devedor Id Count]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraFaixaValor>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraFaixaValor>();
        }

        public List<DTO.CarteiraFaixaAtraso> CarteiraFaixaAtraso(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Atraso].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato],
	                                [Measures].[Devedor Id Count]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraFaixaAtraso>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraFaixaAtraso>();
        }

        public List<DTO.CarteiraSituacao> CarteiraSituacao(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Situacao].[Situacao Id].[Situacao Id]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                 [Measures].[Saldo Contrato],
	                                 [Measures].[Devedor Id Count]} on columns
                               from CubeCarteira
                               where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraSituacao>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraSituacao>();
        }

        public List<DTO.CarteiraUF> CarteiraUF(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim CEP].[UF].[UF]) on rows,
	                                {[Measures].[Fact Carteira Count]
	                                ,[Measures].[Saldo Contrato]
	                                ,[Measures].[Devedor Id Count]} on columns
                              from CubeCarteira
                              where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "]  ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraUF>(cmd.ExecuteCellSet());
                }
                catch
                {

                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraUF>();

        }

        public List<DTO.CarteiraMarcacao> CarteiraMarcacao(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                              where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "]  ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraMarcacao>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraMarcacao>();
        }

        public List<DTO.CarteiraEnquete> CarteiraEnquete(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "]  ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraEnquete>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraEnquete>();
        }

        public List<DTO.CarteiraOrigemPagamento> CarteiraOrigemPagamento(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                              where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "]  ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraOrigemPagamento>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraOrigemPagamento>();
        }

        public List<DTO.CarteiraPlanoAderencia> CarteiraPlanoAderencia(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                              where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "]  ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraPlanoAderencia>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraPlanoAderencia>();
        }

        public List<DTO.CarteiraStatusCobranca> CarteiraStatusCobranca(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Status Cobranca].[Status Cobranca Id].[Status Cobranca Id]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato],
	                                [Measures].[Devedor Id Count]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraStatusCobranca>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraStatusCobranca>();
        }

        public List<DTO.CarteiraPrevisaoRecebimento> CarteiraPrevisaoRecebimento(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraPrevisaoRecebimento>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraPrevisaoRecebimento>();
        }

        public List<DTO.CarteiraPreventivo> CarteiraPreventivo(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";
            int tentativa = 0;

            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraPreventivo>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);
            return new List<DTO.CarteiraPreventivo>();
        }

        public List<DTO.CarteiraQuebras> CarteiraQuebras(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                              where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";
            int tentativa = 0;

            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraQuebras>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa > 3);
            return new List<DTO.CarteiraQuebras>();
        }

        public List<DTO.CarteiraScore> CarteiraScore(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Serasa].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato], [Measures].[Devedor Id Count]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";
            int tentativa = 0;

            do
            {

                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraScore>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa > 3);
            return new List<DTO.CarteiraScore>();
        }

        public List<DTO.CarteiraLocal> CarteiraLocal(int ano, int mes, int dia, params int[] carteiras_id)
        {
            string query = @"Select NON Empty([Dim Faixa Valor].[Faixa Um].[Faixa Um]) on rows,
	                                {[Measures].[Fact Carteira Count], 
	                                [Measures].[Saldo Contrato]} on columns
                              from CubeCarteira
                             where ([Data Cadastro].[Ano].&[" + ano.ToString() + "], [Data Cadastro].[Mes Numero].&[" + mes.ToString() + "] ,[Data Cadastro].[Dia Mes].&[" + dia.ToString() + "] ,{";

            foreach (var c in carteiras_id)
            {
                query += "[Credor].[Credor].&[" + c.ToString() + "],";
            }

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.CarteiraLocal>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.CarteiraLocal>();
        }

    }
}