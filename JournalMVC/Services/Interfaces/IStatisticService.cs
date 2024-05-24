using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IStatisticService
    {
        public Task<DetailsActivitiesDTO?> GetDetailsActivitiesDTOAsync(int id);
    }
}
