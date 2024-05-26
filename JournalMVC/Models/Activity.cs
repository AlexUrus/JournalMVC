using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalMVC.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int TimeIntervalId { get; set; }
        public int DailyRecordId { get; set; } 
        public string Description { get; set; } = null!;

        public TypeActivity Type { get; set; } = null!;
        public TimeInterval TimeInterval { get; set; } = null!;
        public DailyRecord DailyRecord { get; set; } = null!;
    }
}
