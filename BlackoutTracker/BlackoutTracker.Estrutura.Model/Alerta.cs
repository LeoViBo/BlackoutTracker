using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutTracker.Estrutura.Model
{
    public class Alerta
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Bairro { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
    }
}
