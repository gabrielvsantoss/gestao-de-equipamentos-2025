namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

// • Deve ter um identificador único(Id);
// • Deve ter o nome do fabricante;
// • Deve ter o email do fabricante;
// • Deve ter o telefone do fabricante;
public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}
