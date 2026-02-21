using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingApp.API.Entities;
using DatingApp.API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
  public string CreateToken(AppUser user)
  {
    var tokenKey = config["TokenKey"] ?? throw new Exception("TokenKey is not configured.");
    if (tokenKey.Length < 64)
    {
      throw new Exception("TokenKey must be at least 64 characters long.");
    }

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id),
      new Claim(ClaimTypes.Name, user.DisplayName),
      new Claim(ClaimTypes.Email, user.Email),
      new Claim("jti", Guid.NewGuid().ToString())
    };

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddDays(1),
      SigningCredentials = creds
    };

    var tokenHandler = new JwtSecurityTokenHandler();

    return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

  }
}

