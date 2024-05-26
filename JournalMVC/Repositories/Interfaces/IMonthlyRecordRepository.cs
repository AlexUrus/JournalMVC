using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface IMonthlyRecordRepository
    {
        public Task AddAsync(MonthlyRecord model);
        public Task<MonthlyRecord?> GetAsync(int id);
        public Task<ICollection<MonthlyRecord>> GetAsync();
    }
}
