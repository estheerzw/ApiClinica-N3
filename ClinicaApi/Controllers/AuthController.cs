using ClinicaApi.Data;
using ClinicaApi.DTOs;
using ClinicaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(
            AppDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            if (_context.Usuarios.Any(u => u.Username == dto.Username))
                return BadRequest("Usuário já existe.");

            var usuario = new Usuario
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok("Usuário criado com sucesso.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Username == dto.Username);

            if (usuario == null)
                return Unauthorized();

            bool senhaCorreta =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    usuario.PasswordHash);

            if (!senhaCorreta)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));

            var creds =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}