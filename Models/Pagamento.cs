using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCondominio.Models
{
    public class Pagamento
    {
        #region Propriedades Públicas
        public int Id { get; private set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; private set; }
        #endregion

        #region Construtores
        public Pagamento(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
            Data = DateTime.Now;
        }
        #endregion

        #region Métodos
        public void Validar()
        {
            if (Valor <= 0)
                throw new Exception("Valor do pagamento deve ser maior que zero.");
        }
        #endregion
    }
}