using EnrollmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnrollmentSystem.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorID);

        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentID, e.CourseID });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentID);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseID);

        modelBuilder.Entity<Instructor>()
            .Property(i => i.InstructorID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { InstructorID = 1, InstructorName = "Kenzy", Email = "kenzy@example.com" },
            new Instructor { InstructorID = 2, InstructorName = "Farida", Email = "farida@example.com" },
            new Instructor { InstructorID = 3, InstructorName = "Lara", Email = "lara@example.com" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { CourseID = 1, CourseName = "German A1", InstructorID = 1 },
            new Course { CourseID = 2, CourseName = "German A2", InstructorID = 1 },
            new Course { CourseID = 3, CourseName = "Spanish", InstructorID = 2 },
            new Course { CourseID = 4, CourseName = "English B2", InstructorID = 3 },
            new Course { CourseID = 5, CourseName = "English C1", InstructorID = 3 }
        );

    }

}
