using JournalMVC.Models;

namespace JournalMVC.DTO
{
    public class DailyRecordDTO
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int MonthlyRecordId { get; set; }

        public ICollection<ActivityDTO> Activities { get; set; } = new List<ActivityDTO>();
        public MonthlyRecordDTO MonthlyRecord { get; set; } = null!;
    }
}
