namespace ProjetoMarket.Models
{
    public class Sale
    { 
    public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }

        // Navegação para os itens da venda
        public List<SaleItem> Itens { get; set; } = new List<SaleItem>();
    }
}
