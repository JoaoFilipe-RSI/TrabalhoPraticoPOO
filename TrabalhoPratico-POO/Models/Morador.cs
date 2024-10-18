using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TrabalhoPratico_POO.Enums;

namespace TrabalhoPratico_POO.Models
{
    public class Morador
    {
        #region Private Properties
        public int IdMorador { get; set; }
        public TipoMorador Tipo { get; set; }
        public string Nome { get; set; }
        public string Apartamento { get; set; }
        public string Contato { get; set; }
        public Condominio Condominio { get; set; }
        #endregion
    }
}
