using System.ComponentModel.DataAnnotations;

namespace BruShop.Web.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PathToImg { get; set; }
    }
}
