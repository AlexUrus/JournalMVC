using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JournalMVC.Models
{
    public class TimeInterval
    {
        public int Id { get; set; }
        public TimeSpan StartActivity { get; set; }
        public TimeSpan EndActivity { get; set; }
    }
}
