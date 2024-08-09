using ArtInk.Application.DTOs.Enums;
using ArtInk.Utils;
using Microsoft.AspNetCore.Authorization;

namespace ArtInk.WebAPI.Configuration;

public class ArtInkAuthorizeAttribute : AuthorizeAttribute
{
    public ArtInkAuthorizeAttribute() : base() { }

    public ArtInkAuthorizeAttribute(params Rol[] roles)
    {
        var allowedRolesAsStrings = roles.Select(x => StringExtension.Capitalize(Enum.GetName(typeof(Rol), x)!));
        Roles = string.Join(",", allowedRolesAsStrings);
    }
}