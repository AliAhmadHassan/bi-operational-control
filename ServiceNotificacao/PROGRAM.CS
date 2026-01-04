using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ServiceNotification.DTO;
using System.Configuration;

namespace ServiceNotification
{
    class Program
    {
        static DTO.AnalisarPausas analisePausas = new AnalisarPausas();

        static ServiceNotification.BLL.DimUsuarioStatus dimUsuarioStatusService = new ServiceNotification.BLL.DimUsuarioStatus();
        static ServiceNotification.BLL.DimUsuario dimUsuarioService = new ServiceNotification.BLL.DimUsuario();

        static Timer timeAnalisaPausa = new Timer(1000 * 20);
        static Timer timeAnaliseAtraso_Falta_Saida_Antecipada = new Timer(1000 * 60 * 10);
        static ServiceSerializer serviceSerializer = new ServiceSerializer();

        static int BI_GrupoCobrancaId = int.Parse(System.Configuration.ConfigurationManager.AppSettings["BI.GrupoCobrancaId"]);

        static void Main(string[] args)
        {
            Console.Title = "Serviço de notificação de Pausas do B.I - Versão: " + ConfigurationManager.AppSettings["versao"] + " - Discador.Grupo: " + ConfigurationManager.AppSettings["Discador.Grupo"] + " - BI.GrupoCobrancaId: " + ConfigurationManager.AppSettings["BI.GrupoCobrancaId"];
            Console.ForegroundColor = ConsoleColor.Green;
           
            if (serviceSerializer.ExisteArquivo())
                analisePausas = new ServiceSerializer().Deserializer();

            timeAnalisaPausa.Elapsed += TimeAnalisaPausa_Elapsed;
            timeAnaliseAtraso_Falta_Saida_Antecipada.Elapsed += TimeAnaliseAtraso_Falta_Saida_Antecipada_Elapsed;

            timeAnalisaPausa.Start();
            timeAnaliseAtraso_Falta_Saida_Antecipada.Start();

            OutputLogs("Serviço de notificação iniciado com sucesso.".ToUpper(), "info");

            while (true)
                System.Threading.Thread.Sleep(1000);
        }

        static void OutputLogs(string msg, string tipo)
        {
            Console.Out.WriteLine("[{0}] - [{1}] - {2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff"), tipo.ToUpper(), msg);
        }

        private static void TimeAnaliseAtraso_Falta_Saida_Antecipada_Elapsed(object sender, ElapsedEventArgs e)
        {
            OutputLogs("TimeAnaliseAtraso_Falta_Saida_Antecipada_Elapsed", "info");

            timeAnaliseAtraso_Falta_Saida_Antecipada.Enabled = false;
            try
            {
                AnalisaAtraso_Falta_Saida_Antecipada();
            }
            catch (Exception ex)
            {
                OutputLogs(ex.Message + ex.StackTrace, "erro");
            }
            finally
            {
                timeAnaliseAtraso_Falta_Saida_Antecipada.Enabled = true;
            }
        }

        private static void TimeAnalisaPausa_Elapsed(object sender, ElapsedEventArgs e)
        {
            OutputLogs("INÍCIO -".PadRight(80, '-'), "info");
            OutputLogs("TimeAnalisaPausa_Elapsed", "info");
            timeAnalisaPausa.Enabled = false;
            try
            {
                AnalisaFilaPausas();
            }
            catch (Exception ex)
            {
                OutputLogs(ex.Message + ex.StackTrace, "erro");
            }
            finally
            {
                OutputLogs("FIM -".PadRight(80, '-'), "info");
                OutputLogs("", "info");
                timeAnalisaPausa.Enabled = true;
            }
        }

        private static void AnalisaAtraso_Falta_Saida_Antecipada()
        {
            OutputLogs("AnalisaAtraso_Falta_Saida_Antecipada", "info");
            var usuarios = dimUsuarioService.getLista();

            #region MyRegion
            foreach (ServiceNotification.DTO.DimUsuario usuario in usuarios)
            {
                #region MyRegion
                if (!usuario.NotificadoAtraso)
                    if (DateTime.Now.TimeOfDay > usuario.InicioExpediente.Add(TimeSpan.FromMinutes(10)))
                        if (analisePausas.Count(c => c.UsuarioId.Equals(usuario.UsuarioId)) == 0)
                        {
                            usuario.NotificadoAtraso = true;
                            InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Atraso_SemLogin, usuario.UsuarioId);
                        }
                #endregion

                #region MyRegion
                if (!usuario.NotificadoFalta)
                    if (DateTime.Now.TimeOfDay > usuario.FimExpediente)
                    {
                        if (analisePausas.Count(c => c.UsuarioId.Equals(usuario.UsuarioId)) == 0)
                        {
                            usuario.NotificadoFalta = true;
                            InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Falta, usuario.UsuarioId);
                        }
                    }
                #endregion

                #region MyRegion
                if (!usuario.NotificadoPausasObrigatorias)
                    if (DateTime.Now.TimeOfDay < usuario.FimExpediente.Add(-TimeSpan.FromMinutes(20)))
                    {

                        foreach (var item in analisePausas.Where(c => c.UsuarioId.Equals(usuario.UsuarioId)))
                        {

                            var dimUsuarioStatus = dimUsuarioStatusService.getById(item.UsuarioStatusId);

                            if (dimUsuarioStatus.Obrigatorio)
                            {
                                if (item.TotalPausa < dimUsuarioStatus.Inicio)
                                {
                                    usuario.NotificadoPausasObrigatorias = true;

                                    BusinessIntelligence.DTO.EnumTbNotificacaoTipo enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.NaoDefinido;
                                    switch (item.UsuarioStatusId)
                                    {
                                        case 51:
                                            enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa10;
                                            break;

                                        case 58:
                                            enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa20;
                                            break;

                                        case 61:
                                            enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Segunda_Pausa10;
                                            break;

                                    }
                                    InsereNotificacao(enumTbNotificacaoTipo, usuario.UsuarioId);
                                }
                            }
                        }
                    }
                #endregion

                #region MyRegion
                if (!usuario.NotificadoDeslogado)
                    if (DateTime.Now.TimeOfDay < usuario.FimExpediente.Add(-TimeSpan.FromMinutes(10)))
                    {
                        TimeSpan HoraDeslogado = new TimeSpan();
                        TimeSpan HoraLogado = new TimeSpan();

                        var usu_p_deslog = analisePausas.Where(c => c.UsuarioId.Equals(usuario.UsuarioId) && c.UsuarioStatusId.Equals(2)).FirstOrDefault();
                        if (usu_p_deslog != null)
                            HoraDeslogado = usu_p_deslog.Hora;

                        var usu_p_log = analisePausas.Where(c => c.UsuarioId.Equals(usuario.UsuarioId) && c.UsuarioStatusId.Equals(1)).FirstOrDefault();
                        if (usu_p_log != null)
                            HoraLogado = analisePausas.Where(c => c.UsuarioId.Equals(usuario.UsuarioId) && c.UsuarioStatusId.Equals(1)).FirstOrDefault().Hora;

                        if (HoraDeslogado > HoraLogado)
                        {
                            if (DateTime.Now.TimeOfDay > HoraDeslogado.Add(TimeSpan.FromMinutes(15)))
                            {
                                usuario.NotificadoDeslogado = true;
                                InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo.QuinzeMinDeslogado, usuario.UsuarioId);
                            }
                        }
                    }

                #endregion

                #region MyRegion
                if (!usuario.NotificadoSaidaAntecipado)
                    if (DateTime.Now.TimeOfDay > usuario.FimExpediente.Add(TimeSpan.FromHours(1)))
                    {
                        TimeSpan HoraDeslogado = new TimeSpan();
                        var usu_p_deslog = analisePausas.Where(c => c.UsuarioId.Equals(usuario.UsuarioId) && c.UsuarioStatusId.Equals(2)).FirstOrDefault();
                        if (usu_p_deslog != null)
                            HoraDeslogado = usu_p_deslog.Hora;

                        if (HoraDeslogado < usuario.FimExpediente.Add(-TimeSpan.FromMinutes(10)))
                        {
                            usuario.NotificadoSaidaAntecipado = true;
                            InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo.SaidaAntecipada, usuario.UsuarioId);

                        }
                    }
                #endregion
            }
            #endregion
           
            serviceSerializer.Serializer(analisePausas);

        }

        private static void AnalisaFilaPausas()
        {
            OutputLogs("AnalisaFilaPausas", "info");
            ServiceNotification.BLL.FactPausa servicoPausa = new BLL.FactPausa();

            //Obter todos os registros de pausa da fila :private$\NotificacaoPausa
            //List<ServiceNotification.DTO.FactPausa> lista = new ServiceNotification.BLL.FactPausa().getResult();

            DTO.FactPausa factPausa = servicoPausa.getNext();

            //Percorre as pausas para validar seus valores
            while (factPausa != null)
            {
                try
                {
                    //verifica se a pausa já está na fila de analise de pausa
                    DTO.AnalisePausaModel analisePausa = analisePausas.Where(c => c.UsuarioId.Equals(factPausa.UsuarioId) && c.UsuarioStatusId.Equals(factPausa.UsuarioStatusId)).FirstOrDefault();
                    DimUsuario usuario = dimUsuarioService.getById(factPausa.UsuarioId);

                    //se não estiver, inclui na fila
                    if (analisePausa == null)
                    {
                        analisePausa = new DTO.AnalisePausaModel();
                        analisePausa.DataId = factPausa.DataId;
                        analisePausa.HoraId = factPausa.HoraId;
                        analisePausa.InicioPausa = DateTime.Now;
                        analisePausa.PausaId = factPausa.PausaId;
                        analisePausa.UsuarioId = factPausa.UsuarioId;
                        analisePausa.UsuarioStatusId = factPausa.UsuarioStatusId;
                        analisePausa.Hora = factPausa.Hora;

                        analisePausas.Add(analisePausa);

                        //Verifica se é login
                        if (factPausa.UsuarioStatusId == 1)
                        {
                            //verifica se está dentro da telerancia
                            if (analisePausa.Hora > usuario.InicioExpediente_Tolerancia)
                                if (!usuario.NotificadoAtrasoComLogin)
                                {
                                    InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Atraso_ComLogin, factPausa.UsuarioId);
                                    usuario.NotificadoAtrasoComLogin = true;
                                }
                        }
                    }

                    //Verifica se é uma pausa
                    if (dimUsuarioStatusService.getById(factPausa.UsuarioStatusId).Duracao.TotalSeconds > 0)
                    {
                        if (usuario.AnalisePausaModel_Anterior != null && usuario.AnalisePausaModel_Anterior.InicioPausa.TimeOfDay.TotalSeconds > 0 && usuario.AnalisePausaModel_Anterior.UsuarioStatusId != 1)
                        {
                            TimeSpan difPausa = DateTime.Today.AddSeconds(factPausa.Hora.TotalSeconds).Subtract(usuario.AnalisePausaModel_Anterior.InicioPausa);
                            usuario.AnalisePausaModel_Anterior.TotalPausa = usuario.AnalisePausaModel_Anterior.TotalPausa.Add(difPausa);

                            usuario.AnalisePausaModel_Anterior.EmPausaNoMomento = false;

                            usuario.AnalisePausaModel_Anterior.HoraId = factPausa.HoraId;
                            usuario.AnalisePausaModel_Anterior.Hora = factPausa.Hora;
                        }
                        analisePausa.InicioPausa = DateTime.Today.AddSeconds(factPausa.Hora.TotalSeconds);
                        analisePausa.EmPausaNoMomento = true;
                    }
                    else
                    {
                        //Obtem pausa anterior para comparação
                        if (usuario.AnalisePausaModel_Anterior != null && usuario.AnalisePausaModel_Anterior.UsuarioStatusId != 2)
                        {

                            TimeSpan difPausa = DateTime.Today.AddSeconds(factPausa.Hora.TotalSeconds).Subtract(usuario.AnalisePausaModel_Anterior.InicioPausa);
                            usuario.AnalisePausaModel_Anterior.TotalPausa = usuario.AnalisePausaModel_Anterior.TotalPausa.Add(difPausa);

                            usuario.AnalisePausaModel_Anterior.EmPausaNoMomento = false;

                            usuario.AnalisePausaModel_Anterior.HoraId = factPausa.HoraId;
                            usuario.AnalisePausaModel_Anterior.Hora = factPausa.Hora;
                        }

                        if (factPausa.UsuarioStatusId == 2)
                        {
                            analisePausa.HoraId = factPausa.HoraId;
                            analisePausa.Hora = factPausa.Hora;
                        }
                    }

                    usuario.AnalisePausaModel_Anterior = analisePausa;
                }
                catch (Exception ex)
                {
                    OutputLogs(ex.Message + ex.StackTrace, "ERRO");
                    try
                    {
                        ServiceNotification.Msmq.ServiceMsmq s = new Msmq.ServiceMsmq();
                        var trans = s.BeginTransaction();
                        var msg = new BITotalIP.DTO.FactPausa()
                        {
                            DataId = factPausa.DataId,
                            Duracao = factPausa.Duracao,
                            HoraId = factPausa.HoraId,
                            PausaId = factPausa.PausaId,
                            UsuarioId = factPausa.UsuarioId,
                            UsuarioStatusId = factPausa.UsuarioStatusId
                        };

                        s.Enqueue<BITotalIP.DTO.FactPausa>(msg, ConfigurationManager.AppSettings["filaPausa"], trans);
                        trans.Commit();

                        //serviceSerializer.Serializer<BITotalIP.DTO.FactPausa>(msg, string.Format("Fact_Pausa_exception_{0}", DateTime.Now.ToString("ddMMyyyy_HHmmssffff")));
                    }
                    catch (Exception ex2)
                    {
                        OutputLogs("Não foi possível enfileirar a mensagem para reprocessamento.", "INFO");
                        OutputLogs(ex2.Message + ex2.StackTrace, "ERRO");
                    }
                    OutputLogs("Mensagem enfileirada para reprocessamento.", "INFO");
                }
                factPausa = servicoPausa.getNext();
            }

            List<DTO.AnalisePausaModel> listaParaRemocao = new List<AnalisePausaModel>();
            foreach (DTO.AnalisePausaModel analisePausa in analisePausas)
            {
                if (dimUsuarioStatusService.getById(analisePausa.UsuarioStatusId).Duracao.TotalSeconds > 0)
                {
                    if (analisePausa.TotalPausa > dimUsuarioStatusService.getById(analisePausa.UsuarioStatusId).Fim)
                    {
                        NotificarAtraso(analisePausa);
                        listaParaRemocao.Add(analisePausa);
                    }

                    if (analisePausa.EmPausaNoMomento)
                    {
                        TimeSpan difPausa = DateTime.Now.Subtract(analisePausa.InicioPausa);
                        
                        if ((analisePausa.TotalPausa.Add(difPausa)) > dimUsuarioStatusService.getById(analisePausa.UsuarioStatusId).Fim)
                        {
                            NotificarAtraso(analisePausa);
                            listaParaRemocao.Add(analisePausa);
                        }
                    }
                }
            }

            foreach (var item in listaParaRemocao)
                analisePausas.Remove(analisePausas.Where(a=>a.PausaId.Equals(item.PausaId)).FirstOrDefault());

            serviceSerializer.Serializer(analisePausas);
        }

        private static void NotificarAtraso(AnalisePausaModel analisePausa)
        {
            OutputLogs("NotificarAtraso", "info");
            BusinessIntelligence.DTO.EnumTbNotificacaoTipo enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.NaoDefinido;

            #region Define enumTbNotificacaoTipo
            switch (analisePausa.UsuarioStatusId)
            {
                case 51:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa10;
                    break;

                case 52:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaAlmoço;
                    break;

                case 53:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaBanheiro;
                    break;

                case 54:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaBreak;
                    break;

                case 55:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaFeedback;
                    break;

                case 56:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaMonitoria;
                    break;
                case 57:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaRetorno;
                    break;
                case 58:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa20;
                    break;
                case 59:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa30;
                    break;
                case 60:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.PausaAdministrativa;
                    break;
                case 61:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Segunda_Pausa10;
                    break;
                case 62:
                    enumTbNotificacaoTipo = BusinessIntelligence.DTO.EnumTbNotificacaoTipo.Pausa15;
                    break;
            }
            #endregion

            InsereNotificacao(enumTbNotificacaoTipo, analisePausa.UsuarioId);

        }

        private static void InsereNotificacao(BusinessIntelligence.DTO.EnumTbNotificacaoTipo enumTbNotificacaoTipo, int usuarioId)
        {
            OutputLogs("InsereNotificacao", "info");

            BusinessIntelligence.DTO.TbNotificacao notificacao = new BusinessIntelligence.DTO.TbNotificacao();

            notificacao.DataHora = DateTime.Now;
            notificacao.GrupoCobrancaId = BI_GrupoCobrancaId;
            notificacao.NotificacaoTipoId = (int)enumTbNotificacaoTipo;
            notificacao.Pendente = true;
            notificacao.UsuarioId = new BLL.DimUsuario().getById(usuarioId).CobNetUsId;
            notificacao.SupervisorId = new BusinessIntelligence.BLL.TbGrupoCobrancaSupervisor().SelecionarPeloGrupoCrobrancaId(BI_GrupoCobrancaId).FirstOrDefault().SupervisorId;


            new BusinessIntelligence.BLL.TbNotificacao().Cadastrar(notificacao);
        }
    }
}
