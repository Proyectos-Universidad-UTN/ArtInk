using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public class SucursalUsuario
{
    public List<UsuarioSucursalRequestDto> UsuariosSucursal { get; set; } = new List<UsuarioSucursalRequestDto>();

    public SucursalResponseDto Sucursal { get; set; } = null!;

    public IEnumerable<UsuarioResponseDto> Usuarios = new List<UsuarioResponseDto>();

    public char Accion { get; set; }

    public byte IdUsuario { get; set; }

    public void AgregarUsuario(UsuarioSucursalRequestDto usuario) => UsuariosSucursal.Add(usuario);

    public void EliminarUsuario() => UsuariosSucursal = UsuariosSucursal.Where(x => x.IdUsuario != IdUsuario).ToList();
}