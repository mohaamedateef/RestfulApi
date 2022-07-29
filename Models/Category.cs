using System.ComponentModel.DataAnnotations;
namespace RestfullAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
