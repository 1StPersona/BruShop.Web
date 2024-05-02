using System.ComponentModel.DataAnnotations;

namespace BruShop.Web.Models
{
	public class Product
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? PathToImg { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
