using ArtInk.Application.DTOs.Authentication;
using ArtInk.Application.DTOs.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ArtInk.WebAPI.Authorization;

public class UserIdentityHandler : AuthorizationHandler<IdentifiedUser>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdentifiedUser requirement)
    {
        var httpContext = (HttpContext)context.Resource!;
        var claimFinder = new ClaimFinder(context.User.Claims);

        if (claimFinder.IdUsuario != null && claimFinder.Role != null && claimFinder.CorreoElectronico != null)
        {
            httpContext.Items["CurrentUser"] = new CurrentUser
            {
                IdUsuario = short.Parse(claimFinder.IdUsuario!.Value),
                CorreoElectronico = claimFinder.CorreoElectronico!.Value,
                Role = (Rol)Enum.Parse(typeof(Rol), claimFinder.Role!.Value.ToUpper())
            };
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}