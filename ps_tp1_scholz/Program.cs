using Application.Interfaces;
using Application.UseCase.Client;
using Application.UseCase.Order;
using Application.UseCase.Product;
using Infrastructure.cqrs_Command;
using Infrastructure.cqrs_Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();//
builder.Services.AddSwaggerGen();//

// INYECCION POR DEPENDENCIAS
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IClientCommand, ClientCommand>();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductQuery, ProductQuery>();
builder.Services.AddScoped<IProductCommand, ProductCommand>();

builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderQuery, OrderQuery>();
builder.Services.AddScoped<IOrderCommand, OrderCommand>();

//ConectionString
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

//CONSOLE
bool m = true;
do
{
    Console.Clear();
    Console.WriteLine("MENU DE OPCIONES");
    Console.WriteLine("1. Opci�n 1");
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
        Console.Write(e.Message + " \nPress any key to continue . . . ");
        Console.ReadKey(true);
    }
    catch (Exception e)
    {
        Console.Write(e.Message + " \nPress any key to continue . . . ");
        Console.ReadKey(true);
    }
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
                Console.WriteLine("Ingreso la opci�n 1");
                Console.WriteLine("--------------------");
                m1 = Menu1();
            }
            return true;
        case 4:
            Console.WriteLine("Gracias");
            Console.WriteLine("-------");
            return false;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

//MENU1
static bool Menu1()
{
    Console.Clear();
    Console.WriteLine("MENU1");
    Console.WriteLine("1. Opci�n 1");
    Console.WriteLine("2. Opci�n 2");
    Console.WriteLine("7) Volver al menu anterior");
    Console.Write("\r\nSeleccione una opci�n: ");

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

//fin menu
