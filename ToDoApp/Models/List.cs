using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
