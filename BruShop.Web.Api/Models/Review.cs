using System;
using System.Collections.Generic;

namespace BruShop.Web.Api.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
