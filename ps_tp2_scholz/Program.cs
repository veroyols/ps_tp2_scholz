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