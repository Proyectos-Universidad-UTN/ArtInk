using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;

namespace ArtInk.Site.Profiles;

public class ResponseDtoToRequestDtoApplicationProfile: Profile
{
    public ResponseDtoToRequestDtoApplicationProfile()
    {
        CreateMap<SucursalResponseDto, SucursalRequestDto>();
        CreateMap<ProductoResponseDto, ProductoRequestDto>();
        CreateMap<FeriadoResponseDto, FeriadoRequestDto>();
        CreateMap<SucursalFeriadoResponseDto, SucursalFeriadoRequestDto>();
        CreateMap<ServicioResponseDto, ServicioRequestDto>();
        CreateMap<SucursalHorarioResponseDto, SucursalHorarioRequestDto>();
        CreateMap<HorarioResponseDto, HorarioRequestDto>();
    }
}