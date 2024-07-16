using ArtInk.Application.RequestDTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.Profiles;

public class DtoToModelApplicationProfile : Profile
{
    public DtoToModelApplicationProfile()
    {
        CreateMap<RequestProductoDto, Producto>();
        CreateMap<RequestSucursalDto, Sucursal>();
        CreateMap<RequestServicioDto, Servicio>();
        CreateMap<RequestTipoServicioDto, TipoServicio>();
        CreateMap<RequestFeriadoDto, Feriado>();
        CreateMap<RequestSucursalFeriadoDto, SucursalFeriado>();
        CreateMap<RequestHorarioDto, Horario>();
        CreateMap<RequestSucursalHorarioDto, SucursalHorario>();
        CreateMap<RequestSucursalHorarioBloqueoDto, SucursalHorarioBloqueo>();
        CreateMap<RequestInventarioDto, Inventario>();
        CreateMap<RequestInventarioProductoDto, InventarioProducto>();
    }
}
