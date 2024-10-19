using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoPratico_POO.Models;
using TrabalhoPratico_POO.Enums;

namespace TrabalhoPratico_POO.Services
{
    public class MoradorService
    {
        private CondominioService condominioService;

        public MoradorService(CondominioService condominioService)
        {
            this.condominioService = condominioService;
        }

        public void RegistarMorador(int condominioId, TipoMorador tipo, string nome, string apartamento, string contato)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                var morador = new Morador
                {
                    IdMorador = condominio.Moradores.Count + 1,
                    Tipo = tipo,
                    Nome = nome,
                    Apartamento = apartamento,
                    Contato = contato,
                    Condominio = condominio
                };
                condominio.Moradores.Add(morador);
                Console.WriteLine($"Morador {nome} do tipo {tipo} registado no condomínio {condominio.Nome}.");
            }
            else
            {
                Console.WriteLine("Condomínio não encontrado.");
            }
        }

        public void ListarMoradores(int condominioId)
        {
            var condominio = condominioService.ObterCondominioPorId(condominioId);
            if (condominio != null)
            {
                Console.WriteLine($"\nMoradores do Condomínio {condominio.Nome}:");
                foreach (var morador in condominio.Moradores)
                {
                    Console.WriteLine($"ID: {morador.IdMorador}, Tipo: {morador.Tipo}, Nome: {morador.Nome}, Apartamento: {morador.Apartamento}");
                }
            }
            else
            {
                Console.WriteLine("Condomínio não encontrado.");
            }
        }
    }
}
