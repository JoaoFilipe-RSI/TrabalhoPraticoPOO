//-----------------------------------------------------------------
//    <copyright file="TrabalhoPratico-POO" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-10-2024</date>
//    <time>10:00</time>
//    <version>0.1</version>
//    <author>J. Filipe Ferreira</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using TrabalhoPratico_POO;
using TrabalhoPratico_POO.Enums;
using TrabalhoPratico_POO.Services;
using TrabalhoPratico_POO.Models;


namespace TrabalhoPratico_POO.Models
{

    public class Program
    {
    static void Main(string[] args)
    {
        var condominioService = new CondominioService();
        var moradorService = new MoradorService(condominioService);
        var reservaService = new ReservaService(condominioService);
        var financeiroService = new FinanceiroService(condominioService);

        int opcao;
        do
        {
            Console.WriteLine("\n--- Sistema de Gestão de Condomínios ---");
            Console.WriteLine("1. Registar novo Condomínio");
            Console.WriteLine("2. Listar Condomínios");
            Console.WriteLine("3. Registar novo Morador");
            Console.WriteLine("4. Listar Moradores");
            Console.WriteLine("5. Fazer Reserva");
            Console.WriteLine("6. Listar Reservas");
            Console.WriteLine("7. Registar Pagamento");
            Console.WriteLine("0. Sair");
            Console.Write("Selecione uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    RegistarCondominio(condominioService);
                    break;
                case 2:
                    ListarCondominios(condominioService);
                    break;
                case 3:
                    RegistarMorador(moradorService);
                    break;
                case 4:
                    ListarMoradores(moradorService);
                    break;
                case 5:
                    // Implementar Fazer Reserva
                    break;
                case 6:
                    // Implementar Listar Reservas
                    break;
                case 7:
                    // Implementar Registrar Pagamento
                    break;
                case 0:
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (opcao != 0);
    }

    static void RegistarCondominio(CondominioService condominioService)
    {
        Console.Write("Nome do Condomínio: ");
        string nomeCondominio = Console.ReadLine();

        Console.Write("Endereço do Condomínio: ");
        string enderecoCondominio = Console.ReadLine();

        // Escolher o TipoCondominio via Console
        Console.WriteLine("Escolha o tipo de condomínio:");
        Console.WriteLine("1. Residencial");
        Console.WriteLine("2. Comercial");
        Console.WriteLine("3. Fechado");
        Console.Write("Digite o número correspondente: ");
        int tipoCondominioEntrada = int.Parse(Console.ReadLine());

        // Validação básica
        if (!Enum.IsDefined(typeof(TipoCondominio), tipoCondominioEntrada))
        {
            Console.WriteLine("Tipo de condomínio inválido.");
            return;
        }

        TipoCondominio tipoCondominio = (TipoCondominio)tipoCondominioEntrada;

        condominioService.RegistarCondominio(nomeCondominio, enderecoCondominio, tipoCondominio);
    }

    static void ListarCondominios(CondominioService condominioService)
    {
        Console.WriteLine("\nLista de Condomínios:");
            var condominios = condominioService.ListarCondominios();
            foreach (var condominio in condominios)
        {
            Console.WriteLine($"ID: {condominio.Id}, Nome: {condominio.Nome}, Tipo: {condominio.Tipo}, Endereço: {condominio.Endereco}");
        }
    }

    static void RegistarMorador(MoradorService moradorService)
    {
        Console.Write("ID do Condomínio: ");
        if (!int.TryParse(Console.ReadLine(), out int condominioId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Console.Write("Nome do Morador: ");
        string nomeMorador = Console.ReadLine();

        Console.Write("Apartamento: ");
        string apartamentoMorador = Console.ReadLine();

        Console.Write("Contato: ");
        string contatoMorador = Console.ReadLine();

        // Escolher o TipoMorador via Console
        Console.WriteLine("Escolha o tipo de morador:");
        Console.WriteLine("1. Proprietário");
        Console.WriteLine("2. Inquilino");
        Console.WriteLine("3. Visitante");
        Console.Write("Digite o número correspondente: ");
        int tipoMoradorEntrada = int.Parse(Console.ReadLine());

        // Validação básica
        if (!Enum.IsDefined(typeof(TipoMorador), tipoMoradorEntrada))
        {
            Console.WriteLine("Tipo de morador inválido.");
            return;
        }

        TipoMorador tipoMorador = (TipoMorador)tipoMoradorEntrada;

        moradorService.RegistarMorador(condominioId, tipoMorador, nomeMorador, apartamentoMorador, contatoMorador);
    }

    static void ListarMoradores(MoradorService moradorService)
    {
        Console.Write("ID do Condomínio: ");
        if (!int.TryParse(Console.ReadLine(), out int condominioId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        moradorService.ListarMoradores(condominioId);
    }
    }
}

