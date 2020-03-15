using Microsoft.EntityFrameworkCore;
using Study.Domain.CourseAggregate;
using Study.Domain.StudentAggregate;
using System;

namespace Study.Infrastructure
{
    public class StudyContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudyContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var course = new Course("Programming");
            modelBuilder.Entity<Course>().HasData(course);

            var student = new Student("Petro");
            modelBuilder.Entity<Student>().HasData(student);

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse(student.Id, course.Id));
        }
    }
}
