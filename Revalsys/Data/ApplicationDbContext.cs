using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Revalsys.Entities;

namespace Revalsys.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Revalsys.Entites.Learner> Learners { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Revalsys.Entites.LearnerCourse> LearnerCourse { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Revalsys.Entites.LearnerCourse>()
            .HasKey(lc => new { lc.LearnerId, lc.CourseId });

        modelBuilder.Entity<Revalsys.Entites.LearnerCourse>()
            .HasOne(lc => lc.Learner)
            .WithMany(l => l.LearnerCourses)
            .HasForeignKey(lc => lc.LearnerId);

        modelBuilder.Entity<Revalsys.Entites.LearnerCourse>()
            .HasOne(lc => lc.Course)
            .WithMany(c => c.LearnerCourses)
            .HasForeignKey(lc => lc.CourseId);
    }

}
