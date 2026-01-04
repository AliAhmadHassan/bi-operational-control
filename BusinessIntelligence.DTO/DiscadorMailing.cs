using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public class DiscadorMailing : Base
    {
        [AtributoBind(true, 0)]
        public string Status { get; set; }

        [AtributoBind("Fact Resultado Discagem Count")]
        public int Qtd { get; set; }
    }
}
