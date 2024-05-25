using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface ITypeActivitiesService
    {
        Task AddAsync(TypeActivityDTO typeActivityDto);
        Task<ICollection<TypeActivityDTO>> GetAsync();
        Task<TypeActivityDTO> GetAsync(int id);
        Task UpdateAsync(TypeActivityDTO typeActivityDto);
        Task DeleteAsync(int id);
    }
}
