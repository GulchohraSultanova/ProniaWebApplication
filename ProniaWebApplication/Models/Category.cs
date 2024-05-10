using System.ComponentModel.DataAnnotations;

namespace ProniaWebApplication.Models
{
    public class Category 
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Name bos ola bilmez!")]
        public string Name { get; set; } = null!;
        public List<Product>? Products { get; set; }
    }
}
