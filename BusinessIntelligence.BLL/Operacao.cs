using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessIntelligence.DTO;

namespace BusinessIntelligence.BLL
{
    public class Operacao
    {
        public List<DTO.AcordoOperador> AcordoOperadorRealizadosDia(int ano, int mes, int dia, int[] usuario_id)
        {
            return new DAL.Operacao().AcordoOperadorRealizadosDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.Acordo> AcordoRealizados(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRealizados(ano, mes, usuario_id);
        }

        public List<DTO.AcordoRecebimentoOperador> AcordoRealizadosDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRealizadosDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.AcordoSintetico> AcordoSintetico(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoSintetico(ano, mes, usuario_id);
        }

        public List<DTO.AcordoPrevisaoRecebimento> AcordoPrevisaoRecebimentoPorCarteira(int ano, int mes, params int[] carteiras_id)
        {
            return new DAL.Operacao().AcordoPrevisaoRecebimentoPorCarteira(ano, mes, carteiras_id);
        }

        public List<DTO.AcordoPrevisaoRecebimento> AcordoPrevisaoRecebimentoPorOperador(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoPrevisaoRecebimentoPorOperador(ano, mes, usuario_id);
        }

        public List<DTO.AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoPorOperadorDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoPrevisaoRecebimentoPorOperadorDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.AcordoQuebra> AcordoQuebras(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoQuebras(ano, mes, usuario_id);
        }

        public List<DTO.AcordoQuebraDia> AcordoQuebrasDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoQuebrasDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordoAnalitico(int ano, int mes, string usuario_id)
        {
            return new DAL.Operacao().AcordoAnalitico(ano, mes, usuario_id);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordoAnaliticoCad(int ano, int mes, string usuario_id)
        {
            return new DAL.Operacao().AcordoAnaliticoCad(ano, mes, usuario_id);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordoAnaliticoQuebra(int ano, int mes, string usuario_id)
        {
            return new DAL.Operacao().AcordoAnaliticoQuebra(ano, mes, usuario_id);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordoAnaliticoPrevisao(int ano, int mes, string usuario_id)
        {
            return new DAL.Operacao().AcordoAnaliticoPrevisao(ano, mes, usuario_id);
        }

        public List<DTO.AcordoRecebimentoOperador> AcordoRecebimentoOperador(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRecebimentoOperador(ano, mes, usuario_id);
        }

        public List<DTO.AcordoRecebimentoOperador> AcordoRecebimentoOperadorDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRecebimentoOperadorDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.AcordoRecebimentoAcumulado> AcordoRecebimentoAcumulado(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRecebimentoAcumulado(ano, mes, usuario_id);
        }

        public List<DTO.AcordoRecebimentoAcumuladoDia> AcordoRecebimentoAcumuladoDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoRecebimentoAcumuladoDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoOperador(int ano, int mes, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoPrevisaoRecebimentoOperador(ano, mes, usuario_id);
        }

        public List<DTO.AcordoPrevisaoRecebimentoOperador> AcordoPrevisaoRecebimentoOperadorDia(int ano, int mes, int dia, params int[] usuario_id)
        {
            return new DAL.Operacao().AcordoPrevisaoRecebimentoOperadorDia(ano, mes, dia, usuario_id);
        }

        public List<DTO.HistoricoClienteAcionamentos> HistoricoLocalizadosXClientes(int ano, int mes, int dia, params int[] usuario_id)
        {
            var localizados = new DAL.Operacao().HistoricoClienteLocalizadoDia(ano, mes, dia);
            var nlocalizados = new DAL.Operacao().HistoricoClienteNaoLocalizadoDia(ano, mes, dia);

            List<DTO.HistoricoCliente> processado = new List<DTO.HistoricoCliente>();
            List<DTO.HistoricoClienteAcionamentos> selecionados = new List<DTO.HistoricoClienteAcionamentos>();

            processado.AddRange(localizados);
            processado.AddRange(nlocalizados);

            var agrupados = processado
                            .GroupBy(l => l.OperadorID)
                            .Select(cl => new DTO.HistoricoCliente
                            {
                                OperadorID = cl.First().OperadorID,
                                NomeOperador = cl.First().NomeOperador,
                                QtdHistorico = cl.Sum(c => c.QtdHistorico),
                            }).OrderBy(c => c.NomeOperador).ToList();

            foreach (var op in usuario_id)
            {
                var usu = agrupados.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();
                var loc = localizados.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();

                if (usu != null && loc != null)
                    selecionados.Add(new DTO.HistoricoClienteAcionamentos() { NomeOperador = usu.NomeOperador, OperadorID = usu.OperadorID, QtdHistorico = loc.QtdHistorico, TotalAcionamentos = usu.QtdHistorico });
                else
                {
                    if (usu != null && loc == null)
                        selecionados.Add(new DTO.HistoricoClienteAcionamentos() { NomeOperador = usu.NomeOperador, OperadorID = usu.OperadorID, QtdHistorico = 0, TotalAcionamentos = usu.QtdHistorico });
                }
            }

            return selecionados;
        }

        public List<DTO.HistoricoClienteAcionamentos> HistoricoContatosXLocalizados(int ano, int mes, int dia, params int[] usuario_id)
        {
            var localizados = new DAL.Operacao().HistoricoClienteLocalizadoDia(ano, mes, dia);
            var positivos = new DAL.Operacao().HistoricoClienteContatosPositivos(ano, mes, dia);

            List<DTO.HistoricoCliente> processado = new List<DTO.HistoricoCliente>();
            List<DTO.HistoricoClienteAcionamentos> selecionados = new List<DTO.HistoricoClienteAcionamentos>();

            processado.AddRange(positivos);

            var agrupados = processado
                            .GroupBy(l => l.OperadorID)
                            .Select(cl => new DTO.HistoricoCliente
                            {
                                OperadorID = cl.First().OperadorID,
                                NomeOperador = cl.First().NomeOperador,
                                QtdHistorico = cl.Sum(c => c.QtdHistorico),
                            }).OrderBy(c => c.NomeOperador).ToList();

            foreach (var op in usuario_id)
            {
                var usu = agrupados.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();
                var loc = localizados.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();

                if (usu != null && loc != null)
                    selecionados.Add(new DTO.HistoricoClienteAcionamentos()
                    {
                        NomeOperador = usu.NomeOperador,
                        OperadorID = usu.OperadorID,
                        QtdHistorico = loc.QtdHistorico,
                        TotalAcionamentos = usu.QtdHistorico
                    });
                else
                {
                    if (usu != null && loc == null)
                        selecionados.Add(new DTO.HistoricoClienteAcionamentos()
                        {
                            NomeOperador = usu.NomeOperador,
                            OperadorID = usu.OperadorID,
                            QtdHistorico = 0,
                            TotalAcionamentos = usu.QtdHistorico
                        });
                }
            }
            return selecionados;
        }

        public List<DTO.HistoricoClienteAcionamentosAcordos> HistoricoAcordosXContatos(int ano, int mes, int dia, params int[] usuario_id)
        {
            var acordos = new DAL.Operacao().AcordoOperadorRealizadosDiaDispersao(ano, mes, dia, usuario_id);
            var positivos = new DAL.Operacao().HistoricoClienteContatosPositivosDia(ano, mes, dia);

            List<DTO.HistoricoCliente> processado = new List<DTO.HistoricoCliente>();
            List<DTO.HistoricoClienteAcionamentosAcordos> selecionados = new List<DTO.HistoricoClienteAcionamentosAcordos>();

            processado.AddRange(positivos);

            var agrupados = processado
                            .GroupBy(l => l.OperadorID)
                            .Select(cl => new DTO.HistoricoCliente
                            {
                                OperadorID = cl.First().OperadorID,
                                NomeOperador = cl.First().NomeOperador,
                                QtdHistorico = cl.Sum(c => c.QtdHistorico),
                            }).OrderBy(c => c.NomeOperador).ToList();

            foreach (var op in usuario_id)
            {
                var usu = agrupados.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();
                var aco = acordos.Where(u => u.OperadorID.Equals(op)).FirstOrDefault();

                if (usu != null && aco != null)
                    selecionados.Add(new DTO.HistoricoClienteAcionamentosAcordos() { NomeOperador = usu.NomeOperador, OperadorID = usu.OperadorID, QtdHistorico = aco.QtdAcordo, TotalAcionamentos = usu.QtdHistorico, TotalAcordos = aco.QtdAcordo });
                else
                {
                    if (usu != null && aco == null)
                        selecionados.Add(new DTO.HistoricoClienteAcionamentosAcordos() { NomeOperador = usu.NomeOperador, OperadorID = usu.OperadorID, QtdHistorico = 0, TotalAcionamentos = usu.QtdHistorico, TotalAcordos = 0 });
                }
            }

            return selecionados;
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoClienteLocalizados(int ano, int mes,int dia, int operador)
        {
            return new DAL.Operacao().AnaliticoHistoricoClienteLocalizados(ano, mes,dia, operador);
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoContatosLocalizados(int ano, int mes,int dia, int operador)
        {
            return new DAL.Operacao().AnaliticoHistoricoContatosLocalizados(ano, mes, dia,operador);
        }

        public List<DTO.OperacaoAnaliticoHistorico> AnaliticoHistoricoAcordosContatos(int ano, int mes, int dia, int operador)
        {
            return new DAL.Operacao().AnaliticoHistoricoAcordosContatos(ano, mes,dia, operador);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordosAnaliticoPrevisaoxPagamentos(int ano, int mes, string operadores)
        {
            return new DAL.Operacao().AcordosAnaliticoPrevisaoxPagamentos(ano, mes, operadores);
        }

        public List<DTO.OperacaoAnaliticoAcordo> AcordoAnaliticoPrevisaoDia(int ano, int mes, int dia, string usuarios)
        {
            return new DAL.Operacao().AcordoAnaliticoPrevisaoDia(ano, mes, dia, usuarios);
        }
    }
}