using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("\n--- Adicionar Veículo ---");
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placaDigitada = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrWhiteSpace(placaDigitada))
            {
                Console.WriteLine("🚫 Placa inválida. Por favor, digite uma placa não vazia.");
            }
            //Verifica se já existe um veículo com essa Placa na lista
            else if (veiculos.Any(v => v.Placa.Equals(placaDigitada, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"⚠️ O veículo com a placa '{placaDigitada}' já está estacionado. Verifique a placa digitada.");
            }
            else
            {
                //Cria uma nova instância de veículo e a adiciona à lista
                Veiculo novoVeiculo = new Veiculo(placaDigitada);
                veiculos.Add(novoVeiculo);
                Console.WriteLine($"✅ Veículo com a placa '{placaDigitada}' estacionado com sucesso às {novoVeiculo.HoraEntrada:HH:mm:ss}!");
            }
            PausaParaContinuar();
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("\n--- Remover Veículo ---");
            Console.Write("Digite a placa do veículo para remover: ");
            string placaDigitada = Console.ReadLine()?.ToUpper();

            //Encontra o veículo na lista pela placa
            // Usa FirstOrDefault para pegar o primeiro que corresponde ou null se não encontrar
            Veiculo veiculoParaRemover = veiculos.FirstOrDefault(v => v.Placa.Equals(placaDigitada, StringComparison.OrdinalIgnoreCase));

            if (veiculoParaRemover != null) // Se o veículo foi encontrado
            {
                //Cálculo do tempo e valor
                DateTime horaSaida = DateTime.Now; // Pega a hora atual do sistema
                TimeSpan duracao = horaSaida - veiculoParaRemover.HoraEntrada; // Calcula a diferença entre as horas

                // Arredonda as horas para cima para garantir que minutos extras contem como uma hora cheia.
                // Exemplo: 2 horas e 10 minutos são cobrados como 3 horas.
                int horasCobradas = (int)Math.Ceiling(duracao.TotalHours);

                // Garante que o mínimo de horas cobradas seja 1, caso a permanência seja muito curta.
                if (horasCobradas == 0 && duracao.TotalMinutes > 0)
                {
                    horasCobradas = 1;
                }
                else if (horasCobradas < 0) // Caso o relógio do sistema seja ajustado para trás, evita valores negativos
                {
                    horasCobradas = 0; // Ou pode-se considerar 1 hora, dependendo da regra de negócio
                }


                decimal valorTotal = precoInicial + (precoPorHora * horasCobradas);

                //Remove o objeto Veiculo encontrado da lista
                veiculos.Remove(veiculoParaRemover);

                Console.WriteLine($"✅ O veículo '{veiculoParaRemover.Placa}' foi removido.");
                Console.WriteLine($"⏱️ Tempo total estacionado: {duracao.TotalMinutes:F0} minutos ({horasCobradas} horas cobradas).");
                Console.WriteLine($"💰 Preço total a ser pago: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine($"🚫 Desculpe, o veículo com a placa '{placaDigitada}' não está estacionado aqui. Verifique se digitou a placa corretamente.");
            }
            PausaParaContinuar();
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("\n--- Veículos Estacionados ---");

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int contador = 1;
                foreach (Veiculo veiculo in veiculos) //Itera sobre objetos Veiculo
                {
                    //Acessa as propriedades Placa e HoraEntrada do objeto Veiculo
                    Console.WriteLine($"{contador}. Placa: {veiculo.Placa} (Entrada: {veiculo.HoraEntrada:dd/MM/yyyy HH:mm:ss})");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("🅿️ Não há veículos estacionados no momento.");
            }
            PausaParaContinuar();
        }

        // Método auxiliar para pausar a execução e o usuário ler a mensagem
        private void PausaParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}