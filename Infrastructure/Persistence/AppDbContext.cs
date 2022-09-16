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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //  optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        //}

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
                entity.HasKey(c => c.ClientId); //key
                entity.Property(c => c.ClientId).ValueGeneratedOnAdd(); //autoincremental
                //relacion 1 a muchos (cart)
             });
            //PRODUCT
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.ProductId); //key
            });
            //CART
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(p => p.CartId); //key

            });
            //ORDER
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(o => o.CartId); //key
            });
            //CARTPRODUCT
            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.ToTable("CartProduct");
                entity.HasKey(c => c.CartId); //key
            });
        }
    }
}
