using ArtInk.Application.RequestDTOs;
using ArtInk.Infraestructure.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Profiles
{
    public class DTOToModelApplicationProfile : Profile
    {
        public DTOToModelApplicationProfile()
        {
            CreateMap<RequestServicioDTO, Servicio>();
        }
    }
}

