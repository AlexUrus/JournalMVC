using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface ITimeIntervalsService
    {
        Task AddAsync(TimeIntervalDTO dTO);
        Task<ICollection<TimeIntervalDTO>> GetAsync();
        Task<TimeIntervalDTO> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(TimeIntervalDTO dTO);
    }
}
