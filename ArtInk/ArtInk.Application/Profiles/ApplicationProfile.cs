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
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
