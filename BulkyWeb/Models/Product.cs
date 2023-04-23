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
        public string Name { get; set; }
        [DisplayName("Product price")]
        public int Price { get; set; }
    }
}
