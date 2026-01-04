using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class ParqueGrafico
    {
        public List<DTO.ParqueGraficoPivotFaixaAtrasoValor> ParqueGraficoPivotFaixaAtrasoValor(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoPivotFaixaAtrasoValor(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoVencimento> ParqueGraficoVencimento(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoVencimento(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoGerados> ParqueGraficoGerado(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoGerado(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoPesquisaEletronica> ParqueGraficoPesquisaEletronica(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoPesquisaEletronica(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoTipoEndereco> ParqueGraficoTipoEndereco(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoTipoEndereco(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoFaixaAtraso> ParqueGraficoFaixaAtraso(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoFaixaAtraso(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoFaixaValorSaldo> ParqueGraficoFaixaValorSaldo(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoFaixaValorSaldo(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoFaixaValorPago> ParqueGraficoFaixaValorPago(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoFaixaValorPago(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoScoreSerasa> ParqueGraficoScoreSerasa(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoScoreSerasa(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoRegraParqueGrafico> ParqueGraficoRegraParqueGrafico(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoRegraParqueGrafico(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoProduto> ParqueGraficoProtudo(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoProtudo(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoUF> ParqueGraficoUF(int ano, int mes, params int[] carteira_id)
        {
            return new DAL.ParqueGrafico().ParqueGraficoUF(ano, mes, carteira_id);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaDataCadastro(int ano, int mes, int dia, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaDataCadastro(ano, mes, dia, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaDataVencimento(int ano, int mes, int dia, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaDataVencimento(ano, mes, dia, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaRegraParqueGrafico(int ano, int mes, string regra, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaRegraParqueGrafico(ano, mes, regra, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloTipoEndereco(int ano, int mes, string tipoendereco, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPeloTipoEndereco(ano, mes, tipoendereco, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloTratadoPor(int ano, int mes, string tratadopor, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPeloTratadoPor(ano, mes, tratadopor, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaFaixaAtraso(int ano, int mes, string faixaatraso, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaFaixaAtraso(ano, mes, faixaatraso, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaFaixaValor(int ano, int mes, string faixavalor, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaFaixaValor(ano, mes, faixavalor, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloDiaVencimento(int ano, int mes, int dia, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPeloDiaVencimento(ano, mes, dia, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloScore(int ano, int mes, string score, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPeloScore(ano, mes, score, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPeloProduto(int ano, int mes, string produto, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPeloProduto(ano, mes, produto, credores);
        }

        public List<DTO.ParqueGraficoAnalitico> ListarAnaliticoPelaUF(int ano, int mes, string uf, string credores)
        {
            return new DAL.ParqueGrafico().ListarAnaliticoPelaUF(ano, mes, uf, credores);
        }

    }
}