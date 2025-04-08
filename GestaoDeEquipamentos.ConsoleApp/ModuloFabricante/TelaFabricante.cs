
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante()
    {
        repositorioFabricante = new RepositorioFabricante();
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Fabricantes");
        Console.WriteLine("--------------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Fabricante");
        Console.WriteLine("2 - Edição de Fabricante");
        Console.WriteLine("3 - Exclusão de Fabricante");
        Console.WriteLine("4 - Visualização de Fabricante");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Fabricante novoFabricante = ObterDadosFabricante();

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public Fabricante ObterDadosFabricante()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o endereço de email do fabricante: ");
        string email = Console.ReadLine();

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        return fabricante;
    }
}
