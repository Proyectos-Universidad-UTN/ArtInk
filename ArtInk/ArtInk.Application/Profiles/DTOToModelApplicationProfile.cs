using ArtInk.Application.RequestDTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.Profiles;

public class DTOToModelApplicationProfile : Profile
{
    public DTOToModelApplicationProfile()
    {
        CreateMap<RequestProductoDTO, Producto>();
        CreateMap<RequestSucursalDTO, Sucursal>();
        CreateMap<RequestServicioDTO, Servicio>();
        CreateMap<RequestTipoServicioDTO, TipoServicio>();
        CreateMap<RequestFeriadoDTO, Feriado>();
        CreateMap<RequestSucursalFeriadoDTO, SucursalFeriado>();
    }
}
