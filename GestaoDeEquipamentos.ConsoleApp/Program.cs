
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEquipamento.CadastrarEquipamento();
                        break;

                    case '2':
                        telaEquipamento.EditarEquipamento();
                        break;

                    case '3':
                        telaEquipamento.ExcluirEquipamento();
                        break;

                    case '4':
                        telaEquipamento.VisualizarEquipamentos(true);
                        break;

                    default: break;
                }
            }

            Console.ReadLine();
        }
        
    }
}
