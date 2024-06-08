namespace ArtInk.Site.ViewModels.Response
{
    public class UsuarioResponseDTO
    {
        public short Id { get; set; }


        public string Cedula { get; set; } = null!;


        public string Nombre { get; set; } = null!;


        public string Apellidos { get; set; } = null!;

        public int Telefono { get; set; }


        public string CorreoElectronico { get; set; } = null!;

        public short IdDistrito { get; set; }


        public string? DireccionExacta { get; set; }

        public DateOnly FechaNacimiento { get; set; }



        public string Contrasenna { get; set; } = null!;

        public byte IdGenero { get; set; }

        public bool Activo { get; set; }


        public string? UrlFoto { get; set; }

        public byte IdRol { get; set; }



        //public virtual Distrito IdDistritoNavigation { get; set; } = null!;


        //public virtual Genero IdGeneroNavigation { get; set; } = null!;


        public virtual RolResponseDTO Rol { get; set; } = null!;


        //public virtual ICollection<UsuarioSucursal> UsuarioSucursal { get; set; } = new List<UsuarioSucursal>();

    }
}
