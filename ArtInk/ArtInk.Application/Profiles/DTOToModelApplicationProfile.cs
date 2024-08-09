using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.ValueResolvers;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.Profiles;

public class DtoToModelApplicationProfile : Profile
{
    public DtoToModelApplicationProfile()
    {
        CreateMap<RequestBaseDTO, BaseModel>()
            .ForMember(m => m.UsuarioCreacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolver>();
            })
            .ForMember(m => m.UsuarioModificacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolver>();
            });

        CreateMap<RequestProductoDto, Producto>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestSucursalDto, Sucursal>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestServicioDto, Servicio>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestFeriadoDto, Feriado>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestHorarioDto, Horario>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestInventarioDto, Inventario>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestInventarioProductoDto, InventarioProducto>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestFacturaDto, Factura>()
            .IncludeBase<RequestBaseDTO, BaseModel>();
        
        CreateMap<RequestPedidoDto, Pedido>()
            .IncludeBase<RequestBaseDTO, BaseModel>();
        
        CreateMap<RequestReservaDto, Reserva>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestReservaPreguntaDto, ReservaPregunta>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestInventarioProductoMovimientoDto, InventarioProductoMovimiento>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        CreateMap<RequestProveedorDto, Proveedor>()
            .IncludeBase<RequestBaseDTO, BaseModel>();

        
        CreateMap<RequestTipoServicioDto, TipoServicio>();
        CreateMap<RequestSucursalHorarioDto, SucursalHorario>();
        CreateMap<RequestSucursalHorarioBloqueoDto, SucursalHorarioBloqueo>();
        CreateMap<RequestSucursalFeriadoDto, SucursalFeriado>();
        CreateMap<RequestDetalleFacturaDto,  DetalleFactura>();
        CreateMap<RequestDetallePedidoDto, DetallePedido>();
        CreateMap<RequestReservaServicioDto, ReservaServicio>();
    }
}
