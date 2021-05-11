﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project_SPA.Models.Entities
{
    public partial class IF4101_2021_SPAContext : DbContext
    {
        public IF4101_2021_SPAContext()
        {
        }

        public IF4101_2021_SPAContext(DbContextOptions<IF4101_2021_SPAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<ProfessorCourseGroup> ProfessorCourseGroups { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourseGroup> StudentCourseGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=IF4101_2021_SPA;User ID=laboratorios;Password=KmZpo.2796");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AcademicDegree>(entity =>
            {
                entity.ToTable("AcademicDegree");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Course");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.AcademicDegreeId).HasColumnName("AcademicDegree_Id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");
            });

            modelBuilder.Entity<ProfessorCourseGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Professor_Course_Group");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("Gorup_Id");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Professor_Course_Course");

                entity.HasOne(d => d.Gorup)
                    .WithMany()
                    .HasForeignKey(d => d.GorupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Professor_Course_Group_Group");

                entity.HasOne(d => d.Professor)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Professor_Course_Professor");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");
            });

            modelBuilder.Entity<StudentCourseGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student_Course_Group");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Update_User")
                    .HasDefaultValueSql("('DBA')");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Group_Course");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Group_Group");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Group_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}