using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiPagamentos.Authentication;

public class Jwt
{
    public string? Secret { get; set; }

    public string? Issuer { get; set; }

    public string GenerateToken(string role)
    {
        var expiryIn = DateTime.Now.AddMinutes(10);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new("role", role)
        };

        var token = new JwtSecurityToken(
            issuer: Issuer,
            expires: expiryIn,
            signingCredentials: credentials,
            claims: claims
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}