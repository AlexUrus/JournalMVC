namespace JournalMVC.Models
{
    public class DailyRecord
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int MonthlyRecordId { get; set; } 

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public MonthlyRecord MonthlyRecord { get; set; } = null!;
    }
}
