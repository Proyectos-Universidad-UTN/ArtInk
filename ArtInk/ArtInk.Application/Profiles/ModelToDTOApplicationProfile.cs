using ArtInk.Application.DTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.Profiles
{
    public class ModelToDtoApplicationProfile :Profile
    {
        public ModelToDtoApplicationProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Rol, inp => inp.MapFrom(ori => ori.IdRolNavigation))
                .ForMember(dest => dest.Genero, inp => inp.MapFrom(ori => ori.IdGeneroNavigation))
                .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.UnidadMedida, inp => inp.MapFrom(ori => ori.IdUnidadMedidaNavigation))
                .ForMember(dest => dest.Categoria, inp => inp.MapFrom(ori => ori.IdCategoriaNavigation));
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<UnidadMedida, UnidadMedidaDto>();
            CreateMap<Rol, RolDto>();
            CreateMap<Factura, FacturaDto>()
                .ForMember(dest => dest.Cliente, inp => inp.MapFrom(ori => ori.IdClienteNavigation))
                .ForMember(dest => dest.TipoPago, inp => inp.MapFrom(ori => ori.IdTipoPagoNavigation))
                .ForMember(dest => dest.UsuarioSucursal, inp => inp.MapFrom(ori => ori.IdUsuarioSucursalNavigation))
                .ForMember(dest => dest.Impuesto, inp => inp.MapFrom(ori => ori.IdImpuestoNavigation))
                .ForMember(dest => dest.Pedido, inp => inp.MapFrom(ori => ori.IdPedidoNavigation));
            CreateMap<Pedido, PedidoDto>()
               .ForMember(dest => dest.Cliente, inp => inp.MapFrom(ori => ori.IdClienteNavigation))
               .ForMember(dest => dest.TipoPago, inp => inp.MapFrom(ori => ori.IdTipoPagoNavigation))
               .ForMember(dest => dest.UsuarioSucursal, inp => inp.MapFrom(ori => ori.IdUsuarioSucursalNavigation))
               .ForMember(dest => dest.Impuesto, inp => inp.MapFrom(ori => ori.IdImpuestoNavigation))
               .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation));
            CreateMap<Sucursal, SucursalDto>()
                .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Inventario, InventarioDto>();
            CreateMap<UsuarioSucursal, UsuarioSucursalDto>();
            CreateMap<SucursalFeriado, SucursalFeriadoDto>()
                 .ForMember(dest => dest.Feriado, inp => inp.MapFrom(ori => ori.IdFeriadoNavigation))
                 .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<ReservaPregunta, ReservaPreguntaDto>()
                .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation));
            CreateMap<Reserva, ReservaDto>()
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation))
                .ForMember(dest => dest.UsuarioSucursal, inp => inp.MapFrom(ori => ori.IdUsuarioSucursalNavigation))
                .ForMember(dest => dest.Cliente, inp => inp.MapFrom(ori => ori.IdClienteNavigation));
            CreateMap<SucursalHorario, SucursalHorarioDto>()
                .ForMember(dest => dest.Horario, inp => inp.MapFrom(ori => ori.IdHorarioNavigation))
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Horario, HorarioDto>();
            CreateMap<Distrito, DistritoDto>()
                .ForMember(dest => dest.Canton, inp => inp.MapFrom(ori => ori.IdCantonNavigation));
            CreateMap<ReservaServicio, ReservaServicioDto>()
                .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation))
                .ForMember(dest => dest.Servicio, inp => inp.MapFrom(ori => ori.IdServicioNavigation));
            CreateMap<Servicio, ServicioDto>()
                .ForMember(dest => dest.TipoServicio, inp => inp.MapFrom(ori => ori.IdTipoServicioNavigation));
            CreateMap<TipoServicio, TipoServicioDto>();
            CreateMap<Canton, CantonDto>()
                .ForMember(dest => dest.Provincia, inp => inp.MapFrom(ori => ori.IdProvinciaNavigation));
            CreateMap<Contacto, ContactoDto>()
                .ForMember(dest => dest.Proveedor, inp => inp.MapFrom(ori => ori.IdProveedorNavigation));
            CreateMap<DetalleFactura, DetalleFacturaDto>()
                .ForMember(dest => dest.Factura, inp => inp.MapFrom(ori => ori.IdFacturaNavigation))
                .ForMember(dest => dest.Servicio, inp => inp.MapFrom(ori => ori.IdServicioNavigation));
            CreateMap<DetallePedido, DetallePedidoDto>()
                .ForMember(dest => dest.Pedido, inp => inp.MapFrom(ori => ori.IdPedidoNavigation))
                .ForMember(dest => dest.Servicio, inp => inp.MapFrom(ori => ori.IdServicioNavigation));
            CreateMap<DetalleFacturaProducto, DetalleFacturaProductoDto>()
                .ForMember(dest => dest.DetalleFactura, inp => inp.MapFrom(ori => ori.IdDetalleFacturaNavigation))
                .ForMember(dest => dest.Producto, inp => inp.MapFrom(ori => ori.IdProductoNavigation));
            CreateMap<DetallePedidoProducto, DetallePedidoProductoDto>()
                .ForMember(dest => dest.DetallePedido, inp => inp.MapFrom(ori => ori.IdDetallePedidoNavigation))
                .ForMember(dest => dest.Producto, inp => inp.MapFrom(ori => ori.IdProductoNavigation));
            CreateMap<Feriado, FeriadoDto>();
            CreateMap<Genero, GeneroDto>();
            CreateMap<Impuesto, ImpuestoDto>();
            CreateMap<Inventario, InventarioDto>()
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<InventarioProducto, InventarioProductoDto>()
                .ForMember(dest => dest.Inventario, inp => inp.MapFrom(ori => ori.IdInventarioNavigation))
                .ForMember(dest => dest.Producto, inp => inp.MapFrom(ori => ori.IdProductoNavigation));
            CreateMap<Proveedor, ProveedorDto>()
                 .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Provincia, ProvinciaDto>();
            CreateMap<TipoPago, TipoPagoDto>();
            CreateMap<TipoServicio, TipoServicioDto>();
            CreateMap<UsuarioSucursal, UsuarioSucursalDto>()
                 .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation))
                 .ForMember(dest => dest.Usuario, inp => inp.MapFrom(ori => ori.IdUsuarioNavigation));
            CreateMap<Cliente, ClienteDto>()
                  .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<InventarioProductoMovimiento, InventarioProductoMovimientoDto>()
                .ForMember(dest => dest.InventarioProducto, inp => inp.MapFrom(ori => ori.IdInventarioProductoNavigation));
        }
    }
}
