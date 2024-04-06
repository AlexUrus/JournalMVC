namespace JournalMVC.Models
{
    public class DailyLog : IEntity
    {
        public int Id { get; set; }
        public int NumDay { get; set; }
        public int MonthLogId { get; set; }
        
        public MonthLog MonthLog { get; set; }
        public ICollection<Note> DaysActivities { get; set; } = new List<Note>();
    }
}
