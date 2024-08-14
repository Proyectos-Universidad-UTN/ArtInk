using System.Security.Claims;
using ArtInk.Site.Common;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.ViewComponents.General;

public class NavigationViewComponent(ICurrentUserAccessor currentUserAccessor) : ViewComponent
{
    public IViewComponentResult Invoke() => View(currentUserAccessor.GetCurrentUser());
}