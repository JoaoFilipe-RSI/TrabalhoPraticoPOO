using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico_POO.Models;

namespace TrabalhoPratico_POO.Services
{
    public class FinanceiroService
    {
        private CondominioService condominioService;

        public FinanceiroService(CondominioService condominioService)
        {
            this.condominioService = condominioService;
        }

        public void RegistrarPagamento(int condominioId, int moradorId, decimal valor, bool emDia)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                var morador = condominio.Moradores.FirstOrDefault(m => m.IdMorador == moradorId);
                if (morador != null)
                {
                    var pagamento = new Financeiro
                    {
                        Id = morador.Condominio.Reservas.Count + 1,
                        Morador = morador,
                        Valor = valor,
                        DataPagamento = DateTime.Now,
                        PagamentoEmDia = emDia
                    };
                    Console.WriteLine($"Pagamento de {valor:C} registrado para o morador {morador.Nome}.");
                }
                else
                {
                    Console.WriteLine("Morador não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Condomínio não encontrado.");
            }
        }

        public void ListarPagamentos(int condominioId)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                Console.WriteLine($"\nPagamentos no Condomínio {condominio.Nome}:");
                foreach (var morador in condominio.Moradores)
                {
                    Console.WriteLine($"Morador: {morador.Nome}, Total Pagamentos: {morador.Condominio.Reservas.Count}");
                }
            }
            else
            {
                Console.WriteLine("Condomínio não encontrado.");
            }
        }
    }
}
