﻿namespace ProjetoMarket.Models
{
    public class ProductDto
    {
       
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public DateTime CreatedAt { get; set; }
    }
}
