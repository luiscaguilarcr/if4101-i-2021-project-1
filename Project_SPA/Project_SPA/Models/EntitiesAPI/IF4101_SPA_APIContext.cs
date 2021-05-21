using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project_SPA.Models.EntitiesAPI
{
    public partial class IF4101_SPA_APIContext : DbContext
    {
        public IF4101_SPA_APIContext()
        {
        }

        public IF4101_SPA_APIContext(DbContextOptions<IF4101_SPA_APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=IF4101_SPA_API;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrip)
                    .IsRequired()
                    .HasColumnName("descrip");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.Property(e => e.NewsTitle)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("news_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
