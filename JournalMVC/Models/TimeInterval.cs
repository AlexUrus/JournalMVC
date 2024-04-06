namespace JournalMVC.Models
{
    public class TimeInterval : IEntity
    {
        public int Id { get; set; }
        public TimeSpan StartActivity { get; set; }
        public TimeSpan EndActivity { get; set; }
    }
}
