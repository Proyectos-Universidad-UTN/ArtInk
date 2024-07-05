namespace ArtInk.Site.ViewModels.Request
{
    public record ImpuestoRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal Porcentaje { get; set; }
    }
}
