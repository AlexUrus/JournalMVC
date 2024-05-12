using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface IActivitiesRepository
    {
        public void Add(Activity model);
        public Task AddAsync(Activity model);
        public void Update(Activity model);
        public Task UpdateAsync(Activity model);
        public void Delete(Activity model);
        public Task DeleteAsync(Activity model);
        public Activity? Get(int id);
        public Task<Activity?> GetAsync(int id);
        public ICollection<Activity> Get();
        public Task<ICollection<Activity>> GetAsync();
    }
}
