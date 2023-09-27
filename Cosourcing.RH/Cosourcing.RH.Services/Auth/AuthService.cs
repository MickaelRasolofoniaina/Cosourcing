using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cosourcing.RH.Domain.User;
using Microsoft.Extensions.Configuration;
using Cosourcing.RH.DataAccess.Context;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace Cosourcing.RH.Services.Auth;

public class AuthService
{
    private readonly RHDbContext dbContext;
    private readonly IConfiguration configuration;

    public AuthService(RHDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }

    public string GenerateJwtToken(UserModel user)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
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

    public UserModel AuthenticateUser(string email, string password)
    {
        var user = dbContext.User.SingleOrDefault(u => u.Email == email);

        if (user == null)
        {
           
            return null;
        }

       
        if (user.Password == password)
        {
            
            return user;
        }

       
        return null;
    }

    private bool VerifierMotDePasse(string motDePasse, string motDePasseHash)
    {
         return BCrypt.Net.BCrypt.Verify(motDePasse, motDePasseHash); 
        
    }
}