using ArtInk.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceUnidadMedida
    {
        Task<ICollection<UnidadMedidaDTO>> ListAsync();
        Task<UnidadMedidaDTO> FindByIdAsync(byte id);
    }
}
