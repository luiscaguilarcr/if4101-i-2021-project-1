using System;
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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AppointmentAttendance> AppointmentAttendances { get; set; }
        public virtual DbSet<AttendanceProfessorCourseGroup> AttendanceProfessorCourseGroups { get; set; }
        public virtual DbSet<AttendanceSchedule> AttendanceSchedules { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<ProfessorCourseGroup> ProfessorCourseGroups { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourseGroup> StudentCourseGroups { get; set; }
        public virtual DbSet<TemporalAppointmentAttendance> TemporalAppointmentAttendances { get; set; }
        public virtual DbSet<TemporalStudent> TemporalStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=IF4101_2021_SPA;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AcademicDegreeId).HasColumnName("AcademicDegree_Id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<AppointmentAttendance>(entity =>
            {
                entity.ToTable("Appointment_Attendance");

                entity.Property(e => e.AttendanceId).HasColumnName("Attendance_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.EndDateHour)
                    .HasColumnType("date")
                    .HasColumnName("End_Date_Hour");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");

                entity.Property(e => e.StartDateHour)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date_Hour");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            });

            modelBuilder.Entity<AttendanceProfessorCourseGroup>(entity =>
            {
                entity.ToTable("Attendance_Professor_Course_Group");

                entity.Property(e => e.AttendanceScheduleId).HasColumnName("Attendance_Schedule_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");
            });

            modelBuilder.Entity<AttendanceSchedule>(entity =>
            {
                entity.ToTable("AttendanceSchedule");

                entity.Property(e => e.EndDateHour).HasColumnName("End_Date_Hour");

                entity.Property(e => e.StartDateHour).HasColumnName("Start_Date_Hour");
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
                    .HasDefaultValueSql("('DBA')");

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
                    .HasDefaultValueSql("('DBA')");

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

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.AcademicDegreeId).HasColumnName("AcademicDegree_Id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

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
                    .HasDefaultValueSql("('DBA')");

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

                entity.HasOne(d => d.Professor)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Professor_Course_Group_Professor");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreationUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Creation_User")
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

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
            });

            modelBuilder.Entity<TemporalAppointmentAttendance>(entity =>
            {
                entity.ToTable("TemporalAppointment_Attendance");

                entity.Property(e => e.AttendanceId).HasColumnName("Attendance_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.EndDateHour)
                    .HasColumnType("date")
                    .HasColumnName("End_Date_Hour");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");

                entity.Property(e => e.StartDateHour)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date_Hour");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            });

            modelBuilder.Entity<TemporalStudent>(entity =>
            {
                entity.ToTable("TemporalStudent");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
