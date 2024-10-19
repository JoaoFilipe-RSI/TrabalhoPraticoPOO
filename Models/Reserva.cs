using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico_POO.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string Area { get; set; }
        public DateTime DataReserva { get; set; }
        public Morador Morador { get; set; }
        public Condominio Condominio { get; set; }
    }
}
