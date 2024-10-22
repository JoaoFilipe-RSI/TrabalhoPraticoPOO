using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCondominio.Models;

namespace ProjetoCondominio.Services
{
    public static class ReservaService
    {
        #region Métodos Públicos
        public static void RegistrarReserva(int condominioId, string descricao, DateTime data)
        {
            var condominio = CondominioService.ObterCondominioPorId(condominioId);
            int id = condominio.ObterReservas().Count + 1;
            var reserva = new Reserva(id, descricao, data);
            condominio.AdicionarReserva(reserva);
            Console.WriteLine($"Reserva para {descricao} registrada com sucesso no condomínio {condominio.Nome}!");
        }

        public static List<Reserva> ObterReservasPorCondominio(int condominioId)
        {
            var condominio = CondominioService.ObterCondominioPorId(condominioId);
            return condominio.ObterReservas();
        }
        #endregion
    }
}