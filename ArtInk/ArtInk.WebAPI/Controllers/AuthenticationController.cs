using ArtInk.Application.DTOs.Authentication;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IServiceIdentity serviceIdentity) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> LoginAsync([FromBody] RequestUserLoginDto loginModel)
    {
        var login = await serviceIdentity.LoginAsync(loginModel);
        return StatusCode(StatusCodes.Status200OK, login);
    }

    [Route("refresh")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> Refresh([FromBody] TokenModel request)
    {
        var refreshToken = await serviceIdentity.RefreshTokenAsync(request);
        return StatusCode(StatusCodes.Status200OK, refreshToken);
    }
}