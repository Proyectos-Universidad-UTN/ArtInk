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
        CreateMap<RequestBaseDto, BaseModel>()
            .ForMember(m => m.UsuarioCreacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolver>();
            })
            .ForMember(m => m.UsuarioModificacion, opts =>
            {
                opts.MapFrom<CurrentUserIdResolver>();
            });

        CreateMap<RequestProductoDto, Producto>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestSucursalDto, Sucursal>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestServicioDto, Servicio>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestFeriadoDto, Feriado>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestHorarioDto, Horario>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestInventarioDto, Inventario>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestInventarioProductoDto, InventarioProducto>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestFacturaDto, Factura>()
            .IncludeBase<RequestBaseDto, BaseModel>();
        
        CreateMap<RequestPedidoDto, Pedido>()
            .IncludeBase<RequestBaseDto, BaseModel>();
        
        CreateMap<RequestReservaDto, Reserva>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestReservaPreguntaDto, ReservaPregunta>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestInventarioProductoMovimientoDto, InventarioProductoMovimiento>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        CreateMap<RequestProveedorDto, Proveedor>()
            .IncludeBase<RequestBaseDto, BaseModel>();

        
        CreateMap<RequestTipoServicioDto, TipoServicio>();
        CreateMap<RequestSucursalHorarioDto, SucursalHorario>();
        CreateMap<RequestSucursalHorarioBloqueoDto, SucursalHorarioBloqueo>();
        CreateMap<RequestSucursalFeriadoDto, SucursalFeriado>();
        CreateMap<RequestDetalleFacturaDto,  DetalleFactura>();
        CreateMap<RequestDetallePedidoDto, DetallePedido>();
        CreateMap<RequestReservaServicioDto, ReservaServicio>();
    }
}
