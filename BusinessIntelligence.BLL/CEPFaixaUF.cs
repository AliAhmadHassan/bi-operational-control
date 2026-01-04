using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.BLL
{
    public class FaixaUF
    {
        public string UF { get; set; }

        public int FaixaInicial { get; set; }

        public int FaixaFinal { get; set; }
    }

    public class CEPFaixaUF
    {
        public List<FaixaUF> faixa_uf { get; set; }

        public CEPFaixaUF()
        {
            faixa_uf = new List<FaixaUF>();
            LoadUf();
        }

        private void LoadUf()
        {
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 69900000, FaixaInicial = 69999999, UF = "AC" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 57000000, FaixaInicial = 57999999, UF = "AL" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 69000000, FaixaInicial = 69299999, UF = "AM" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 69400000, FaixaInicial = 69899999, UF = "AM" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 68900000, FaixaInicial = 68999999, UF = "AP" });

            faixa_uf.Add(new FaixaUF() { FaixaFinal = 40000000, FaixaInicial = 48999999, UF = "BA" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 60000000, FaixaInicial = 63999999, UF = "CE" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 70000000, FaixaInicial = 72799999, UF = "DF" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 73000000, FaixaInicial = 73699999, UF = "DF" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 29000000, FaixaInicial = 29999999, UF = "ES" });

            faixa_uf.Add(new FaixaUF() { FaixaFinal = 72800000, FaixaInicial = 72999999, UF = "GO" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 73700000, FaixaInicial = 76799999, UF = "GO" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 65000000, FaixaInicial = 65999999, UF = "MA" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 30000000, FaixaInicial = 39999999, UF = "MG" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 79000000, FaixaInicial = 79999999, UF = "MS" });

            faixa_uf.Add(new FaixaUF() { FaixaFinal = 78000000, FaixaInicial = 78899999, UF = "MT" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 66000000, FaixaInicial = 68899999, UF = "PA" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 58000000, FaixaInicial = 58999999, UF = "PB" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 50000000, FaixaInicial = 56999999, UF = "PE" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 64000000, FaixaInicial = 64999999, UF = "PI" });

            faixa_uf.Add(new FaixaUF() { FaixaFinal = 80000000, FaixaInicial = 87999999, UF = "PR" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 20000000, FaixaInicial = 28999999, UF = "RJ" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 59000000, FaixaInicial = 59999999, UF = "RN" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 76800000, FaixaInicial = 76999999, UF = "RO" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 69300000, FaixaInicial = 69399999, UF = "RR" });

            faixa_uf.Add(new FaixaUF() { FaixaFinal = 90000000, FaixaInicial = 99999999, UF = "RS" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 88000000, FaixaInicial = 89999999, UF = "SC" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 49000000, FaixaInicial = 49999999, UF = "SE" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 01000000, FaixaInicial = 19999999, UF = "SP" });
            faixa_uf.Add(new FaixaUF() { FaixaFinal = 77000000, FaixaInicial = 77999999, UF = "TO" });

        }
    }
}
