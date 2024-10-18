using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoPratico_POO.Models;
using TrabalhoPratico_POO.Enums;

namespace TrabalhoPratico_POO.Services
{
    public class CondominioService
    {
        private List<Condominio> condominios = new List<Condominio>();
        private int idCounter = 1;

        public void RegistarCondominio(string nome, string endereco, TipoCondominio tipo)
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

        public void ListarCondominios()
        {
            Console.WriteLine("\nLista de Condomínios:");
            foreach (var condominio in condominios)
            {
        Console.WriteLine($"ID: {condominio.IdCondominio}, Nome: {condominio.Nome}, Tipo: {condominio.Tipo}, Endereço: {condominio.Endereco}");
        }
        }

        public Condominio ObterCondominioPorId(int id)
        {
            return condominios.FirstOrDefault(c => c.IdCondominio == id);
        }
    }
}
