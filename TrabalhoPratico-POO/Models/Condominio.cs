using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoPratico_POO.Enums;

namespace TrabalhoPratico_POO.Models
{
    public class Condominio
    {
        public int IdCondominio { get; set; }
        public string Nome { get; set; }
        public TipoCondominio Tipo { get; set; }
        public string Endereco { get; set; }

        // Relação com os moradores e as áreas
        public List<Morador> Moradores { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Condominio()
        {
            Moradores = new List<Morador>();
            Reservas = new List<Reserva>();
        }
    }
}