using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Prueba> Prueba { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySQL("server=localhost;port=3306;database=mydb;uid=root;password=12345678;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Descripcion).HasMaxLength(45);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCategoria, "Id_Categoria_FK_idx");

            entity.Property(e => e.Descripcion).HasMaxLength(45);
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("Id_Categoria_FK");
        });

        modelBuilder.Entity<Prueba>(entity =>
        {
            entity.HasKey(e => e.IdPrueba).HasName("PRIMARY");

            entity.Property(e => e.IdPrueba).HasColumnName("idPrueba");
            entity.Property(e => e.Desc)
                .HasMaxLength(45)
                .HasColumnName("desc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
