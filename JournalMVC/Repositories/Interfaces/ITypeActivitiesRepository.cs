using JournalMVC.DTO;
using JournalMVC.Models;

namespace JournalMVC.Repositories.Interfaces
{
    public interface ITypeActivitiesRepository
    {
        public void Add(TypeActivity model);
        public Task AddAsync(TypeActivity model);
        public void Update(TypeActivity model);
        public Task UpdateAsync(TypeActivity model);
        public void Delete(TypeActivity model);
        public Task DeleteAsync(TypeActivity model);
        public TypeActivity? Get(int id);
        public Task<TypeActivity?> GetAsync(int id);
        public ICollection<TypeActivity> Get();
        public Task<ICollection<TypeActivity>> GetAsync();
    }
}
