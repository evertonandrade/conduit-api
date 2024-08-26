using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Conduit.Entities;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Conduit.Utils.Auth;

public class JwtGenerator(IOptions<JwtOptions> options)
{
    public string GenerateToken(User user)
    {
        var key = SecurityKey(options.Value.Key);
        var token = new JwtSecurityToken(
            claims:
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            ],
            signingCredentials: new(key, SecurityAlgorithms.HmacSha256Signature),
            expires: DateTime.UtcNow.AddHours(8)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static SymmetricSecurityKey SecurityKey(string key) => new(Encoding.ASCII.GetBytes(key));
}

public class JwtOptions
{
    public required string Key { get; init; }
}
