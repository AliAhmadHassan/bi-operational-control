using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.DTO;

namespace BusinessIntelligence.DAL
{
    public class Operacao : Conexao
    {
        public List<DTO.AcordoSintetico> AcordoSintetico(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Vencimento].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoSintetico>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoSintetico>();
        }

        public List<AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoPorOperadorDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                         [Measures].[Valor Acordo], 
	                         [Measures].[Valor Parcela],
	                         [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "],[Vencimento].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {

                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoPrevisaoRecebimentoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoPrevisaoRecebimentoOperador>();
        }

        public List<AcordoQuebraDia> AcordoQuebrasDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                         where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],[Vencimento].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {

                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoQuebraDia>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoQuebraDia>();
        }

        public List<AcordoRecebimentoOperador> AcordoRealizadosDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                       where ([Cadastro].[Ano].&[" + ano.ToString() + "], [Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Cadastro].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoRecebimentoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoRecebimentoOperador>();
        }

        public List<AcordoOperadorDia> AcordoOperadorRealizadosDiaDispersao(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select
                            non empty crossjoin({";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "}";

            query += @",[Dim Usuario].[Nome].[Nome]
                            )on rows,
                            {
                                [Measures].[Fact Acordo Count],
                                [Measures].[Valor Acordo],
                                [Measures].[Valor Parcela],
                                [Measures].[Vl Pago]
                            }on columns
                            from CubeAcordo
                       where ([Cadastro].[Ano].&[" + ano.ToString() + "], [Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Cadastro].[Dia Mes].&[" + dia.ToString() + "])";


            int tentativa = 0;
            do
            {
                try
                {

                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoOperadorDia>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoOperadorDia>();
        }

        public List<AcordoOperador> AcordoOperadorRealizadosDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                       where ([Cadastro].[Ano].&[" + ano.ToString() + "], [Cadastro].[Mes Numero].&[" + mes.ToString() + "],[Cadastro].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;

            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoOperador>();
        }

        public List<OperacaoAnaliticoAcordo> AcordoAnalitico(int ano, int mes, string usuario_id)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloUsuarioData",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = usuario_id}
                });
        }

        public List<OperacaoAnaliticoAcordo> AcordoAnaliticoCad(int ano, int mes, string usuario_id)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloUsuarioDataCadastro",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = usuario_id}
                });
        }

        public List<OperacaoAnaliticoAcordo> AcordoAnaliticoQuebra(int ano, int mes, string usuario_id)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloUsuarioDataPrevisao",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = usuario_id}
                });
        }

        public List<AcordoRecebimentoOperador> AcordoRecebimentoOperadorDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                       where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],[Vencimento].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoRecebimentoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoRecebimentoOperador>();
        }

        public List<AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoOperadorDia(int ano, int mes, int dia, int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                         where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],[Vencimento].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;

            do
            {
                try
                {

                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoPrevisaoRecebimentoOperador>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoPrevisaoRecebimentoOperador>();
        }

        public List<OperacaoAnaliticoAcordo> AcordoAnaliticoPrevisao(int ano, int mes, string usuario_id)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloUsuarioDataPrevisao",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = usuario_id}
                });
        }

        public List<DTO.AcordoPrevisaoRecebimento> AcordoPrevisaoRecebimentoPorCarteira(int ano, int mes, params int[] carteiras_id)
        {
            string query = @"Select NON Empty{[Vencimento].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                         [Measures].[Valor Acordo], 
	                         [Measures].[Valor Parcela],
	                         [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                        where (
                                    [Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "] , Except([Dim Usuario].[Usuario ID].[Usuario ID].members, [Dim Usuario].[Usuario ID].[Usuario ID].&[909]),{";

            foreach (var c in carteiras_id)
                query += "[Credor].[Credor].&[" + c.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoPrevisaoRecebimento>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoPrevisaoRecebimento>();
        }

        public List<OperacaoAnaliticoAcordo> AcordoAnaliticoPrevisaoDia(int ano, int mes, int dia, string usuarios)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
               "SPSFatoAcordoPeloUsuarioDataPrevisaoDia",
               ConnectionStringDW,
               new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = usuarios}
               });
        }

        public List<DTO.AcordoPrevisaoRecebimento> AcordoPrevisaoRecebimentoPorOperador(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Vencimento].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                         [Measures].[Valor Acordo], 
	                         [Measures].[Valor Parcela],
	                         [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                        where ([Vencimento].[Ano].&[" + ano.ToString() + "] , [Vencimento].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoPrevisaoRecebimento>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoPrevisaoRecebimento>();
        }

        public List<DTO.AcordoQuebra> AcordoQuebras(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Vencimento].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                         where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoQuebra>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<AcordoQuebra>();
        }

        public List<DTO.Acordo> AcordoRealizados(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Cadastro].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                       where ([Cadastro].[Ano].&[" + ano.ToString() + "], [Cadastro].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.Acordo>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 0);

            return new List<Acordo>();
        }

        public List<DTO.AcordoRecebimentoOperador> AcordoRecebimentoOperador(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                       where ([Dt Pgto].[Ano].&[" + ano.ToString() + "], [Dt Pgto].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoRecebimentoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoRecebimentoOperador>();
        }

        public List<DTO.AcordoRecebimentoAcumuladoDia> AcordoRecebimentoAcumuladoDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
                                {[Measures].[Fact Acordo Count], 
                                [Measures].[Valor Acordo], 
                                [Measures].[Valor Parcela],
                                [Measures].[Vl Pago]} on columns
                            from CubeAcordo
                            where ([Dt Pgto].[Ano].&[" + ano.ToString() + "], [Dt Pgto].[Mes Numero].&[" + mes.ToString() + "],[Dt Pgto].[Dia Mes].&[" + dia.ToString() + "], {";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoRecebimentoAcumuladoDia>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }

            } while (tentativa < 3);

            return new List<DTO.AcordoRecebimentoAcumuladoDia>();
        }

        public List<DTO.AcordoRecebimentoAcumulado> AcordoRecebimentoAcumulado(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dt Pgto].[Data].[Data]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                        where ([Dt Pgto].[Ano].&[" + ano.ToString() + "], [Dt Pgto].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoRecebimentoAcumulado>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoRecebimentoAcumulado>();
        }

        public List<DTO.AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoOperador(int ano, int mes, params int[] usuario_id)
        {
            string query = @"Select NON Empty{[Dim Usuario].[Nome].[Nome]} on rows,
	                        {[Measures].[Fact Acordo Count], 
	                        [Measures].[Valor Acordo], 
	                        [Measures].[Valor Parcela],
	                        [Measures].[Vl Pago]} on columns
                        from CubeAcordo
                         where ([Vencimento].[Ano].&[" + ano.ToString() + "], [Vencimento].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in usuario_id)
                query += "[Dim Usuario].[Usuario ID].[Usuario ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.AcordoPrevisaoRecebimentoOperador>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.AcordoPrevisaoRecebimentoOperador>();

        }

        public List<DTO.HistoricoCliente> HistoricoClienteLocalizadoDia(int ano, int mes, int dia)
        {

            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where (
                                                [Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Cliente Localizado].&[True])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                } 
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteLocalizado(int ano, int mes, int dia)
        {

            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Ocorrencia].[Cliente Localizado].&[True])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                } 
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteNaoLocalizadoDia(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Cliente Localizado].&[False])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                } 
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteNaoLocalizado(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Cliente Localizado].&[False])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteContatosPositivos(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Contato Positivo].&[True])";
            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteContatosPositivosDia(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Contato Positivo].&[True])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteContatosNaoPositivos(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Contato Positivo].&[False])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteContatosNaoPositivosDia(int ano, int mes, int dia)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],[Dim Ocorrencia].[Contato Positivo].&[False])";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteAcordos(int ano, int mes, params int[] ocorrencias_id)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],{";

            foreach (var u in ocorrencias_id)
                query += "[Dim Ocorrencia].[Ocorrencia ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch 
                {
                    tentativa++;
                } 
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.HistoricoCliente> HistoricoClienteAcordosDia(int ano, int mes, int dia, params int[] ocorrencias_id)
        {
            string query = @"Select NON Empty(
					                        [Dim Usuario].[Usuario ID].[Usuario ID],[Dim Usuario].[Nome].[Nome]
			                            ) on rows,
	                            {[Measures].[Fact Historico Count]} on columns
                            from CubeHistorico
                                    where ([Dim Data].[Ano].&[" + ano.ToString() + "], [Dim Data].[Mes Numero].&[" + mes.ToString() + "],[Dim Data].[Dia Mes].&[" + dia.ToString() + "],{";

            foreach (var u in ocorrencias_id)
                query += "[Dim Ocorrencia].[Ocorrencia ID].&[" + u.ToString() + "],";

            query = query.Remove(query.LastIndexOf(','), 1);
            query += "});";

            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexao.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.HistoricoCliente>(cmd.ExecuteCellSet());
                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<HistoricoCliente>();
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordosAnaliticos(int ano, int mes, int dia, string operadores)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloUsuarioData",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = operadores}
                });
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordosAnaliticoPrevisaoxPagamentos(int ano, int mes, string operadores)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoAcordo>.Lista(
                "SPSFatoAcordoPeloPrevisaoxPagamento",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuarios", Value = operadores}
                });
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoClienteLocalizados(int ano, int mes, int dia, int operador)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoHistorico>.Lista(
                "SPSFatoHistoricoLocalizadoCliente",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuario", Value = operador}
                });
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoContatosLocalizados(int ano, int mes, int dia, int operador)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoHistorico>.Lista(
                "SPSFatoHistoricoContatoLocalizado",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuario", Value = operador}
                });
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoAcordosContatos(int ano, int mes, int dia, int operador)
        {
            return AuxConsultas<DTO.OperacaoAnaliticoHistorico>.Lista(
                "SPSFatoHistoricoAcordosContatos",
                ConnectionStringDW,
                new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Ano", Value = ano },
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Mes", Value = mes},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Dia", Value = dia},
                    new System.Data.SqlClient.SqlParameter{ParameterName = "@Usuario", Value = operador}
                });
        }
    }
}
