using System.Reflection;
using ArtInk.Application.DTOs.Authentication;
using ArtInk.Application.Services.Interfaces.Authorization;
using Microsoft.AspNetCore.Http;

namespace ArtInk.Application.Services.Implementations.Authorization;

public class ServiceUserContext(IHttpContextAccessor httpContextAccessor) : IServiceUserContext
{
    public string? UserId
    {
        get
        {
            string? result = null;
            var httpContextItems = httpContextAccessor.HttpContext?.Items;
            if (httpContextItems != null && httpContextItems["CurrentUser"] is CurrentUser currentUser)
            {
                result = currentUser.CorreoElectronico;
            }

            if (string.IsNullOrEmpty(result))
            {
                result = Assembly.GetEntryAssembly()?.GetName().Name;
            }

            return result;
        }
    }
}