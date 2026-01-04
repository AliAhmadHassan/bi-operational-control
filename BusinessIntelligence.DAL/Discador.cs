using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class Discador : Conexao
    {
        public List<DTO.DiscadorMailing> ListarStatusDiscagem(int id_mailing)
        {
            string query = @"Select NON Empty{[Dim Discagem Status].[Discagem Status Id].[Discagem Status Id]} on rows,
                            {[Measures].[Fact Resultado Discagem Count]} on columns
                        from [CuboResultadoDiscagem]
                        WHERE (
			                        [Dim Mailling].[Mailling Id].&[" + id_mailing + "])";


            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexaoDiscador.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.DiscadorMailing>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.DiscadorMailing>();
        }

        public List<DTO.DiscadorMailing> ListarStatusDiscagemPelaCampanha(int id_campanha)
        {
            string query = @"Select NON Empty{[Dim Discagem Status].[Discagem Status Id].[Discagem Status Id]} on rows,
                            {[Measures].[Fact Resultado Discagem Count]} on columns
                        from [CuboResultadoDiscagem]
                        WHERE (
			                        [Dim Campanha].[Campanha Id].&[" + id_campanha + "])";


            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexaoDiscador.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.DiscadorMailing>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.DiscadorMailing>();
        }

        public List<DTO.DiscadorMailing> ListarAlo(int id_mailing)
        {
            string query = @"Select NON Empty{[Dim Discagem Status].[Discagem Status Id].[Discagem Status Id]} on rows,
                            {[Measures].[Fact Resultado Discagem Count]} on columns
                        from [CuboResultadoDiscagem]
                        WHERE (
                                    [Dim Discagem Status].[Alo].&[True],
			                        [Dim Mailling].[Mailling Id].&[" + id_mailing + "])";


            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexaoDiscador.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.DiscadorMailing>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.DiscadorMailing>();
        }

        public List<DTO.DiscadorMailing> ListarLocalizado(int id_mailing)
        {
            string query = @"Select NON Empty{[Dim Discagem Status].[Discagem Status Id].[Discagem Status Id]} on rows,
                            {[Measures].[Fact Resultado Discagem Count]} on columns
                        from [CuboResultadoDiscagem]
                        WHERE (
                                    [Dim Discagem Status].[Localizado].&[True],
			                        [Dim Mailling].[Mailling Id].&[" + id_mailing + "])";


            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexaoDiscador.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.DiscadorMailing>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.DiscadorMailing>();
        }

        public List<DTO.DiscadorMailing> ListarCpc(int id_mailing)
        {
            string query = @"Select NON Empty{[Dim Discagem Status].[Discagem Status Id].[Discagem Status Id]} on rows,
                            {[Measures].[Fact Resultado Discagem Count]} on columns
                        from [CuboResultadoDiscagem]
                        WHERE (
                                    [Dim Discagem Status].[CPC].&[True],
			                        [Dim Mailling].[Mailling Id].&[" + id_mailing + "])";


            int tentativa = 0;
            do
            {
                try
                {
                    using (AdomdCommand cmd = new AdomdCommand(query, SingletonConexaoDiscador.Instance) { CommandTimeout = int.MaxValue })
                        return AuxiliarParse.RetornaDadosEntidade<DTO.DiscadorMailing>(cmd.ExecuteCellSet());

                }
                catch
                {
                    tentativa++;
                }
            } while (tentativa < 3);

            return new List<DTO.DiscadorMailing>();
        }

        public List<DTO.DiscadorStatusDia> ListarUsuariosStatusDia(int ano, int mes, int dia)
        {
            return AuxConsultas<DTO.DiscadorStatusDia>.Lista("SPSStatusUsuarioDia", Conexao.DiscadorDW, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter { ParameterName = "@Ano", Value = ano },
                new System.Data.SqlClient.SqlParameter { ParameterName = "@Mes", Value = mes},
                new System.Data.SqlClient.SqlParameter { ParameterName = "@Dia", Value = dia }
            });
        }

        public List<DTO.MailingAtivo> ListarMailingAtivos()
        {
            return AuxConsultas<DTO.MailingAtivo>.Lista("SPSMailingAtivo", Conexao.DiscadorDW, null);
        }
    }
}
