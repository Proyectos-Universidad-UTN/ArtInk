using ArtInk.Site.ViewComponents.General;

namespace ArtInk.Site.Common;

public interface ICurrentUserAccessor
{
    UsuarioJWT GetCurrentUser();
}