using App = ArtInk.Application.DTOs.Enums;
using AutoMapper;
using Infra = ArtInk.Infraestructure.Enums;

namespace ArtInk.Application.Profiles;

public class MiscApplicationProfile :Profile
{
    public MiscApplicationProfile()
    {
        CreateMap<App.DiaSemana, Infra.DiaSemana>().ReverseMap();
    }
}
