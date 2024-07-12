using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record DistritoRequestDto
{
    public short Id { get; set; }

    [DisplayName("Nombre")]
    public string Nombre { get; set; } = null!;

    [DisplayName("Cantón")]
    public byte IdCanton { get; set; }
}