using ProjectDawAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectDawAngular.Data
{
    public class Lab4Context : DbContext
    {
        public Lab4Context() { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorDetails> ProfessorDetails { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public Lab4Context(DbContextOptions<Lab4Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProjectDawAngular;TrustServerCertificate=True;");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to One: ProfessorDetails - Professor
            modelBuilder.Entity<ProfessorDetails>()
                        .HasOne(pd => pd.Professor)
                        .WithOne(p => p.ProfessorDetails)
                        .HasForeignKey<ProfessorDetails>(pd => pd.ProfessorId);

            // Many to Many: Student - Course
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.StudentCourses)
                        .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(sc => sc.Course)
                        .WithMany(c => c.StudentCourses)
                        .HasForeignKey(sc => sc.CourseId);

            // One to Many: Professor - Course
            modelBuilder.Entity<Course>()
                        .HasOne(c => c.Professor)
                        .WithMany(p => p.Courses)
                        .HasForeignKey(c => c.ProfessorId);

            // One to Many: Department - Professor
            modelBuilder.Entity<Professor>()
                        .HasOne(p => p.Department)
                        .WithMany(d => d.Professors)
                        .HasForeignKey(p => p.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}