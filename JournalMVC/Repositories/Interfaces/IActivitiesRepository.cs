using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface IActivitiesRepository
    {
        public Task AddAsync(Activity model);
        public Task UpdateAsync(Activity model);
        public Task DeleteAsync(Activity model);
        public Task<Activity?> GetAsync(int id);
        public Task<ICollection<Activity>> GetAsync();
    }
}
