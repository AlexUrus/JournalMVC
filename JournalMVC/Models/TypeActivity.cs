using System.ComponentModel.DataAnnotations;

namespace JournalMVC.Models
{
    public class TypeActivity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
