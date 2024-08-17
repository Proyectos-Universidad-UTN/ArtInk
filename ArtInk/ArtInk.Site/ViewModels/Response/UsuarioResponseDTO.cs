using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record UsuarioResponseDto
{
    public short Id { get; set; }

    [DisplayName("Cédula")]
    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    [DisplayName("Télefono")]
    public int Telefono { get; set; }

    [DisplayName("Correo Electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Distrito")]
    public short IdDistrito { get; set; }

    [DisplayName("Dirección Exacta")]
    public string? DireccionExacta { get; set; }

    [DisplayName("Fecha Nacimiento")]
    public DateOnly FechaNacimiento { get; set; }

    [DisplayName("Contraseña")]
    public string Contrasenna { get; set; } = null!;

    [DisplayName("Género")]
    public byte IdGenero { get; set; }

    public bool Activo { get; set; }

    public string? UrlFoto { get; set; }

    [DisplayName("Rol")]
    public byte IdRol { get; set; }

    public virtual DistritoResponseDto Distrito { get; set; } = null!;

    public virtual GeneroResponseDto Genero { get; set; } = null!;

    public virtual RolResponseDto Rol { get; set; } = null!;

    private string? _nombreCompleto;

    public string NombreCompleto 
    {
        get => string.IsNullOrEmpty(Nombre) ? _nombreCompleto ?? "" : $"{Nombre ?? ""} {Apellidos ?? ""} - Rol: {Rol.Descripcion}";
        set => _nombreCompleto = value; 
    }
    
    public virtual ICollection<UsuarioSucursalResponseDto> UsuarioSucursal { get; set; } = new List<UsuarioSucursalResponseDto>();
}