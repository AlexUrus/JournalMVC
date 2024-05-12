using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface ITimeIntervalsService
    {
        Task AddAsync(TimeIntervalDTO dTO);
        Task<ICollection<TimeIntervalDTO>> GetAsync();
        Task<TimeIntervalDTO> GetAsync(int id);
        Task DeleteAsync(TimeIntervalDTO dTO);
        Task UpdateAsync(TimeIntervalDTO dTO);

        // Sync methods
        void Add(TimeIntervalDTO dTO);
        ICollection<TimeIntervalDTO> Get();
        TimeIntervalDTO Get(int id);
        void Delete(TimeIntervalDTO dTO);
        void Update(TimeIntervalDTO dTO);
    }
}
