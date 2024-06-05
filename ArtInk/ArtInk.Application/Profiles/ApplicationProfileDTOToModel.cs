using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;

namespace ArtInk.Application.Profiles;

public class ApplicationProfileDTOToModel : Profile
{
    public ApplicationProfileDTOToModel()
    {
        CreateMap<SucursalDTO, Sucursal>()
                .ForMember(dest => dest.IdDistritoNavigation, inpt => inpt.MapFrom(ori => ori.Distrito)); // Esto es por que en los models se llama navigation, replicar en cada clase
        CreateMap<FeriadoDTO, Feriado>();
        CreateMap<HorarioDTO, Horario>();
        CreateMap<InventarioDTO, Inventario>();
        CreateMap<SucursalHorarioDTO, SucursalHorario>();
        CreateMap<UsuarioSucursalDTO, UsuarioSucursal>();


        CreateMap<CantonDTO, Canton>();
        CreateMap<CategoriaDTO, Categoria>();
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<ContactoDTO, Contacto>();
        CreateMap<DetalleFacturaDTO, DetalleFactura>();
        CreateMap<DetalleFacturaProductoDTO, DetalleFacturaProducto>();
        CreateMap<DistritoDTO, Distrito>();
        CreateMap<FacturaDTO, Factura>();
        CreateMap<GeneroDTO, Genero>();
        CreateMap<ImpuestoDTO, Impuesto>();
        CreateMap<InventarioDTO, Inventario>();
        CreateMap<ProductoDTO, Producto>();
        CreateMap<ReservaDTO, Reserva>();
        CreateMap<ReservaPreguntaDTO, ReservaPregunta>();
        CreateMap<ReservaServicioDTO, ReservaServicio>();
        CreateMap<RolDTO, Rol>();
        CreateMap<ServicioDTO, Servicio>();
        CreateMap<TipoPagoDTO, TipoPago>();
        CreateMap<TipoServicioDTO, TipoServicio>();
        CreateMap<UnidadMedidaDTO, UnidadMedida>();
        CreateMap<UsuarioDTO, Usuario>();
    }
}