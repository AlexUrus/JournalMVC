using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IActivitiesService
    {
        Task AddAsync(ActivityDTO dTO);
        Task<ICollection<ActivityDTO>> GetAsync();
        Task<ActivityDTO> GetAsync(int id);
        Task DeleteAsync(ActivityDTO dTO);
        Task UpdateAsync(ActivityDTO dTO);

        // Sync methods
        void Add(ActivityDTO dTO);
        ICollection<ActivityDTO> Get();
        ActivityDTO Get(int id);
        void Delete(ActivityDTO dTO);
        void Update(ActivityDTO dTO);
    }
}
