using System.Text.Json;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
{
    private List<T> registros = new List<T>();
    private int contadorIds = 0;
    private string nomeArquivo;

    protected RepositorioBaseEmArquivo(string nomeArquivo)
    {
        this.nomeArquivo = nomeArquivo;

        registros = Desserializar();

        int maiorId = 0;

        foreach (var item in registros)
        {
            if (item.Id > maiorId)
                maiorId = item.Id;
        }

        contadorIds = maiorId;
    }

    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);

        Serializar();
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (T item in registros)
        {
            if (item.Id == idRegistro)
            {
                item.AtualizarRegistro(registroEditado);

                Serializar();

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        T registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado != null)
        {
            registros.Remove(registroSelecionado);

            Serializar();

            return true;
        }

        return false;
    }

    public List<T> SelecionarRegistros()
    {
        return registros;
    }

    public T SelecionarRegistroPorId(int idRegistro)
    {
        foreach (T item in registros)
        {
            if (item.Id == idRegistro)
                return item;
        }

        return null;
    }

    protected void Serializar()
    {
        string pastaArmazenamento = "C:\\temp";
        string caminhoCompleto = Path.Combine(pastaArmazenamento, nomeArquivo);

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string jsonString = JsonSerializer.Serialize(registros, options);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, jsonString);
    }

    protected List<T> Desserializar()
    {
        string pastaArmazenamento = "C:\\temp";
        string caminhoCompleto = Path.Combine(pastaArmazenamento, nomeArquivo);

        if (!File.Exists(caminhoCompleto))
            return new List<T>();

        string jsonString = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(jsonString))
            return new List<T>();

        return JsonSerializer.Deserialize<List<T>>(jsonString)!;
    }
}
