using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cosourcing.RH.Contracts.DataAccess.User;
using Cosourcing.RH.Domain.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace Cosourcing.RH.Services.Auth
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string GenerateJwtToken(UserModel user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserModel> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("L'utilisateur avec cet email n'a pas été trouvé.");
            }

            if (VerifyPassword(password, user.MotDePasseHash))
            {
                return user;
            }
            throw new UnauthorizedAccessException("Mot de passe incorrect.");
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
            }
            catch (BCrypt.Net.SaltParseException)
            {              
                string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(inputPassword, BCrypt.Net.BCrypt.GenerateSalt());
                return newHashedPassword.Equals(hashedPassword);
            }
        }
    }
}
