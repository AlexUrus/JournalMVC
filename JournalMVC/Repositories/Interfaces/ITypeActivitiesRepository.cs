using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface ITypeActivitiesRepository
    {
        public Task AddAsync(TypeActivity model);
        public Task UpdateAsync(TypeActivity model);
        public Task DeleteAsync(TypeActivity model);
        public Task<TypeActivity?> GetAsync(int id);
        public Task<ICollection<TypeActivity>> GetAsync();
    }
}
