using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico_POO.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public Condominio Condominio { get; set; }
        public Morador Morador { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool PagamentoEmDia { get; set; }
    }
}
