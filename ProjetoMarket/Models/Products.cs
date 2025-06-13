using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMarket.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }

        public required int Stock { get; set; } = 0; // Default stock is 0

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
