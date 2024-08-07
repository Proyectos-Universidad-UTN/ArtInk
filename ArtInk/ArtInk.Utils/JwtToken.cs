

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ArtInk.Utils;

public static class JwtToken
{
    private static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);

        return token;
    }

    public static (string keyId, List<string> audience, IEnumerable<Claim> claims) DecodeJwt(string? jwt)
    {
        var token = ConvertJwtStringToJwtSecurityToken(jwt);

        var keyId = token.Header.Kid;
        var audience = token.Audiences.ToList();
        var claims = token.Claims;

        return (keyId, audience, claims);
    }
}