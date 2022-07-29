using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfullAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(8)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
