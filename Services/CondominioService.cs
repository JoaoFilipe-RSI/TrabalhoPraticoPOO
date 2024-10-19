using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoPratico_POO.Models;
using TrabalhoPratico_POO.Enums;

namespace TrabalhoPratico_POO.Services
{
    public static class CondominioService
    {
        private static List<Condominio> condominios = new List<Condominio>();
        private static int idCounter = 1;

        public static void RegistarCondominio(string nome, string endereco, TipoCondominio tipo)
        {
            var condominio = new Condominio
            {
                IdCondominio = idCounter++,
                Nome = nome,
                Endereco = endereco,
                Tipo = tipo
            };
            condominios.Add(condominio);
            Console.WriteLine($"Condomínio {nome} do tipo {tipo} registado com sucesso!");
        }

        public static void ListarCondominios()
        {
            Console.WriteLine("\nLista de Condomínios:");
            foreach (var condominio in condominios)
            {
        Console.WriteLine($"ID: {condominio.IdCondominio}, Nome: {condominio.Nome}, Tipo: {condominio.Tipo}, Endereço: {condominio.Endereco}");
        }
        }

        public static Condominio ObterCondominioPorId(int id)
        {
            return condominios.FirstOrDefault(c => c.IdCondominio == id);
        }
    }
}
