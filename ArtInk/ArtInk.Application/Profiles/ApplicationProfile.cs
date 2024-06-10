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
                .ForMember(dest => dest.Rol, inp => inp.MapFrom(ori => ori.IdRolNavigation));
            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.UnidadMedida, inp => inp.MapFrom(ori => ori.IdUnidadMedidaNavigation))
                .ForMember(dest => dest.Categoria, inp => inp.MapFrom(ori => ori.IdCategoriaNavigation));
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<UnidadMedida, UnidadMedidaDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<ReservaPregunta, ReservaPreguntaDTO>()
                .ForMember(dest => dest.Reserva, inp => inp.MapFrom(ori => ori.IdReservaNavigation));
            CreateMap<Reserva, ReservaDTO>()
                .ForMember(dest => dest.SucursalHorario, inp => inp.MapFrom(ori => ori.IdSucursalHorarioNavigation));
            CreateMap<SucursalHorario, SucursalHorarioDTO>()
                .ForMember(dest => dest.Horario, inp => inp.MapFrom(ori => ori.IdHorarioNavigation))
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Horario, HorarioDTO>()
                .ForMember(dest => dest.Sucursal, inp => inp.MapFrom(ori => ori.IdSucursalNavigation));
            CreateMap<Sucursal, SucursalDTO>()
                .ForMember(dest => dest.Distrito, inp => inp.MapFrom(ori => ori.IdDistritoNavigation));
            CreateMap<Distrito, DistritoDTO>();
            CreateMap<ReservaServicio, ReservaServicioDTO>()
                .ForMember(dest => dest.ReservaNav, inp => inp.MapFrom(ori => ori.IdReservaNavigation))
                .ForMember(dest => dest.ServicioNav, inp => inp.MapFrom(ori => ori.IdReservaNavigation));
            CreateMap<Servicio, ServicioDTO>()
                .ForMember(dest => dest.TipoServicio, inp => inp.MapFrom(ori => ori.IdTipoServicioNavigation));
            CreateMap<TipoServicio, TipoServicioDTO>();





        }
    }
}
