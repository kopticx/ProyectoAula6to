using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PapeleriaIPN.Models
{
    public partial class PapeleriaContext : DbContext
    {
        public PapeleriaContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__9D335DC3031885CD");

                entity.ToTable("Pedido");

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Pedido__IdProduc__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pedido__IdUsuari__3E52440B");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210B9E38FD3");

                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ImagenUrl1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoUsua__9E3A29A5D8A999C7");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipo).ValueGeneratedOnAdd();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Usuario__B7C92638B3526423");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK__Usuario__UserTyp__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
