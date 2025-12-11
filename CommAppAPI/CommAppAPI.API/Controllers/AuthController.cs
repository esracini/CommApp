using CommAppAPI.Application.DTOs.Auth;
using CommAppAPI.Domain.Entities;
using CommAppAPI.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CommAppAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IWriteRepository<User> _writeRepo;
        private readonly IReadRepository<User> _readRepo;
        private readonly IConfiguration _config;

        public AuthController(
            IWriteRepository<User> writeRepo,
            IReadRepository<User> readRepo,
            IConfiguration config)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
            _config = config;
        }

        //Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (_readRepo.GetWhere(u => u.Username == dto.Username).Any())
                return BadRequest("Bu kullanıcı adı zaten kullanılıyor.");

            CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = dto.Role
            };


            await _writeRepo.AddAsync(user);
            await _writeRepo.SaveAsync();

            return Ok("Kayıt başarılı.");
        }

        //Login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _readRepo
                .GetWhere(u => u.Username == dto.Username)
                .FirstOrDefault();

            if (user == null)
                return Unauthorized("Kullanıcı bulunamadı.");

            if (!VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Hatalı şifre.");

            var token = GenerateJwtToken(user.Username, user.Role);


            return Ok(new LoginResultDto
            {
                Token = token,
                Expiration = DateTime.Now.AddHours(2)
            });
        }

        //Hash
        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computed.SequenceEqual(hash);
        }

        //JWT token
        private string GenerateJwtToken(string username, string role)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role)
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
