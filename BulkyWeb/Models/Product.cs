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
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Product price")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1-10000")]
        public int Price { get; set; }
    }
}
