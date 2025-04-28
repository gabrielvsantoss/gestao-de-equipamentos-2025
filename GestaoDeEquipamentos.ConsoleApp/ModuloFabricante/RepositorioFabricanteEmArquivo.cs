using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>, IRepositorioFabricante
{
    public RepositorioFabricanteEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Fabricante> ObterDados()
    {
        return contexto.Fabricantes;
    }
}