using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // criar um servidor web
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        app.MapGet("/", PaginaInicial);

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }
}
