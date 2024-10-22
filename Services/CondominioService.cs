using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCondominio.Enums;
using ProjetoCondominio.Models;

namespace ProjetoCondominio.Services
{
    public static class CondominioService
    {
        #region Propriedades Privadas
        private static List<Condominio> condominios = new List<Condominio>();
        #endregion

        #region Métodos Públicos
        public static void RegistarCondominio(string nome, string endereco, TipoCondominio tipo)
        {
            int id = condominios.Count + 1;
            var condominio = new Condominio(id, nome, endereco, tipo);
            condominios.Add(condominio);
            Console.WriteLine($"Condomínio {nome} registdo com sucesso!");
        }

        public static List<Condominio> ObterCondominios()
        {
            return condominios;
        }

        public static Condominio ObterCondominioPorId(int id)
        {
            var condominio = condominios.Find(c => c.Id == id);
            if (condominio == null)
                throw new Exception("Condomínio não encontrado.");
            return condominio;
        }
        #endregion
    }
}