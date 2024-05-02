using System;
using System.Collections.Generic;

namespace BruShop.Web.Api.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? PathToImg { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
