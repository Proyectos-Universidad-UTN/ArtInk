using ArtInk.Site.Common;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class BaseArtInkController: Controller
{
    public ICurrentUserAccessor? CurrentUserAccessor { get; init; }

    public BaseArtInkController()
    {
        
    }

    public BaseArtInkController(ICurrentUserAccessor currentUserAccessor) => CurrentUserAccessor = currentUserAccessor;
}