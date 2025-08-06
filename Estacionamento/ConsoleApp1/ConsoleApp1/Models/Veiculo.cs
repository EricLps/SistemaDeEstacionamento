namespace DesafioFundamentos.Models;

public class Veiculo
{
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }

    public Veiculo(string placa)
    {
        Placa = placa.ToUpper(); // Garante que a placa seja sempre maiúscula
        HoraEntrada = DateTime.Now; // Registra a hora atual do sistema
    }
}