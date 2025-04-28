using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>, IRepositorioFabricante
{
    public RepositorioFabricanteEmArquivo() : base("fabricantes.json")
    {
    }
}
