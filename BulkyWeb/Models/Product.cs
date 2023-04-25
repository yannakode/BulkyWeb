using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product name")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "The {0} field cannot contain numbers and must be at most 30 characters long"), MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Product price")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1-10000")]
        public int Price { get; set; }
    }
}
