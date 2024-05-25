using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalMVC.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int TimeIntervalId { get; set; }
        public string Description { get; set; }
        

        public TypeActivity Type { get; set; }
        public TimeInterval TimeInterval { get; set; }
    }
}
