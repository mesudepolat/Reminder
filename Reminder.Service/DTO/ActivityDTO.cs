using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.Models
{
    public class ActivityDTO
    {
        public int Id { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Description { get; set; }

        public DateTime Time { get; set; }

        public string? CategoryName { get; set; }
        public List<Category>? CategoryList { get; set; }



    }
}
