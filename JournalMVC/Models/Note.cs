namespace JournalMVC.Models
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int TimeIntervalId { get; set; }
        public int DailyLogId { get; set; }

        public Activity Activity { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public DailyLog DailyLog { get; set; }
    }
}
