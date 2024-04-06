namespace JournalMVC.Models
{
    public class Statistic
    {
        public double AverageTimePerDay { get; set; }
        public double TotalTime { get; set; }
        public string NameActivity { get; set; }

        public Statistic(string nameActivity, double totaltime, double averageTimePerDay)
        {
            NameActivity = nameActivity;
            TotalTime = totaltime;
            AverageTimePerDay = averageTimePerDay;
        }
    }
}
