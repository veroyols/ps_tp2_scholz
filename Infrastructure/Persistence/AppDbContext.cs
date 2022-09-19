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
        //Declarar las entities
        public DbSet<Cliente> ClienteDb { get; set; }
        public DbSet<Producto> ProductoDb { get; set; }
        public DbSet<Carrito> CarritoDb { get; set; }
        public DbSet<Orden> OrdenDb { get; set; }
        public DbSet<CarritoProducto> CarritoProductoDb { get; set; }
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
        //No sobreescribo el metodo porque lo INYECTO en Program
        //MODELADO -> FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CLIENTE
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente"); 
                entity.HasKey(c => c.ClienteId);
                entity.Property(c => c.ClienteId).ValueGeneratedOnAdd(); //autoincremental
                //RELACION: Carrito
            });
            //PRODUCTO
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(p => p.ProductoId); 
                entity.Property(p => p.ProductoId).ValueGeneratedOnAdd();
                entity.Property(p => p.Precio).HasColumnType("decimal(15, 2)");
                //RELACION: CartPRoduct
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
                    .HasForeignKey(car => car.ClienteId)
                    .IsRequired(false); //?
            });
            //ORDEN
            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(o => o.OrdenId); 
                entity.Property(o => o.Total).HasColumnType("decimal(15, 2)");
                entity
                    .HasOne<Carrito>(o => o.Carrito)
                    .WithOne(c => c.Orden)
                    .HasForeignKey<Carrito>(c => c.CarritoId);  
            });
            //CARRITOPRODUCTO 
            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.ToTable("CarritoProducto");
                entity.HasKey(cp => new { cp.CarritoId, cp.ProductoId });//key

                entity
                    .HasOne<Carrito>(cp => cp.Carrito)
                    .WithMany(cp => cp.CarritoProducto)
                    .HasForeignKey(cp => cp.CarritoId)
                    .IsRequired(false); //?

                entity
                    .HasOne<Producto>(cp => cp.Producto)
                    .WithMany(cp => cp.CarritoProducto)
                    .HasForeignKey(cp => cp.ProductoId);
            });
        }
    }
}
