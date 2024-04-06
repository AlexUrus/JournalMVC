using JournalMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace JournalMVC.Database
{
    public class ApplicationContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DailyLog> DailyLogs { get; set; }
        public DbSet<MonthLog> MonthLogs { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<TypeActivity> TypeActivities { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //public async Task BeginTransactionAsync()
        //{
        //    if (_currentTransaction != null)
        //    {
        //        return;
        //    }

        //    _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        //}

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                await (_currentTransaction?.CommitAsync() ?? Task.CompletedTask);
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
