using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Music_Player.Models;

public partial class MusicPlayerContext : DbContext
{
    public MusicPlayerContext()
    {
    }

    public MusicPlayerContext(DbContextOptions<MusicPlayerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artista> Artista { get; set; }

    public virtual DbSet<BitacoraUsuario> BitacoraUsuario { get; set; }

    public virtual DbSet<Cancion> Cancion { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vistaultrasuperperrona> Vistaultrasuperperrona { get; set; }

    public virtual DbSet<VwCancionesfavoritas> VwCancionesfavoritas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Music_Player;password=root;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Artista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("artista");

            entity.HasIndex(e => e.IdGenero, "fk_Artista_Genero_idx");

            entity.Property(e => e.Apodo).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nacionalidad).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TotalCanciones).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Artista)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Artista_Genero");
        });

        modelBuilder.Entity<BitacoraUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bitacora_usuario");

            entity.HasIndex(e => e.IdUsuario, "fk_Bitacora_Usuario");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaAgregada)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.BitacoraUsuario)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_Bitacora_Usuario");
        });

        modelBuilder.Entity<Cancion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cancion");

            entity.HasIndex(e => e.IdArtista, "fk_Musica_Artista");

            entity.HasIndex(e => e.IdGenero, "fk_Musica_Genero");

            entity.HasIndex(e => e.IdUsuario, "fk_Musica_Usuario");

            entity.Property(e => e.Duracion).HasMaxLength(45);
            entity.Property(e => e.FechaAgregada)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.MeGusta).HasDefaultValueSql("'0'");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdArtistaNavigation).WithMany(p => p.Cancion)
                .HasForeignKey(d => d.IdArtista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Musica_Artista");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Cancion)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Musica_Genero");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cancion)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Musica_Usuario");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genero");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TotalCanciones).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.CorreoElectronico, "CorreoElectronico").IsUnique();

            entity.HasIndex(e => e.IdRol, "fk_Usuario_Rol");

            entity.Property(e => e.Contraseña).HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_Usuario_Rol");
        });

        modelBuilder.Entity<Vistaultrasuperperrona>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vistaultrasuperperrona");

            entity.Property(e => e.Apodo).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Genero).HasMaxLength(100);
            entity.Property(e => e.Nacionalidad).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<VwCancionesfavoritas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_cancionesfavoritas");

            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
