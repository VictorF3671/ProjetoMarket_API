using System.ComponentModel.DataAnnotations;

namespace ProjetoMarket.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }
        public int SaleId { get; set; } // Foreign key to Venda
        public int ProductId { get; set; } // Foreign key to Products
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // Navegação para a venda
        public required Sale Sale{ get; set; }
        // Navegação para o produto
        public required Products Product { get; set; }
        }
}
