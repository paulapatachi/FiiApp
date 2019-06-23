using FiiApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiiApp.Data.Context
{
    public class FiiAppContext : DbContext
    {
        public FiiAppContext() { }

        public FiiAppContext(DbContextOptions<FiiAppContext> options)
            : base(options) { }

        public virtual DbSet<Citizenship> Citizenship { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseStatus> CourseStatus { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<EvaluationType> EvaluationType { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentTest> StudentTest { get; set; }
        public virtual DbSet<StudentToClass> StudentToClass { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeacherToCourse> TeacherToCourse { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<FinalGrade> FinalGrade { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Citizenship>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Class>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Course>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.HasOne(d => d.Status)
        //            .WithMany(p => p.Course)
        //            .HasForeignKey(d => d.StatusId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Course_CourseStatus");
        //    });

        //    modelBuilder.Entity<CourseStatus>(entity =>
        //    {
        //        entity.Property(e => e.Abbreviation)
        //            .IsRequired()
        //            .HasMaxLength(10);

        //        entity.Property(e => e.Status)
        //            .IsRequired()
        //            .HasMaxLength(30);
        //    });

        //    modelBuilder.Entity<Evaluation>(entity =>
        //    {
        //        entity.Property(e => e.MaxScore).HasColumnType("decimal(18, 5)");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.HasOne(d => d.Course)
        //            .WithMany(p => p.Evaluation)
        //            .HasForeignKey(d => d.CourseId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Evaluation_Course");

        //        entity.HasOne(d => d.Type)
        //            .WithMany(p => p.Evaluation)
        //            .HasForeignKey(d => d.TypeId)
        //            .HasConstraintName("FK_Evaluation_EvaluationType");
        //    });

        //    modelBuilder.Entity<EvaluationType>(entity =>
        //    {
        //        entity.Property(e => e.Abbreviation).HasMaxLength(10);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Grade>(entity =>
        //    {
        //        entity.Property(e => e.EvalDate).HasColumnType("date");

        //        entity.Property(e => e.GradeValue).HasColumnType("decimal(18, 5)");

        //        entity.Property(e => e.Score).HasColumnType("decimal(18, 5)");

        //        entity.HasOne(d => d.Evaluation)
        //            .WithMany(p => p.Grade)
        //            .HasForeignKey(d => d.EvaluationId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Grade_Evaluation");

        //        entity.HasOne(d => d.Student)
        //            .WithMany(p => p.Grade)
        //            .HasForeignKey(d => d.StudentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Grade_Student");

        //        entity.HasOne(d => d.Teacher)
        //            .WithMany(p => p.Grade)
        //            .HasForeignKey(d => d.TeacherId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Grade_Teacher");
        //    });

        //    modelBuilder.Entity<Nationality>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.Property(e => e.Address).HasMaxLength(255);

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        //        entity.Property(e => e.Email).HasMaxLength(255);

        //        entity.Property(e => e.FatherInitials).HasMaxLength(10);

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.PhoneNumber).HasMaxLength(255);

        //        entity.Property(e => e.RegistrationNumber)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.Citizenship)
        //            .WithMany(p => p.Student)
        //            .HasForeignKey(d => d.CitizenshipId)
        //            .HasConstraintName("FK_Student_Citizenship");

        //        entity.HasOne(d => d.Nationality)
        //            .WithMany(p => p.Student)
        //            .HasForeignKey(d => d.NationalityId)
        //            .HasConstraintName("FK_Student_Nationality");

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.Student)
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("FK_Student_User");
        //    });

        //    modelBuilder.Entity<StudentTest>(entity =>
        //    {
        //        entity.Property(e => e.DateOfBirth).HasColumnType("smalldatetime");

        //        entity.Property(e => e.FatherInitial).HasMaxLength(5);

        //        entity.Property(e => e.FirstName).HasMaxLength(100);

        //        entity.Property(e => e.LastName).HasMaxLength(100);

        //        entity.Property(e => e.NumarMatricol).HasMaxLength(13);
        //    });

        //    modelBuilder.Entity<StudentToClass>(entity =>
        //    {
        //        entity.HasOne(d => d.Class)
        //            .WithMany(p => p.StudentToClass)
        //            .HasForeignKey(d => d.ClassId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_StudentToClass_Class");

        //        entity.HasOne(d => d.Student)
        //            .WithMany(p => p.StudentToClass)
        //            .HasForeignKey(d => d.StudentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_StudentToClass_Student");
        //    });

        //    modelBuilder.Entity<Teacher>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        //        entity.Property(e => e.Email).HasMaxLength(255);

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.PhoneNumber).HasMaxLength(255);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //    });

        //    modelBuilder.Entity<TeacherToCourse>(entity =>
        //    {
        //        entity.HasOne(d => d.Course)
        //            .WithMany(p => p.TeacherToCourse)
        //            .HasForeignKey(d => d.CourseId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_TeacherToCourse_Course");

        //        entity.HasOne(d => d.Teacher)
        //            .WithMany(p => p.TeacherToCourse)
        //            .HasForeignKey(d => d.TeacherId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_TeacherToCourse_Teacher");
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.Property(e => e.Password).HasMaxLength(255);

        //        entity.Property(e => e.Role).HasMaxLength(255);

        //        entity.Property(e => e.UserGuid).HasMaxLength(255);

        //        entity.Property(e => e.Username).HasMaxLength(255);
        //    });
        //}
    }
}
