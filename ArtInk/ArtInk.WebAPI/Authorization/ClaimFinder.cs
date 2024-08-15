using System.Security.Claims;

namespace ArtInk.WebAPI.Authorization;

public class ClaimFinder(IEnumerable<Claim> claims)
{
    public Claim? IdUsuario { get => claims.FirstOrDefault(m => m.Type == "IdUsuario"); }

    public Claim? CorreoElectronico { get => claims.FirstOrDefault(m => m.Type == "CorreoElectronico"); }

    public Claim? Role { get => claims.FirstOrDefault(m => m.Type == ClaimTypes.Role); }
}