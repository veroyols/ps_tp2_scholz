using Application.Interfaces;
using Application.UseCase;
using Application.UseCase.CartProduct;
using Application.UseCase.Client;
using Application.UseCase.Order;
using Application.UseCase.Product;
using Infrastructure.cqrs_Command;
using Infrastructure.cqrs_Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

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

builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderQuery, OrderQuery>();
builder.Services.AddScoped<IOrderCommand, OrderCommand>();

builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<ICartQuery, CartQuery>();
builder.Services.AddScoped<ICartCommand, CartCommand>();

builder.Services.AddScoped<ICartProductServices, CartProducServices>();
builder.Services.AddScoped<ICartProductCommand, CartProductCommand>();
builder.Services.AddScoped<ICartProductQuery, CartProductQuery>();

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

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();