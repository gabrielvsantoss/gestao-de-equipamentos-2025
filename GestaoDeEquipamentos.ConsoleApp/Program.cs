using System.Text;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {// criar um servidor web
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        // mapeamento de rotas
        app.MapGet("/", OlaMundo);

        app.Run();
    }


    static Task OlaMundo(HttpContext context)
    {
        return context.Response.WriteAsync("Olá, mundo!");
    }
}
