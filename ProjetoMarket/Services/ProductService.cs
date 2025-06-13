using Microsoft.EntityFrameworkCore;
using ProjetoMarket.Data;
using ProjetoMarket.Interfaces;
using ProjetoMarket.Models;
using System.Security.Claims;

namespace ProjetoMarket.Services
{
    public class ProductService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CreateProductDto> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                throw new ArgumentNullException(nameof(createProductDto), "Produto não pode ser nulo.");


            var product = new Products
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return createProductDto;
        }
        public async Task<IEnumerable<object>> GetAllProduct()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();

            return products;
        }
        public async Task<object?> GetProductById(int id)
        {
            var product = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedAt = p.CreatedAt
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }
        public async Task<bool?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }


    }
    }
