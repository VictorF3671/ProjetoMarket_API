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

namespace ProjetoMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public UsersController(AppDbContext context, IUserService userService )
        {
            _context = context;
            _userService = userService;
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var user = new User
            {
                Name = userDto.Name,
                HashPassword = _userService.GenerateHashPassword(userDto.Password),
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Group = userDto.Group,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new {success = true});
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers()
        {

            
            var usuarios = await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Group = u.Group == 1
                        ? "Vendedor"
                        : u.Group == 2
                            ? "Administrador"
                            : "Desconhecido",
                }).ToListAsync();

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(usuarios));

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }
    }
}
