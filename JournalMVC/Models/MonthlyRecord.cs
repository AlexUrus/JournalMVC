namespace JournalMVC.Models
{
    public class MonthlyRecord
    {
        public int Id { get; set; }
        public int Month { get; set; }

        public ICollection<DailyRecord> DailyRecords { get; set; } = new List<DailyRecord>();
    }
}
