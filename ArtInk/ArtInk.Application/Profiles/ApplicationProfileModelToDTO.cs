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
    public class ApplicationProfileModelToDTO : Profile
    {
        public ApplicationProfileModelToDTO()
        {
            // Atención al mapear
            CreateMap<Sucursal, SucursalDTO>()
                .ForMember(dest => dest.Distrito, inpt => inpt.MapFrom(ori => ori.IdDistritoNavigation)); // Esto es por que en los models se llama navigation, replicar en cada clase
            CreateMap<Feriado, FeriadoDTO>();
            CreateMap<Horario, HorarioDTO>();
            CreateMap<Inventario, InventarioDTO>();
            CreateMap<SucursalHorario, SucursalHorarioDTO>();
            CreateMap<UsuarioSucursal, UsuarioSucursalDTO>();


            CreateMap<Canton, CantonDTO>();
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Contacto, ContactoDTO>();
            CreateMap<DetalleFactura, DetalleFacturaDTO>();
            CreateMap<DetalleFacturaProducto, DetalleFacturaProductoDTO>();
            CreateMap<Distrito, DistritoDTO>();
            CreateMap<Factura, FacturaDTO>();
            CreateMap<Genero, GeneroDTO>();
            CreateMap<Impuesto, ImpuestoDTO>();
            CreateMap<Inventario, InventarioDTO>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaPregunta, ReservaPreguntaDTO>();
            CreateMap<ReservaServicio, ReservaServicioDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<Servicio, ServicioDTO>();
            CreateMap<TipoPago, TipoPagoDTO>();
            CreateMap<TipoServicio, TipoServicioDTO>();
            CreateMap<UnidadMedida, UnidadMedidaDTO>();
            CreateMap<Usuario, UsuarioDTO>();



        }
    }
}
