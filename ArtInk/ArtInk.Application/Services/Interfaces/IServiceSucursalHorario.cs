﻿using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceSucursalHorario
    {
        Task<ICollection<SucursalHorarioDto>> GetHorariosBySucursalAsync(byte idSucursal);

        Task<SucursalHorarioDto?> GetSucursalHorarioByIdAsync(short id);

        Task<bool> CreateSucursalHorarioAsync(byte idSucursal, IEnumerable<RequestSucursalHorarioDto> sucursalHorarios);
    }
}