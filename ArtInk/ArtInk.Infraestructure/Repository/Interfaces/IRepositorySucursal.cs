using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositorySucursal
    {
        Task<Sucursal> CreateSucursalAsync(Sucursal sucursal);

        Task<Sucursal> UpdateSucursalAsync(Sucursal sucursal);

        Task<ICollection<Sucursal>> ListAsync();

        Task<Sucursal?> FindByIdAsync(byte id);

        Task<bool> ExisteSucursal(byte id);
    }
}
