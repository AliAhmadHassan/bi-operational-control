using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DTO.Discador.TotalIP
{
    public class Campanhas
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool ativa { get; set; }
        public int telefones_restantes { get; set; }
        public int numeros_agendados { get; set; }
        public int agendamento_operador { get; set; }
        public int clientes_finalizados { get; set; }
        public int clientes_nao_finalizados { get; set; }
        public int ligacoes_atendidas { get; set; }
        public int licagoes_nao_atendidas { get; set; }
        public int ligacoes_ocupadas { get; set; }
        public int retentativas { get; set; }
        public int discando { get; set; }
        public int ligacoes_em_andamento_ura { get; set; }
        public int clientes_em_ligacao { get; set; }
        public int ligacoes_fila { get; set; }
        public int clientes_virgens { get; set; }
        public int entregues_sem_tabulacao { get; set; }
    }
}
