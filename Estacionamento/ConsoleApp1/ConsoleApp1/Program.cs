using DesafioFundamentos.Models;
using System;
using System.Text;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            decimal precoInicial = 0;
            decimal precoPorHora = 0;

            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento! 🅿️\n");

            // --- Solicita e valida o preço inicial ---
            Console.Write("Digite o preço inicial: R$ ");
            while (!decimal.TryParse(Console.ReadLine(), out precoInicial) || precoInicial < 0)
            {
                Console.WriteLine("🚫 Preço inicial inválido. Por favor, digite um valor numérico positivo:");
                Console.Write("Digite o preço inicial: R$ ");
            }

            // --- Solicita e valida o preço por hora ---
            Console.Write("Agora digite o preço por hora: R$ ");
            while (!decimal.TryParse(Console.ReadLine(), out precoPorHora) || precoPorHora < 0)
            {
                Console.WriteLine("🚫 Preço por hora inválido. Por favor, digite um valor numérico positivo:");
                Console.Write("Agora digite o preço por hora: R$ ");
            }

            Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

            bool exibirMenu = true;

            // --- Realiza o loop principal do menu ---
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("✨ Menu do Estacionamento ✨");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");
                Console.Write("Digite a sua opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        es.AdicionarVeiculo();
                        break;

                    case "2":
                        es.RemoverVeiculo();
                        break;

                    case "3":
                        es.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("🚫 Opção inválida. Por favor, digite uma opção de 1 a 4.");
                        // Adicionei uma pausa aqui também para o usuário poder ler a mensagem de erro
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("\n👋 O programa se encerrou. Obrigado por utilizar nosso sistema!");
        }
    }
}