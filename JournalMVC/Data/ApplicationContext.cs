using JournalMVC.Data;
using JournalMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using JournalMVC.DTO;

namespace JournalMVC.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<TypeActivity> TypeActivities { get; set; }
        public DbSet<DailyRecord> DailyRecords { get; set; }
        public DbSet<MonthlyRecord> MonthlyRecords { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ApplicationContextSeed(modelBuilder).Seed();
        }
    }
}
