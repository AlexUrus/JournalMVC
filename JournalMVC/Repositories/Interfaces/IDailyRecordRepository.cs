using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface IDailyRecordRepository
    {
        public Task AddAsync(DailyRecord model);
        public Task<DailyRecord?> GetAsync(int id);
        public Task<ICollection<DailyRecord>> GetAsync();
    }
}
