using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryUsuarioSucursal
{
    Task<bool> AsignarEncargados(byte idSucursal, IEnumerable<UsuarioSucursal> usuariosSucursal);

    Task<IEnumerable<UsuarioSucursal>> ObtenerUsuariosSucursal(byte idSucursal);
}