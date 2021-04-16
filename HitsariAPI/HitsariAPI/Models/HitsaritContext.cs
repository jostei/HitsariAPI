using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HitsariAPI.Models
{
    public partial class HitsaritContext : DbContext
    {
        public HitsaritContext()
        {
        }

        public HitsaritContext(DbContextOptions<HitsaritContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sertifikaatit> Sertifikaatits { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Hitsarit;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Sertifikaatit>(entity =>
            {
                entity.HasKey(e => e.CertificateId);

                entity.ToTable("Sertifikaatit");

                entity.Property(e => e.CertificateId)
                    .HasMaxLength(10)
                    .HasColumnName("CertificateID")
                    .IsFixedLength(true);

                entity.Property(e => e.Myönnetty).HasColumnType("smalldatetime");

                entity.Property(e => e.Pätevyys)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SertifikaatinHaltija)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Voimassa).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.WorkerId)
                    .HasMaxLength(10)
                    .HasColumnName("WorkerID")
                    .IsFixedLength(true);

                entity.Property(e => e.Esimies)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Etunimi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Lisäyspäivä).HasColumnType("smalldatetime");

                entity.Property(e => e.Muokattu).HasColumnType("smalldatetime");

                entity.Property(e => e.Pätevyys1)
                    .HasMaxLength(10)
                    .HasColumnName("Pätevyys_1")
                    .IsFixedLength(true);

                entity.Property(e => e.Pätevyys2)
                    .HasMaxLength(10)
                    .HasColumnName("Pätevyys_2")
                    .IsFixedLength(true);

                entity.Property(e => e.Pätevyys3)
                    .HasMaxLength(10)
                    .HasColumnName("Pätevyys_3")
                    .IsFixedLength(true);

                entity.Property(e => e.Pätevyys4)
                    .HasMaxLength(10)
                    .HasColumnName("Pätevyys_4")
                    .IsFixedLength(true);

                entity.Property(e => e.Sukunimi)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Toimipiste)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
