using ArtInk.Site.Controllers;
using ArtInk.Site.Models;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArtInk.Site.Common;

public class RolAccessAttribute : ActionFilterAttribute
{
    private readonly Rol[]? _roles;

    public RolAccessAttribute() : base()
    {
    }

    public RolAccessAttribute(params Rol[] roles) => _roles = roles;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.Controller as BaseArtInkController;
        var allowedRolesAsStrings = _roles!.Select(x => StringExtension.Capitalize(Enum.GetName(typeof(Rol), x)!));
        if (controller != null && controller.CurrentUserAccessor != null && !allowedRolesAsStrings.ToList().Exists(m => m == controller.CurrentUserAccessor.GetCurrentUser().Role))
        {
            context.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary
                                        {
                                            {"controller", "Home"},
                                            {"action", "Index"},
                                            {"errorCode", "2"}
                                        }
                                    );
        }
    }
}