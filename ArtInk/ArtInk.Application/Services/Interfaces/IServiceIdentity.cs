using ArtInk.Application.DTOs.Authentication;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceIdentity
{
    Task<TokenModel> LoginAsync(RequestUserLoginDto login);

    Task<TokenModel> RefreshTokenAsync(TokenModel request);
}