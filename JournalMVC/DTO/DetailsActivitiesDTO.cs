namespace JournalMVC.DTO
{
    public class DetailsActivitiesDTO
    {
        public int Id { get; set; }
        public string TypeActivity { get; set; } = null!;
        public TimeSpan AverrageTimePerDay { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
