using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JournalMVC.Models
{
    public class TimeInterval : IEntity
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan StartActivity { get; set; }
        public TimeSpan EndActivity { get; set; }
    }
}
