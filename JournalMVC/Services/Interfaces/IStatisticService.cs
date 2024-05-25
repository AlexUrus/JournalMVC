using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<DetailsActivitiesDTO?> GetDetailsActivitiesDTOAsync(int id);
    }
}
