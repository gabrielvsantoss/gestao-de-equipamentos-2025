using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.ModuloSetor;

namespace GestaoDeEquipamentos.ConsoleApp.Util;

public class TelaPrincipal
{
    public char opcaoPrincipal;

    RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
    RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
    RepositorioSetor repositorioSetor = new RepositorioSetor();
    RepositorioChamado repositorioChamado = new RepositorioChamado();

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fabricantes");
        Console.WriteLine("2 - Controle de Equipamentos");
        Console.WriteLine("3 - Controle de Chamados");
        Console.WriteLine("4 - Controle de Setores");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolhoerOpcao();
    }

    internal TelaBase ObterTela()
    {
        if (opcaoPrincipal == '1')        
            return new TelaFabricante(repositorioFabricante);
        
        else if (opcaoPrincipal == '2')        
            return new TelaEquipamento(repositorioEquipamento, repositorioFabricante, repositorioSetor);
        
        else if (opcaoPrincipal == '3')        
            return new TelaChamado(repositorioChamado, repositorioEquipamento);
        
        else if (opcaoPrincipal == '4')        
            return new TelaSetor(repositorioSetor);

        return null;
    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}