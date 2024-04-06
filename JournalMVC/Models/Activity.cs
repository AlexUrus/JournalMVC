﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalMVC.Models
{
    public class Activity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public string Description { get; set; }

        public TypeActivity Type { get; set; }
    }
}