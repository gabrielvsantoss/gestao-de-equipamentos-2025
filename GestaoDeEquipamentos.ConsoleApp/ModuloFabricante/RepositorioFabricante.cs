using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    public Fabricante[] fabricantes = new Fabricante[100];
    public int contadorFabricantes = 0;

    public void CadastrarFabricante(Fabricante novoFabricante)
    {
        novoFabricante.Id = GeradorIds.GerarIdFabricante();

        fabricantes[contadorFabricantes++] = novoFabricante; 
    }
}
