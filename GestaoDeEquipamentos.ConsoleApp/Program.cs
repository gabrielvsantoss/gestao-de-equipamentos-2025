using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.ModuloSetor;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp;

public class Animal
{
    public string nome;
    public override string ToString()
    {
        return nome;
    }

    public virtual void Andar()
    {
        Console.WriteLine($"O {nome} está andando... ");
    }
}
public class Cachorro : Animal
{
    public override void Andar()
    {
        Console.WriteLine("Cachorro em ação: ");
        base.Andar();
    }
}

public class Gato : Animal
{
    public override void Andar()
    {
        Console.WriteLine("Gato em ação: ");
        base.Andar();
    }
}

public class Coelho : Animal
{
    public override void Andar()
    {
        Console.WriteLine("Goelho em ação: ");
        base.Andar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var c = new Cachorro();
        c.nome = "Totó";

        var g = new Gato();
        g.nome = "Missi";

        var coelho = new Coelho();
        coelho.nome = "Coelhinho da Pascoa";

        AndarNaTela(g);
        AndarNaTela(c);
        AndarNaTela(coelho);
    }

    static void AndarNaTela(Animal animal)
    {
        Type type = animal.GetType();
        animal.Andar();
    }


    static void Main2(string[] args)
    {       
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            telaPrincipal.ApresentarMenuPrincipal();

            TelaBase telaSelecionada = telaPrincipal.ObterTela();

            char opcaoEscolhida = telaSelecionada.ApresentarMenu();

            if (telaSelecionada is TelaChamado)
            {
                TelaChamado telaChamado = (TelaChamado)telaSelecionada;
                if (opcaoEscolhida == '5')
                {
                    telaChamado.VisualizarChamadosEmAberto();
                }
            }

            switch (opcaoEscolhida)
            {
                case '1': telaSelecionada.CadastrarRegistro(); break;

                case '2': telaSelecionada.EditarRegistro(); break;

                case '3': telaSelecionada.ExcluirRegistro(); break;

                case '4': telaSelecionada.VisualizarRegistros(true); break;

                default: break;
            }           
        }
    }
}
