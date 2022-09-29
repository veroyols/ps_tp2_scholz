﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220927162357_tp2")]
    partial class tp2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.Property<Guid>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("CarritoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carrito", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarritoProducto", b =>
                {
                    b.Property<Guid>("CarritoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("CarritoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CarritoProducto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Apellido = "",
                            DNI = "",
                            Direccion = "",
                            Nombre = "admin",
                            Telefono = ""
                        });
                });

            modelBuilder.Entity("Domain.Entities.Orden", b =>
                {
                    b.Property<Guid>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarritoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("OrdenId");

                    b.HasIndex("CarritoId")
                        .IsUnique();

                    b.ToTable("Orden", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto", (string)null);

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Codigo = "ps2c2022-01",
                            Descripcion = "Remera de algodon lisa, varios colores.",
                            Image = "remera.png",
                            Marca = "Simpl",
                            Nombre = "Remera",
                            Precio = 3000.00m
                        },
                        new
                        {
                            ProductoId = 2,
                            Codigo = "ps2c2022-02",
                            Descripcion = "Buzo de friza liso, varios colores.",
                            Image = "buzo.png",
                            Marca = "Simpl",
                            Nombre = "Buzo",
                            Precio = 4000.00m
                        },
                        new
                        {
                            ProductoId = 3,
                            Codigo = "ps2c2022-03",
                            Descripcion = "Canguro de friza liso, varios colores.",
                            Image = "canguro.png",
                            Marca = "Simpl",
                            Nombre = "Buzo Canguro",
                            Precio = 4500.00m
                        },
                        new
                        {
                            ProductoId = 4,
                            Codigo = "ps2c2022-04",
                            Descripcion = "Campera de frisa lisa, varios colores.",
                            Image = "campera.png",
                            Marca = "Simpl",
                            Nombre = "Campera",
                            Precio = 5000.00m
                        },
                        new
                        {
                            ProductoId = 5,
                            Codigo = "ps2c2022-05",
                            Descripcion = "Musculosa de algodon lisa, varios colores.",
                            Image = "musculosa.png",
                            Marca = "Simpl",
                            Nombre = "Musculosa",
                            Precio = 2700.00m
                        },
                        new
                        {
                            ProductoId = 6,
                            Codigo = "ps2c2022-06",
                            Descripcion = "Pantalon jogging de friza.",
                            Image = "jogging.png",
                            Marca = "Simpl",
                            Nombre = "Pantalon Jogging",
                            Precio = 4700.00m
                        },
                        new
                        {
                            ProductoId = 7,
                            Codigo = "ps2c2022-07",
                            Descripcion = "Campera de jean corta.",
                            Image = "campera.png",
                            Marca = "Simpl",
                            Nombre = "Campera Jean",
                            Precio = 4900.00m
                        },
                        new
                        {
                            ProductoId = 8,
                            Codigo = "ps2c2022-08",
                            Descripcion = "Pantalon de jean claro.",
                            Image = "jean.png",
                            Marca = "Simpl",
                            Nombre = "Pantalon Jean",
                            Precio = 6300.00m
                        },
                        new
                        {
                            ProductoId = 9,
                            Codigo = "ps2c2022-09",
                            Descripcion = "Sweater Bremer Negro.",
                            Image = "bremer.png",
                            Marca = "Simpl",
                            Nombre = "Sweater Bremer Negro",
                            Precio = 5100.00m
                        },
                        new
                        {
                            ProductoId = 10,
                            Codigo = "ps2c2022-10",
                            Descripcion = "Camiseta algodon, varios colores.",
                            Image = "camiseta.png",
                            Marca = "Simpl",
                            Nombre = "Camiseta",
                            Precio = 5200.00m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Carritos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.CarritoProducto", b =>
                {
                    b.HasOne("Domain.Entities.Carrito", "Carrito")
                        .WithMany("CarritoProducto")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Producto", "Producto")
                        .WithMany("CarritoProducto")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Domain.Entities.Orden", b =>
                {
                    b.HasOne("Domain.Entities.Carrito", "Carrito")
                        .WithOne("Orden")
                        .HasForeignKey("Domain.Entities.Orden", "CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.Navigation("CarritoProducto");

                    b.Navigation("Orden")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Carritos");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("CarritoProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
