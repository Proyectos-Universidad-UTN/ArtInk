namespace ArtInk.Application.RequestDTOs;

public record RequestProductoDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public byte IdCategoria { get; set; }

    public decimal Costo { get; set; }

    public string Sku { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public byte IdUnidadMedida { get; set; }

    public bool Activo { get; set; }
}
