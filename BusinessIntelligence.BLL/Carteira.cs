using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class Carteira
    {
        public List<DTO.CarteiraFaixaAtraso> CarteiraFaixaAtraso(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraFaixaAtraso(ano, mes, dia,carteira_id);
        }

        public List<DTO.CarteiraFaixaValor> CarteiraFaixaValor(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraFaixaValor(ano, mes, dia, carteira_id);
        }

        public List<DTO.CarteiraSituacao> CarteiraSituacao(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraSituacao(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraUF> CarteiraUF(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraUF(ano, mes, dia, carteira_id);
        }

        public List<DTO.CarteiraMarcacao> CarteiraMarcacao(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraMarcacao(ano, mes, dia, carteira_id);
        }

        public List<DTO.CarteiraEnquete> CarteiraEnquete(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraEnquete(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraOrigemPagamento> CarteiraOrigemPagamento(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraOrigemPagamento(ano, mes, dia,carteira_id);
        }

        public List<DTO.CarteiraPlanoAderencia> CarteiraPlanoAderencia(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraPlanoAderencia(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraStatusCobranca> CarteiraStatusCobranca(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraStatusCobranca(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraPrevisaoRecebimento> CarteiraPrevisaoRecebimento(int ano, int mes,int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraPrevisaoRecebimento(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraPreventivo> CarteiraPreventivo(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraPreventivo(ano, mes,dia,  carteira_id);
        }

        public List<DTO.CarteiraQuebras> CarteiraQuebras(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraQuebras(ano, mes, dia, carteira_id);
        }

        public List<DTO.CarteiraScore> CarteiraScore(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraScore(ano, mes,dia, carteira_id);
        }

        public List<DTO.CarteiraLocal> CarteiraLocal(int ano, int mes, int dia, params int[] carteira_id)
        {
            return new DAL.Carteira().CarteiraLocal(ano, mes, dia, carteira_id);
        }

        public List<DTO.CarteiraAnaliticoSituacao> ListarPelaSituacaoID(int ano, int mes, int dia, string situacao, string credores_id)
        {
            return new DAL.FactCarteira().ListarPelaSituacaoID(ano, mes, dia, situacao, credores_id);
        }

        public List<DTO.CarteiraAnaliticoScoreSerasa> ListarPeloScore(int ano, int mes, int dia, string score, string credores_id)
        {
            return new DAL.FactCarteira().ListarPeloScore(ano, mes, dia, score, credores_id);
        }

        public List<DTO.CarteiraAnaliticoFaixaValor> ListarPelaFaixaValor(int ano, int mes, int dia, string faixa, string credores_id)
        {
            return new DAL.FactCarteira().ListarPelaFaixaValor(ano, mes, dia, faixa, credores_id);
        }

        public List<DTO.CarteiraAnaliticoFaixaAtraso> ListarPelaFaixaAtraso(int ano, int mes, int dia, string faixa, string credores_id)
        {
            return new DAL.FactCarteira().ListarPelaFaixaAtraso(ano, mes, dia, faixa, credores_id);
        }

        public List<DTO.CarteiraAnaliticoUF> ListarPelaUF(int ano, int mes, int dia, string uf, string credores_id)
        {
            return new DAL.FactCarteira().ListarPelaUF(ano, mes, dia, uf, credores_id);
        }

        public List<DTO.CarteiraAnaliticoStatusCobranca> ListarPelaStatusCobrancaID(string situacao, int ano, int mes, int dia, string credores_id)
        {
            return new DAL.FactCarteira().ListarPelaStatusCobrancaID(situacao, ano, mes, dia, credores_id);
        }

        public List<DTO.CarteiraAnaliticoVencimento> ListarPeloVencimento(int ano, int mes, int dia, string credores_id)
        {
            return new DAL.FactCarteira().ListarPeloVencimento(ano, mes, dia, credores_id);
        }
    }
}