using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reminder.Service.Models
{
    public class Activity
    // 
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Time { get; set; }
        public Category Category { get; set; }

    }
}
