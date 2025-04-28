using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public class ContextoDados
{
    public List<Fabricante> Fabricantes { get; set; }
    public List<Equipamento> Equipamentos { get; set; }
    public List<Chamado> Chamados { get; set; }

    private string pastaArmazenamento = "C:\\temp";
    private string arquivoArmazenamento = "dados.json";

    public ContextoDados()
    {
        Fabricantes = new List<Fabricante>();
        Equipamentos = new List<Equipamento>();
        Chamados = new List<Chamado>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        options.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, options);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, jsonString);
    }

    private void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto))
            return;

        string jsonString = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(jsonString))
            return;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados dadosArmazenados = JsonSerializer.Deserialize<ContextoDados>(jsonString, options);

        if (dadosArmazenados == null) return;

        this.Fabricantes = dadosArmazenados.Fabricantes;
        this.Equipamentos = dadosArmazenados.Equipamentos;
        this.Chamados = dadosArmazenados.Chamados;
    }
}
