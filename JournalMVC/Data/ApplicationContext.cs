using JournalMVC.Data;
using JournalMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace JournalMVC.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<TypeActivity> TypeActivities { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ApplicationContextSeed(modelBuilder).Seed();
        }
    }
}
