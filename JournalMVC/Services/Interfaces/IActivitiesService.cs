using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IActivitiesService
    {
        Task AddAsync(ActivityDTO dTO);
        Task<ICollection<ActivityDTO>> GetAsync();
        Task<ActivityDTO> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(ActivityDTO dTO);
    }
}
