using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFactura
    {
        Task<ICollection<Factura>> ListAsync();
        Task<Factura?> FindByIdAsync(long id);

    }
}
