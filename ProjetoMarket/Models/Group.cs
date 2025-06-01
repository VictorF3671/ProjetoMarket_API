using System.ComponentModel.DataAnnotations;

namespace ProjetoMarket.Models
{
    public class Group
    {
        [Key]public int Id { get; set; }
        public required string Name { get; set; }
    }
}
