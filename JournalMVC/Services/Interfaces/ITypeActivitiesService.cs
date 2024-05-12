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

        // Sync methods
        void Add(TypeActivityDTO typeActivityDto);
        ICollection<TypeActivityDTO> Get();
        TypeActivityDTO Get(int id);
        void Update(TypeActivityDTO typeActivityDto);
        void Delete(int id);
    }
}
