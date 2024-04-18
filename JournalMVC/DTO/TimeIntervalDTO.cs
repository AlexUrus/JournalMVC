using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JournalMVC.DTO
{
    public class TimeIntervalDTO
    {
        public int Id { get; set; }

        [BindProperty, DataType(DataType.Time)]
        public DateTime StartActivity { get; set; }

        [BindProperty, DataType(DataType.Time)]
        public DateTime EndActivity { get; set; }
        public string Interval { get => StartActivity.ToShortTimeString() + " - " + EndActivity.ToShortTimeString(); }
    }
}
