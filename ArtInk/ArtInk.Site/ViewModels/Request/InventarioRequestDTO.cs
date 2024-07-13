using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request;

public record InventarioRequestDto
{
    public short Id { get; set; }

    [Required(ErrorMessage = "Ingrese el nombre del inventario")]
    public string Nombre { get; set; } = null!;

    [DisplayName("Sucursal")]
    [Range(1, 99, ErrorMessage = "Seleccione una sucursal")]
    public byte IdSucursal { get; set; }

    public bool Activo { get; set; }

    public List<SucursalResponseDto> Sucursales { get; set; } = new List<SucursalResponseDto>();
}