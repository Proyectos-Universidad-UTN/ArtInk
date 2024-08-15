using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryUsuario
{
    Task<ICollection<Usuario>> ListAsync();

    Task<Usuario?> FindByIdAsync(short id);

    Task<Usuario?> FindByEmailAsync(string correoElectronico);

    Task<Usuario?> LoginAsync(string correoElectronico, string contrasenna);
}