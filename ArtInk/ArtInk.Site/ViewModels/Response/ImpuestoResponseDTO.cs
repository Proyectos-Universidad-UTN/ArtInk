namespace ArtInk.Site.ViewModels.Response
{
    public record ImpuestoResponseDTO
    {

        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal Porcentaje { get; set; }

        public virtual ICollection<FacturaResponseDTO> Facturas { get; set; } = new List<FacturaResponseDTO>();
    }
}
