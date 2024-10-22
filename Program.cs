using System;
using ProjetoCondominio.Enums;
using ProjetoCondominio.Services;
using ProjetoCondominio.Models;

namespace ProjetoCondominio
{
    class Program
    {
        static void Main(string[] args)
        {

        #region MENU Principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("###--- MENU PRINCIPAL ---###");
                Console.WriteLine("1. Gestão de Condomínios");
                Console.WriteLine("2. Gestão de Moradores");
                Console.WriteLine("3. Gestão de Reservas");
                Console.WriteLine("4. Contabilidade");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuGestaoCondominios();
                        break;
                    case "2":
                        MenuGestaoMoradores();
                        break;
                    case "3":
                        MenuGestaoReservas();
                        break;
                    case "4":
                        MenuContabilidade();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        #endregion

        #region MENU Gestão de Condomínios
        static void MenuGestaoCondominios()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("###--- Gestão de Condomínios ---###");
                Console.WriteLine("1. Registar novo Condomínio");
                Console.WriteLine("2. Listar Condomínios");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistarCondominio();
                        break;
                    case "2":
                        ListarCondominios();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void RegistarCondominio()
        {
            Console.WriteLine("###--- Registar novo Condomínio ---###");
            Console.Write("Nome do condominio: ");
            string nome = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Tipo de Condominio (1-Residencial, 2-Comercial, 3-Fechado): ");
            TipoCondominio tipo = (TipoCondominio)int.Parse(Console.ReadLine());

            CondominioService.RegistarCondominio(nome, endereco, tipo);
        }

        static void ListarCondominios()
        {
            var condominios = CondominioService.ObterCondominios();
            if (condominios.Count == 0)
            {
                Console.WriteLine("Nenhum condomínio registrado.");
                return; 
            }
            foreach (var condominio in condominios)
            {
                Console.WriteLine($"ID do Condominio: {condominio.Id} - Nome do Codominio: {condominio.Nome} - Tipo de Condominio: {condominio.Tipo}");
            }
        }
        #endregion

        #region MENU Gestão de Moradores
        static void MenuGestaoMoradores()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("###--- Gestão de Moradores ---###");
                Console.WriteLine("1. Registar novo Morador");
                Console.WriteLine("2. Listar Moradores por Condomínio");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistarMorador();
                        break;
                    case "2":
                        ListarMoradoresPorCondominio();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void RegistarMorador()
        {
            bool tipoValido = false;

            do
            {
                try
                {
                //Console.Clear();
                Console.WriteLine("###--- Registo de novo Morador ---###");
                Console.Write("ID do Condomínio: ");
                int condominioId = int.Parse(Console.ReadLine());

                // Verifica se o condomínio existe antes de prosseguir
                var condominio = CondominioService.ObterCondominioPorId(condominioId);

                Console.Write("Nome do morador: ");
                string nome = Console.ReadLine();
                Console.Write("Nº Bloco/Apartamento/casa: ");
                string apartamento = Console.ReadLine();
                Console.Write("Contato: ");
                string contato = Console.ReadLine();
                Console.Write("Tipo de morador (1-Proprietário, 2-Inquilino, 3-Visitante): ");
                TipoMorador tipo = (TipoMorador)int.Parse(Console.ReadLine());

                    if (Enum.IsDefined(typeof(TipoMorador), tipo))
                        {
                        tipo = (TipoMorador)tipo;
                        tipoValido = true;
                            MoradorService.RegistarMorador(condominioId, nome, apartamento, contato, tipo);
                        }
                    else
                    {
                        Console.WriteLine("Tipo de morador inválido. Tente novamente.");        
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Entrada inválida. Certifique-se de digitar o valor corretamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        while (!tipoValido);
        }

        static void ListarMoradoresPorCondominio()
        {
        try
        {
            Console.WriteLine("###--- Lista de Moradores ---###");
            Console.Write("ID do Condomínio: ");
            int condominioId = int.Parse(Console.ReadLine());

            // Verifica se o condomínio existe antes de prosseguir          
            var condominio = CondominioService.ObterCondominioPorId(condominioId);

            var moradores = MoradorService.ObterMoradoresPorCondominio(condominioId);
                if (moradores.Count == 0)
                {
                    Console.WriteLine("Nenhum morador registado nesse condominio.");
                    return;
                }
                foreach (var morador in moradores)
            {
                Console.WriteLine($"ID do morador: {morador.Id} - Nome do morador: {morador.Nome} - Bloco/Apartamento/Casa: {morador.Apartamento} - Tipo de morador: {morador.Tipo}");
            }
        }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida. Certifique-se de digitar o valor corretamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        #endregion

        #region MENU Gestão de Reservas
        static void MenuGestaoReservas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("### Gestão de Reservas ###");
                Console.WriteLine("1. Registrar Reserva");
                Console.WriteLine("2. Listar Reservas por Condomínio");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarReserva();
                        break;
                    case "2":
                        ListarReservasPorCondominio();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void RegistrarReserva()
        {
            Console.WriteLine("Registrar Reserva:");
            Console.Write("ID do Condomínio: ");
            int condominioId = int.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Data (dd/MM/yyyy): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            ReservaService.RegistrarReserva(condominioId, descricao, data);
        }

        static void ListarReservasPorCondominio()
        {
            Console.WriteLine("Listar Reservas:");
            Console.Write("ID do Condomínio: ");
            int condominioId = int.Parse(Console.ReadLine());

            var reservas = ReservaService.ObterReservasPorCondominio(condominioId);
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"ID: {reserva.Id} - Descrição: {reserva.Descricao} - Data: {reserva.Data:dd/MM/yyyy}");
            }
        }
        #endregion

        #region MENU Contabilidade 
        static void MenuContabilidade()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("### Contabilidade ###");
                Console.WriteLine("1. Registrar Pagamento");
                Console.WriteLine("2. Listar Pagamentos por Morador");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarPagamento();
                        break;
                    case "2":
                        ListarPagamentosPorMorador();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void RegistrarPagamento()
        {
            Console.WriteLine("Registrar Pagamento:");
            Console.Write("ID do Condomínio: ");
            int condominioId = int.Parse(Console.ReadLine());
            Console.Write("ID do Morador: ");
            int moradorId = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            FinanceiroService.RegistrarPagamento(moradorId, condominioId, valor, descricao);
        }

        static void ListarPagamentosPorMorador()
        {
            Console.WriteLine("Listar Pagamentos de um Morador:");
            Console.Write("ID do Condomínio: ");
            int condominioId = int.Parse(Console.ReadLine());
            Console.Write("ID do Morador: ");
            int moradorId = int.Parse(Console.ReadLine());

            var pagamentos = FinanceiroService.ObterPagamentosPorMorador(moradorId, condominioId);
            foreach (var pagamento in pagamentos)
            {
                Console.WriteLine($"Nº do pagamento: {pagamento.Id} - Valor: {pagamento.Valor:C} - Data: {pagamento.Data:dd/MM/yyyy} - Descrição: {pagamento.Descricao}");
            }
            #endregion

        }
    }
}