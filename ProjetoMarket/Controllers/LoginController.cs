using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoMarket.Data;
using ProjetoMarket.Interfaces;
using ProjetoMarket.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMarket.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public LoginController(AppDbContext context, IConfiguration configuration, IUserService userService)
        {
            _context = context;
            _userService = userService;
            _configuration = configuration;

        }
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email);

            if (user == null) {
                return Unauthorized("Usuário Não Encontrado");
            }
            if (!_userService.VerifyPassword(login.Password, user.HashPassword)) {
                return Unauthorized("Senha Inválida");
            }


            var token = _userService.GenerateJwtToken(user);
            string roleString = user.Group switch
            {
                1 => "ROLE_SELLER",
                2 => "ROLE_ADMIM",
                _ => "ROLE_UNKNOWN"
            };
            LoginDto loginDto = new LoginDto
            {
                Token = token,
                Email = user.Email,
                Name = user.Name,
                group = roleString
            };
            return Ok(loginDto);
        }


    }
}
