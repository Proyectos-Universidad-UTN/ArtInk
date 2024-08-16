using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryUsuario
{
    Task<ICollection<Usuario>> ListAsync();

    Task<ICollection<Usuario>> ListAsync(byte idRol);

    Task<bool> LibreAsignacionSucursal(short id, byte idSucursalAsignacion);

    Task<Usuario?> FindByIdAsync(short id);

    Task<bool> ExistsByIdAsync(short id);

    Task<Usuario?> FindByEmailAsync(string correoElectronico);

    Task<Usuario?> LoginAsync(string correoElectronico, string contrasenna);
}