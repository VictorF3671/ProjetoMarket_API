using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMarket.Data;
using ProjetoMarket.Interfaces;
using ProjetoMarket.Models;
using ProjetoMarket.Services;

namespace ProjetoMarket.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductsService _productService;

        public ProductsController(AppDbContext context, IProductsService productService)
        {
            _context = context;
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productsDto)
        {
            var product = await _productService.CreateProduct(productsDto);
            if (product == null)
            {
                return BadRequest("Erro ao criar o produto.");
            }
            return Ok(new { success = true});
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProduct();
            if (products == null)
            {
                return NotFound("Nenhum produto encontrado.");
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {

            var products = await _productService.GetProductById(id);
            return products != null ? Ok(products) : NotFound("Produto não encontrado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }
            await _productService.DeleteProduct(id);
            return Ok(new { message = "Produto deletado com sucesso." });
        }
    }
}
