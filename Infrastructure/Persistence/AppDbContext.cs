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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base() { }
        //Declarar las entities
        public DbSet<Client> ClientDb { get; set; }
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<Cart> CartDb { get; set; }
        public DbSet<Order> OrderDb { get; set; }
        public DbSet<CartProduct> CartProductDb { get; set; }

        //MODELADO -> FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CLIENT
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client"); //nombre de la tabla
                entity.HasKey(c => c.ClientId); //int key
                entity.Property(c => c.ClientId).ValueGeneratedOnAdd(); //autoincremental
                //RELACION: Cart
            });
            //PRODUCT
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.ProductId); //key
                entity.Property(p => p.ProductId).ValueGeneratedOnAdd(); //autoincremental
                entity.Property(p => p.Price).HasColumnType("decimal(15, 2)");
                //RELACION: CartPRoduct
            });
            //CART
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(c => c.CartId); //key
                entity.Property(c => c.CartId).HasColumnType("UUID");//?
                //clientetoIdFK
                entity
                    .HasOne<Client>(cart => cart.Client)
                    .WithMany(cli => cli.Carts)
                    .HasForeignKey(cli => cli.ClientId);
            });
            //ORDER ok
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(o => o.CartId); //key
                entity.Property(o => o.Total).HasColumnType("decimal(15, 2)");
                entity
                    .HasOne<Cart>(o => o.Cart)
                    .WithOne(cart => cart.Order)
                    .HasForeignKey<Cart>(cart => cart.CartId); //FK
            });
            //CART/PRODUCT 
            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.ToTable("CartProduct");
                entity.HasKey(cp => new { cp.CartId, cp.ProductId });//key

                entity
                    .HasOne<Cart>(cp => cp.Cart)
                    .WithMany(cp => cp.CartProduct)
                    .HasForeignKey(cp => cp.CartId);

                entity
                    .HasOne<Product>(cp => cp.Product)
                    .WithMany(cp => cp.CartProduct)
                    .HasForeignKey(cp => cp.ProductId);
            });
        }
    }
}
