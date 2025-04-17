using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloSetor;

public class TelaSetor : TelaBase //classe mãe, superclasse, classe base
{
    private RepositorioSetor repositorioSetor;

    public TelaSetor(RepositorioSetor repositorioSetor) 
        : base("Setor", repositorioSetor)
    {
        this.repositorioSetor = repositorioSetor;
    }

    public override EntidadeBase ObterDados()
    {
        Console.Write("Digite o nome do setor: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone do setor: ");
        string telefone = Console.ReadLine();

        Console.Write("Digite o responsável pelo setor: ");
        string responsavel = Console.ReadLine();

        Setor setor = new Setor(nome, telefone, responsavel);

        return setor;
    }

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine("Visualizando Setores...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -30} | {2, -30} | {3, -20}",
            "Id", "Nome", "Telefone", "Responsável"
        );

        EntidadeBase[] registros = repositorioSetor.SelecionarRegistros();
        Setor[] setoresCadastrados = new Setor[registros.Length];

        for (int i = 0; i < registros.Length; i++)
            setoresCadastrados[i] = (Setor)registros[i];

        for (int i = 0; i < setoresCadastrados.Length; i++)
        {
            Setor s = setoresCadastrados[i];

            if (s == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -30} | {2, -30} | {3, -20}",
                s.Id, s.Nome, s.Telefone, s.Responsavel
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}
