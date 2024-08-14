using ArtInk.Site.ViewComponents.General;
using ArtInk.Utils;

namespace ArtInk.Site.Common;

public class CurrentUserAccessor(IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    public UsuarioJWT GetCurrentUser()
    {
         var jwtCookie = httpContextAccessor.HttpContext!.Request.Cookies["JWT"];
        if (jwtCookie == null) return new UsuarioJWT() { Role = string.Empty };

        var (keyId, _auience, claims) = JwtToken.DecodeJwt(jwtCookie);

        var usuarioJWT = new UsuarioJWT()
        {
            IdUsuario = short.Parse(claims.Single(m => m.Type == "IdUsuario").Value),
            Nombre = claims.Single(m => m.Type == "Nombre").Value,
            Apellidos = claims.Single(m => m.Type == "Apellidos").Value,
            NombreCompleto = claims.Single(m => m.Type == "NombreCompleto").Value,
            CorreoElectronico = claims.Single(m => m.Type == "CorreoElectronico").Value,
            Role = claims.Single(m => m.Type == "role").Value,
        };

        return usuarioJWT;
    }
}
