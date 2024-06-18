using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;


namespace ArtInk.Application.Profiles
{
    public class ApplicationProfile :Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Rol, inp => inp.MapFrom(ori => ori.IdRolNavigation))
                .ForMember(dest => dest.Genero, inp => inp.MapFrom(ori => ori.IdGeneroNavigation))
                .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.UnidadMedida, inp => inp.MapFrom(ori => ori.IdUnidadMedidaNavigation))
                .ForMember(dest => dest.Categoria, inp => inp.MapFrom(ori => ori.IdCategoriaNavigation));
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<UnidadMedida, UnidadMedidaDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<Factura, FacturaDTO>()
                .ForMember(dest => dest.Cliente, inp => inp.MapFrom(ori => ori.IdClienteNavigation))
                .ForMember(dest => dest.TipoPago, inp => inp.MapFrom(ori => ori.IdTipoPagoNavigation))
                .ForMember(dest => dest.UsuarioSucursal, inp => inp.MapFrom(ori => ori.IdUsuarioSucursalNavigation))
                .ForMember(dest => dest.Impuesto, inp => inp.MapFrom(ori => ori.IdImpuestoNavigation));
            CreateMap<Sucursal, SucursalDTO>()
                .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Inventario, InventarioDTO>();
            CreateMap<UsuarioSucursal, UsuarioSucursalDTO>();
            CreateMap<SucursalFeriado, SucursalFeriadoDTO>()
                 .ForMember(dest => dest.Feriado, inp => inp.MapFrom(ori => ori.IdFeriadoNavigation))
                 .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<ReservaPregunta, ReservaPreguntaDTO>()
                .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation));
            CreateMap<Reserva, ReservaDTO>()
                .ForMember(dest => dest.SucursalHorario, inp => inp.MapFrom(ori => ori.IdSucursalHorarioNavigation));
            CreateMap<SucursalHorario, SucursalHorarioDTO>()
                .ForMember(dest => dest.Horario, inp => inp.MapFrom(ori => ori.IdHorarioNavigation))
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Horario, HorarioDTO>()
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Distrito, DistritoDTO>()
                .ForMember(dest => dest.Canton, inp => inp.MapFrom(ori => ori.IdCantonNavigation));
            CreateMap<ReservaServicio, ReservaServicioDTO>()
                .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation))
                .ForMember(dest => dest.Servicio, inp => inp.MapFrom(ori => ori.IdServicioNavigation));
            CreateMap<Servicio, ServicioDTO>()
                .ForMember(dest => dest.TipoServicio, inp => inp.MapFrom(ori => ori.IdTipoServicioNavigation));
            CreateMap<TipoServicio, TipoServicioDTO>();
            CreateMap<Canton, CantonDTO>()
                .ForMember(dest => dest.Provincia, inp => inp.MapFrom(ori => ori.IdProvinciaNavigation));
            CreateMap<Contacto, ContactoDTO>()
                .ForMember(dest => dest.Proveedor, inp => inp.MapFrom(ori => ori.IdProveedorNavigation));
            CreateMap<DetalleFactura, DetalleFacturaDTO>()
                .ForMember(dest => dest.Factura, inp => inp.MapFrom(ori => ori.IdFacturaNavigation))
                .ForMember(dest => dest.Servicio, inp => inp.MapFrom(ori => ori.IdServicioNavigation));
            CreateMap<DetalleFacturaProducto, DetalleFacturaProductoDTO>()
                .ForMember(dest => dest.DetalleFactura, inp => inp.MapFrom(ori => ori.IdDetalleFacturaNavigation))
                .ForMember(dest => dest.Producto, inp => inp.MapFrom(ori => ori.IdProductoNavigation));
            CreateMap<Feriado, FeriadoDTO>();
            CreateMap<Genero, GeneroDTO>();
            CreateMap<Impuesto, ImpuestoDTO>();
            CreateMap<Inventario, InventarioDTO>()
                .ForMember(dest => dest.Producto, inp => inp.MapFrom(ori => ori.IdProductoNavigation))
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Proveedor, ProveedorDTO>()
                 .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<TipoPago, TipoPagoDTO>();
            CreateMap<TipoServicio, TipoServicioDTO>();
            CreateMap<UsuarioSucursal, UsuarioSucursalDTO>()
                 .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation))
                 .ForMember(dest => dest.Usuario, inp => inp.MapFrom(ori => ori.IdUsuarioNavigation));
            CreateMap<Cliente, ClienteDTO>()
                  .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));














        }
    }
}
