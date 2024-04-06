namespace JournalMVC.Models
{
    public class MonthLog : IEntity
    {
        public int Id { get; set; }
        public int NumMonth { get; set; }

        public ICollection<DailyLog> DailyLogs { get; set; } = new List<DailyLog>();

    }
}
