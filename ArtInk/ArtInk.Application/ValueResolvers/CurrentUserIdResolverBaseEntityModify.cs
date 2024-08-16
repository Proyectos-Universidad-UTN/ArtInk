using ArtInk.Application.DTOs.Base;
using ArtInk.Application.Services.Interfaces.Authorization;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.ValueResolvers;

public class CurrentUserIdResolverBaseEntityModify(IServiceUserContext serviceUserContext) : IValueResolver<BaseEntity, BaseModel, string?>
{
    public string? Resolve(BaseEntity source, BaseModel destination, string? destMember, ResolutionContext context) =>
        serviceUserContext.UserId!;
}