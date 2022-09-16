using Application.Interfaces;
using Application.UseCase.Client;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INYECCION POR DEPENDENCIAS
builder.Services.AddTransient<IClientServices, ClientServices>(); 

//CONEXION A bd
var conectionString = builder.Configuration["ConectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conectionString));

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Menu
bool m = true;
do
{
    //Console.Clear();
    Console.WriteLine("MENU DE OPCIONES");
    Console.WriteLine("1. Opción 1");
    Console.WriteLine("4. Salir");
    Console.Write("Ingrese un numero: ");

    try
    {
        int opt = int.Parse(Console.ReadLine());
        m = MenuPrincipal(opt);
    }
    catch (FormatException e)
    {
        Console.Write(e.Message + " \nPress any key to continue . . . ");
        Console.ReadKey(true);
    }
    catch (OverflowException e)
    {
        Console.Write(e.Message + " Press any key to continue . . . ");
        Console.ReadKey(true);
    }
    catch (Exception e)
    {
        Console.Write(e.Message + " Ingrese un numero. Press any key to continue . . . ");
        Console.ReadKey(true);
    }
    //catch: si esta vacio -> "No ha ingresado ningun numero."

}
while (m);

Console.Write("Press any key to continue . . . ");
Console.ReadKey(true);

//MENU PRINCIPAL
bool MenuPrincipal(int opt)
{
    switch (opt)
    {
        case 1:
            bool m1 = true;
            while (m1)
            {
                Console.WriteLine("Ingreso la opción 1");
                Console.WriteLine("--------------------");
                m1 = Menu1();
            }
            return true;
        case 4:
            Console.WriteLine("Gracias");
            Console.WriteLine("-------");
            return false;
        default:
            Console.WriteLine("Debe ingresar un numero entre 1 y 3");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            return true;
    }
}

//MENU1
static bool Menu1()
{
    Console.Clear();
    Console.WriteLine("MENU1");
    Console.WriteLine("1. Opción 1");
    Console.WriteLine("2. Opción 2");
    Console.WriteLine("7) Volver al menu anterior");
    Console.Write("\r\nSeleccione una opción: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Ha elegido 1");
            Console.WriteLine("Presione una tecla para volver al menu...");
            Console.ReadKey(true);
            return true;
        case "2":
            Console.WriteLine("Ha elegido 2");
            Console.WriteLine("Presione una tecla para volver al menu...");
            Console.ReadKey(true);
            return true;
        case "7":
            Console.Clear();
            return false;
        default:
            return true;
    }
}
