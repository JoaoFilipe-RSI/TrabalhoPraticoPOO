using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCondominio.Enums;
using ProjetoCondominio.Models;


namespace ProjetoCondominio.Services
{
    public static class MoradorService
    {
        #region Métodos Públicos
        public static void RegistarMorador(int condominioId, string nome, string apartamento, string contato, TipoMorador tipo)
        {
            var condominio = CondominioService.ObterCondominioPorId(condominioId);
            int id = condominio.ObterMoradores().Count + 1;
            var morador = new Morador(id, nome, apartamento, contato, tipo);
            condominio.AdicionarMorador(morador);
            Console.WriteLine($"Morador {nome} registado com sucesso no condomínio {condominio.Nome}!");
        }

        public static Morador ObterMoradorPorId(int condominioId, int moradorId)
        {
            var condominio = CondominioService.ObterCondominioPorId(condominioId);
            var morador = condominio.ObterMoradores().Find(m => m.Id == moradorId);
            if (morador == null)
                throw new Exception("Morador não encontrado.");
            return morador;
        }

        public static List<Morador> ObterMoradoresPorCondominio(int condominioId)
        {
            var condominio = CondominioService.ObterCondominioPorId(condominioId);
            return condominio.ObterMoradores();
        }
        #endregion
    }
}
