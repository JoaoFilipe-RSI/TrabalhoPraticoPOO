using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPratico_POO.Models;

namespace TrabalhoPratico_POO.Services
{
    public class ReservaService
    {
        private CondominioService condominioService;

        public ReservaService(CondominioService condominioService)
        {
            this.condominioService = condominioService;
        }

        public void CriarReserva(int condominioId, int moradorId, string area, DateTime dataReserva)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                var morador = condominio.Moradores.FirstOrDefault(m => m.IdMorador == moradorId);
                if (morador != null)
                {
                    var reserva = new Reserva
                    {
                        IdReserva = condominio.Reservas.Count + 1,
                        Area = area,
                        DataReserva = dataReserva,
                        Morador = morador
                    };
                    condominio.Reservas.Add(reserva);
                    Console.WriteLine($"Área {area} reservada por {morador.Nome} no dia {dataReserva.ToShortDateString()}.");
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

        public void ListarReservas(int condominioId)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                Console.WriteLine($"\nReservas no Condomínio {condominio.Nome}:");
                foreach (var reserva in condominio.Reservas)
                {
                    Console.WriteLine($"ID: {reserva.IdReserva}, Área: {reserva.Area}, Data: {reserva.DataReserva.ToShortDateString()}, Morador: {reserva.Morador.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Condomínio não encontrado.");
            }
        }
    }
}
