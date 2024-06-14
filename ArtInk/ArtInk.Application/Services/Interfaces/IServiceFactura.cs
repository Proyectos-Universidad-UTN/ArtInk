using ArtInk.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceFactura
    {
        Task<ICollection<FacturaDTO>> ListAsync();
        Task<FacturaDTO> FindByIdAsync(long id);
    }
}
