using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface ITimeIntervalsRepository
    {
        public void Add(TimeInterval model);
        public Task AddAsync(TimeInterval model);
        public void Update(TimeInterval model);
        public Task UpdateAsync(TimeInterval model);
        public void Delete(TimeInterval model);
        public Task DeleteAsync(TimeInterval model);
        public TimeInterval? Get(int id);
        public Task<TimeInterval?> GetAsync(int id);
        public ICollection<TimeInterval> Get();
        public Task<ICollection<TimeInterval>> GetAsync();
    }
}
