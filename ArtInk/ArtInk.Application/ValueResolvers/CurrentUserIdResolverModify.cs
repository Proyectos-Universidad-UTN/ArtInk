using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces.Authorization;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.ValueResolvers;

public class CurrentUserIdResolverModify(IServiceUserContext serviceUserContext) : IValueResolver<RequestBaseDto, BaseModel, string?>
{
    public string? Resolve(RequestBaseDto source, BaseModel destination, string? destMember, ResolutionContext context) =>
        serviceUserContext.UserId!;
}