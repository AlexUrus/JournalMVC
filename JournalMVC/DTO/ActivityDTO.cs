﻿using JournalMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JournalMVC.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int TimeIntervalId { get; set; }
        public string Description { get; set; } = null!;

        public TypeActivityDTO? Type { get; set; } = null!;
        public TimeIntervalDTO? TimeInterval { get; set; } = null!;
    }
}
