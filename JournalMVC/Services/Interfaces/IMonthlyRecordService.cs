using JournalMVC.DTO;

namespace JournalMVC.Services.Interfaces
{
    public interface IMonthlyRecordService
    {
        Task<MonthlyRecordDTO> GetOrCreateMonthlyRecord(int month);
    }
}
