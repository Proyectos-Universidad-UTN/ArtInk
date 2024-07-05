namespace ArtInk.Site.Configuration
{
    public static class Constantes
    {
        public const string MEDIATYPEJSON = "application/json";

        public const string GET = "GET";
        public const string PUT = "PUT";
        public const string POST = "POST";
        public const string DELETE = "DELETE";

        //Url Usuarios
        public const string GETALLUSUARIOS = "usuario"; //minuscula es el endpoint del API

        //Url Productos
        public const string GETALLPRODUCTOS = "producto"; 
        public const string GETPRODUCTOBYID = "producto/{0}";
        public const string POSTPRODUCTO = "producto";
       
        //Url Rol
        public const string GETALLROLS = "rol"; 
        public const string GETROLBYID = "rol/{0}";

        //Url Reserva
        public const string GETALLRESERVASBYROL = "rol/{0}/reserva"; 
        public const string GETRESERVABYID = "reserva/{0}";

        //Url Sucursales
        public const string GETALLSUCURSALES = "sucursal"; 
        public const string GETSUCURSALBYID = "sucursal/{0}";
        public const string POSTSUCURSAL = "sucursal";
        public const string PUTSUCURSAL = "sucursal/{0}";


        //Url Servicos
        public const string GETALLSERVICIOS = "servicio"; 
        public const string GETSERVICIOBYID = "servicio/{0}";
        public const string POSTSERVICIO = "servicio";

        //Url Horarios
        public const string GETALLHORARIOS = "horario"; 
        public const string GETHORARIOBYID = "horario/{0}";

        //Url Facturas
        public const string GETALLFACTURAS = "factura"; 
        public const string GETFACTURABYID = "factura/{0}";

        //Url DetalleFactura
        public const string GETALLDETALLEFACTURAS = "factura/{0}/detallefactura"; 
        public const string GETDETALLEFACTURABYID = "factura/{0}/detallefactura/{1}";

        //Url ReservaPregunta
        public const string GETALLRESERVASPREGUNTAS = "reserva"; 
        public const string GETRESERVAPREGUNTABYID = "reserva/{0}";  
        
        //Url UnidadMedida
        public const string GETALLUNIDAMEDIDAS = "unidadmedida"; 

        //Url Categoria
        public const string GETALLCATEGORIAS = "categoria";

        //Url Provincia
        public const string GETALLPROVINCIA = "provincia";
        public const string GETPROVINCIABYID = "provincia/{0}";

        //Url Distrito
        public const string GETALLDISTRITOS = "distrito"; 
        public const string GETALLDISTRITOSBYCANTON = "canton/{0}/distrito";

        //Url Canton
        public const string GETALLCANTONESBYPROVINCIA = "provincia/{0}/canton"; 
        public const string GETCANTONBYID = "canton/{0}";

        //Url TipoServicio
        public const string GETALLTIPOSERVICIOS = "tiposervicio"; //minuscula es el endpoint del API

        //Url TipoServicio
        public const string GETALLTIPOSERVICIOS = "tiposervicio"; //minuscula es el endpoint del API

    }
}
