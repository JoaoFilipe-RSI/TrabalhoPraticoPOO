using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCondominio.Models;

namespace ProjetoCondominio.Services
{
    public static class FinanceiroService
    {
        #region Métodos Públicos
        public static void RegistrarPagamento(int moradorId, int condominioId, decimal valor, string descricao)
        {
            try
            {
                var morador = MoradorService.ObterMoradorPorId(condominioId, moradorId);
                var pagamento = new Pagamento(morador.ObterPagamentos().Count + 1, valor, descricao);
                pagamento.Validar();
                morador.AdicionarPagamento(pagamento);
                Console.WriteLine($"Pagamento de {valor:C} registrado com sucesso para o morador {morador.Nome}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar pagamento: {ex.Message}");
            }
        }

        public static List<Pagamento> ObterPagamentosPorMorador(int moradorId, int condominioId)
        {
            var morador = MoradorService.ObterMoradorPorId(condominioId, moradorId);
            return morador.ObterPagamentos();
        }
        #endregion
    }
}
