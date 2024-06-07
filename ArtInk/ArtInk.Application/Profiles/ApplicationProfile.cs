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

        }
    }
}
