﻿// <auto-generated />
using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MydbContext))]
    partial class MydbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccess.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("DataAccess.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("Id_Categoria");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoria" }, "Id_Categoria_FK_idx");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("DataAccess.Entities.Prueba", b =>
                {
                    b.Property<int>("IdPrueba")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPrueba");

                    b.Property<string>("Desc")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("desc");

                    b.HasKey("IdPrueba")
                        .HasName("PRIMARY");

                    b.ToTable("Prueba");
                });

            modelBuilder.Entity("DataAccess.Entities.Producto", b =>
                {
                    b.HasOne("DataAccess.Entities.Categoria", "IdCategoriaNavigation")
                        .WithMany("Producto")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("Id_Categoria_FK");

                    b.Navigation("IdCategoriaNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Categoria", b =>
                {
                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
