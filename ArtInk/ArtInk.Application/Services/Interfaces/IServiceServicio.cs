﻿using ArtInk.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceServicio
    {
        Task<ICollection<ServicioDTO>> ListAsync();
        Task<ServicioDTO> FindByIdAsync(byte id);
    }
}