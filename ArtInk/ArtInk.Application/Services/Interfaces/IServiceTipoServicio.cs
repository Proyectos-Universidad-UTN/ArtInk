using ArtInk.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceTipoServicio
    {
        Task<ICollection<TipoServicioDTO>> ListAsync();
        Task<TipoServicioDTO> FindByIdAsync(byte id);
    }
}
