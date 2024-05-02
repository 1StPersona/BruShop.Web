using System;
using System.Collections.Generic;

namespace BruShop.Web.Api.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PathToImg { get; set; }
    }
}
