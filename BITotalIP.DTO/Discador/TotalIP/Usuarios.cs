using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITotalIP.DTO.Discador.TotalIP
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string ramal { get; set; }
        public int id_status_usuario { get; set; }
        public string status_usuario { get; set; }
        public int id_status_telefone { get; set; }
        public string nome_status_telefone { get; set; }
        public int id_grupo { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string tipo_da_ligacao { get; set; }
        public string uniqueid { get; set; }
        public string parametro1 { get; set; }
        public string parametro2 { get; set; }
        public string telefone { get; set; }
        public int id_campanha { get; set; }
        public string telefone_origem { get; set; }
    }
}
