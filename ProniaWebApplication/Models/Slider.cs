using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaWebApplication.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Duzgun daxil edin!")]
        public string Title { get; set; }
        [StringLength(10,ErrorMessage ="Uzunluq 10 kecmesin!")]
        public string Subtitle { get; set; }    
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
