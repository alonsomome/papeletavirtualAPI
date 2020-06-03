using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace papeletavirtualapp.Models
{
    public partial class PapeletaVirtualDBContext : DbContext
    {
        public PapeletaVirtualDBContext()
        {
        }

        public PapeletaVirtualDBContext(DbContextOptions<PapeletaVirtualDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autoridad> Autoridad { get; set; }
        public virtual DbSet<Infraccion> Infraccion { get; set; }
        public virtual DbSet<Infractor> Infractor { get; set; }
        public virtual DbSet<Licencia> Licencia { get; set; }
        public virtual DbSet<Papeleta> Papeleta { get; set; }
        public virtual DbSet<Placa> Placa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HJ16PM0\\SQLEXPRESS;Database=PapeletaVirtualDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autoridad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cip)
                    .HasColumnName("cip")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Infraccion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Infractor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdLicencia).HasColumnName("id_licencia");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.IdLicenciaNavigation)
                    .WithMany(p => p.Infractor)
                    .HasForeignKey(d => d.IdLicencia)
                    .HasConstraintName("FK_Infractor_Licencia");
            });

            modelBuilder.Entity<Licencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumLicencia)
                    .HasColumnName("numLicencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Restriction)
                    .HasColumnName("restriction")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Papeleta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .IsUnicode(false);

                entity.Property(e => e.IdAutoridad).HasColumnName("id_autoridad");

                entity.Property(e => e.IdInfraccion).HasColumnName("id_infraccion");

                entity.Property(e => e.IdInfractor).HasColumnName("id_infractor");

                entity.Property(e => e.IdPlaca).HasColumnName("id_placa");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .IsUnicode(false);

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.IdAutoridadNavigation)
                    .WithMany(p => p.Papeleta)
                    .HasForeignKey(d => d.IdAutoridad)
                    .HasConstraintName("FK_Papeleta_Autoridad");

                entity.HasOne(d => d.IdInfraccionNavigation)
                    .WithMany(p => p.Papeleta)
                    .HasForeignKey(d => d.IdInfraccion)
                    .HasConstraintName("FK_Papeleta_Infraccion");

                entity.HasOne(d => d.IdInfractorNavigation)
                    .WithMany(p => p.Papeleta)
                    .HasForeignKey(d => d.IdInfractor)
                    .HasConstraintName("FK_Papeleta_Infractor");

                entity.HasOne(d => d.IdPlacaNavigation)
                    .WithMany(p => p.Papeleta)
                    .HasForeignKey(d => d.IdPlaca)
                    .HasConstraintName("FK_Papeleta_Placa");
            });

            modelBuilder.Entity<Placa>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarBrand)
                    .HasColumnName("carBrand")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarModel)
                    .HasColumnName("carModel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumPlaca)
                    .HasColumnName("numPlaca")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransportDetails)
                    .HasColumnName("transportDetails")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
