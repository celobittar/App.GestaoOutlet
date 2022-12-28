using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.GestaoOutlet.Data;

public partial class DboutletContext : DbContext
{
    public DboutletContext()
    {
    }

    public DboutletContext(DbContextOptions<DboutletContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<FormaPag> FormaPags { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<StatusPedido> StatusPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MARCELOPC\\SQLEXPRESS;Initial Catalog=DBOutlet;Integrated Security=True;MultipleActiveResultSets=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Idcategoria);

            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.DescricaoCategoria)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FormaPag>(entity =>
        {
            entity.HasKey(e => e.IdformaPag);

            entity.ToTable("FormaPag");

            entity.Property(e => e.IdformaPag).HasColumnName("IDFormaPag");
            entity.Property(e => e.DescricaoFormaPag)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Idmodelo);

            entity.ToTable("Modelo");

            entity.Property(e => e.Idmodelo).HasColumnName("IDModelo");
            entity.Property(e => e.DescricaoModelo)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido);

            entity.ToTable("Pedido");

            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.DtEntrega)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoEntrega)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FaltaPagar)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdformaPag).HasColumnName("IDFormaPag");
            entity.Property(e => e.IdpedidoCategoria).HasColumnName("IDPedidoCategoria");
            entity.Property(e => e.IdpedidoModelo).HasColumnName("IDPedidoModelo");
            entity.Property(e => e.Idstatus).HasColumnName("IDStatus");
            entity.Property(e => e.Qtde)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VlrGasto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VlrRecebido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Idcategoria).WithMany(p => p.Idpedidos)
                .UsingEntity<Dictionary<string, object>>(
                    "PedidoCategorium",
                    r => r.HasOne<Categorium>().WithMany()
                        .HasForeignKey("Idcategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Categoria"),
                    l => l.HasOne<Pedido>().WithMany()
                        .HasForeignKey("Idpedido")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Pedido"),
                    j =>
                    {
                        j.HasKey("Idpedido", "Idcategoria");
                    });

            entity.HasMany(d => d.Idmodelos).WithMany(p => p.Idpedidos)
                .UsingEntity<Dictionary<string, object>>(
                    "PedidoModelo",
                    r => r.HasOne<Modelo>().WithMany()
                        .HasForeignKey("Idmodelo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Modelo"),
                    l => l.HasOne<Pedido>().WithMany()
                        .HasForeignKey("Idpedido")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PedidoM"),
                    j =>
                    {
                        j.HasKey("Idpedido", "Idmodelo");
                        j.ToTable("PedidoModelo");
                    });
        });

        modelBuilder.Entity<StatusPedido>(entity =>
        {
            entity.HasKey(e => e.Idstatus);

            entity.ToTable("StatusPedido");

            entity.Property(e => e.Idstatus).HasColumnName("IDStatus");
            entity.Property(e => e.DescricaoStatus)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
