using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        //ENTITIES
        public DbSet<Cliente> ClienteDb { get; set; }
        public DbSet<Producto> ProductoDb { get; set; }
        public DbSet<Carrito> CarritoDb { get; set; }
        public DbSet<Orden> OrdenDb { get; set; }
        public DbSet<CarritoProducto> CarritoProductoDb { get; set; }
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //bd - se INYECTO en Program
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=VeronicaScholz;Trusted_Connection=True;");
        //}

        //MODELADO -> FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CLIENTE
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(c => c.ClienteId);
                entity.Property(c => c.ClienteId).ValueGeneratedOnAdd();
                entity.HasData(
                    new Cliente
                    {
                        ClienteId = 1,
                        Nombre = "admin",
                        Apellido = "",
                        DNI = "",
                        Direccion = "",
                        Telefono = ""
                    });
                //RELACION: Carrito
            });
            //PRODUCTO
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(p => p.ProductoId);
                entity.Property(p => p.ProductoId).ValueGeneratedOnAdd();
                entity.Property(p => p.Precio).HasColumnType("decimal(15, 2)");
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 1,
                        Nombre = "Remera",
                        Descripcion = "Remera de algodon lisa, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-01",
                        Precio = 3000.00M,
                        Image = "remera.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 2,
                        Nombre = "Buzo",
                        Descripcion = "Buzo de friza liso, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-02",
                        Precio = 4000.00M,
                        Image = "buzo.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 3,
                        Nombre = "Buzo Canguro",
                        Descripcion = "Canguro de friza liso, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-03",
                        Precio = 4500.00M,
                        Image = "canguro.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 4,
                        Nombre = "Campera",
                        Descripcion = "Campera de frisa lisa, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-04",
                        Precio = 5000.00M,
                        Image = "campera.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 5,
                        Nombre = "Musculosa",
                        Descripcion = "Musculosa de algodon lisa, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-05",
                        Precio = 2700.00M,
                        Image = "musculosa.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 6,
                        Nombre = "Pantalon Jogging",
                        Descripcion = "Pantalon jogging de friza.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-06",
                        Precio = 4700.00M,
                        Image = "jogging.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 7,
                        Nombre = "Campera Jean",
                        Descripcion = "Campera de jean corta.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-07",
                        Precio = 4900.00M,
                        Image = "campera.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 8,
                        Nombre = "Pantalon Jean",
                        Descripcion = "Pantalon de jean claro.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-08",
                        Precio = 6300.00M,
                        Image = "jean.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 9,
                        Nombre = "Sweater Bremer Negro",
                        Descripcion = "Sweater Bremer Negro.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-09",
                        Precio = 5100.00M,
                        Image = "bremer.png"
                    });
                entity.HasData(
                    new Producto
                    {
                        ProductoId = 10,
                        Nombre = "Camiseta",
                        Descripcion = "Camiseta algodon, varios colores.",
                        Marca = "Simpl",
                        Codigo = "ps2c2022-10",
                        Precio = 5200.00M,
                        Image = "camiseta.png"
                    });
                //RELACION: CartPRoduct?
            });

            //ORDEN
            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(o => o.OrdenId);
                entity.Property(o => o.Total).HasColumnType("decimal(15, 2)");
                //entity
                //.HasOne<Carrito>(o => o.Carrito)
                //.WithOne(c => c.Orden)
                //.HasForeignKey<Carrito>(c => c.CarritoId);
            });

            //CARRITO
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");
                entity.HasKey(c => c.CarritoId);
                //clienteFK
                entity
                    .HasOne<Cliente>(car => car.Cliente)
                    .WithMany(cli => cli.Carritos)
                    .HasForeignKey(car => car.ClienteId);
                entity
                    .HasOne<Orden>(car => car.Orden)
                    .WithOne(x => x.Carrito)
                    .HasForeignKey<Orden>(x => x.CarritoId);
            });

            //CARRITOPRODUCTO 
            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.ToTable("CarritoProducto");
                entity.HasKey(cp => new { cp.CarritoId, cp.ProductoId });

                entity
                    .HasOne<Carrito>(cp => cp.Carrito)
                    .WithMany(c => c.CarritoProducto)
                    .HasForeignKey(cp => cp.CarritoId);
                entity
                    .HasOne<Producto>(cp => cp.Producto)
                    .WithMany(p => p.CarritoProducto)
                    .HasForeignKey(cp => cp.ProductoId);
            });
        }
    }
}
