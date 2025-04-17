using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloSetor;

public class Setor : EntidadeBase
{
    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Responsavel { get; set; }

    public Setor(string nome, string telefone, string responsavel)
    {
        Nome = nome;
        Telefone = telefone;
        Responsavel = responsavel;
    }

    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Setor setorEditado = (Setor)registroEditado;

        Nome = setorEditado.Nome;   
        Telefone= setorEditado.Telefone;
        Responsavel= setorEditado.Responsavel;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";     

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        if (string.IsNullOrWhiteSpace(Responsavel))
            erros += "O campo 'Responsável' é obrigatório.\n";

        if (Responsavel.Length < 3)
            erros += "O campo 'Responsável' precisa conter ao menos 3 caracteres.\n";

        return erros;
    }
}
