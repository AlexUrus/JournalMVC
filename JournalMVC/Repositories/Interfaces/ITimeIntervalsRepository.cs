using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface ITimeIntervalsRepository
    {
        public Task AddAsync(TimeInterval model);
        public Task UpdateAsync(TimeInterval model);
        public Task DeleteAsync(TimeInterval model);
        public Task<TimeInterval?> GetAsync(int id);
        public Task<ICollection<TimeInterval>> GetAsync();
    }
}
