﻿using ArtInk.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceCategoria
    {
        Task<ICollection<CategoriaDTO>> ListAsync();
        Task<CategoriaDTO> FindByIdAsync(byte id);
    }
}
