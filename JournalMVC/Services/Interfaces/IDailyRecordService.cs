using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IDailyRecordService
    {
        Task<DailyRecordDTO> GetOrCreateDailyRecord(int monthlyRecordId, int day);
        Task<ICollection<DailyRecordDTO>> GetAsync();
    }
}
