using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDetalleFactura
    {
        Task<DetalleFactura?> FindByIdAsync(long idFactura, long id);
        Task<ICollection<DetalleFactura>> ListAsync(long idFactura);
    }
}
