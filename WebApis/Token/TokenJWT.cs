using System.IdentityModel.Tokens.Jwt;

namespace WebApis.Token;

public class TokenJWT
{
    private readonly JwtSecurityToken _token;
    internal TokenJWT(JwtSecurityToken token)
    {
        _token = token;
    }

    public DateTime ValidTo => _token.ValidTo;

    public string value => new JwtSecurityTokenHandler().WriteToken(_token);
}
