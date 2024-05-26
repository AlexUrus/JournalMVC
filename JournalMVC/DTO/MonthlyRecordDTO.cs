using JournalMVC.Models;

namespace JournalMVC.DTO
{
    public class MonthlyRecordDTO
    {
        public int Id { get; set; }
        public int Month { get; set; }

        public ICollection<DailyRecordDTO> DailyRecords { get; set; } = new List<DailyRecordDTO>();
    }
}
