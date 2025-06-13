using ProjetoMarket.Models;
using System.Security.Claims;

namespace ProjetoMarket.Interfaces
{
    public interface IProductsService
    {
        Task<CreateProductDto> CreateProduct(CreateProductDto createProductDto);
        Task<IEnumerable<object>> GetAllProduct();
        Task<object?> GetProductById(int id);
        Task<bool?> DeleteProduct(int id);
    }
}
