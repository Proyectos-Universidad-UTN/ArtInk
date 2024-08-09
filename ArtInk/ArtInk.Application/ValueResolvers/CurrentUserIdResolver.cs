using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces.Authorization;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.ValueResolvers;

public class CurrentUserIdResolver(IServiceUserContext serviceUserContext) : IValueResolver<RequestBaseDTO, BaseModel, string?>
{
    public string? Resolve(RequestBaseDTO source, BaseModel destination, string? destMember, ResolutionContext context) =>
        serviceUserContext.UserId!;
}