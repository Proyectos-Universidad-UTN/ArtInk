﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public record ProductoResponseDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    public string Marca { get; set; } = null!;

    [DisplayName("Categoría")]
    public byte IdCategoria { get; set; }

    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Costo { get; set; }

    public string Sku { get; set; } = null!;

    [DisplayName("Unidad Medida")]
    public byte IdUnidadMedida { get; set; }

    public bool Activo { get; set; }

    public virtual CategoriaResponseDto Categoria { get; set; } = null!;

    public virtual UnidadMedidaResponseDto UnidadMedida { get; set; } = null!;

    public virtual ICollection<InventarioProductoResponseDto> InventarioProductos { get; set; } = new List<InventarioProductoResponseDto>();
}