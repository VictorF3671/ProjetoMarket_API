using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMarket.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }

        public required string ImageUrl { get; set; }

        public required int Stock { get; set; } = 0; // Default stock is 0

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
