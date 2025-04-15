namespace GestaoDeEquipamentos.ConsoleApp;

public class ContaCorrente
{
    public decimal Saldo { get; private set; }

    public string Responsavel;

    public void Sacar(decimal valor)
    {
        Saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }
}
