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
        public const string GETALLPRODUCTOS = "producto"; //minuscula es el endpoint del API
        public const string GETPRODUCTOBYID = "producto/{0}";
        public const string POSTPRODUCTO = "producto";
       
        //Url Rol
        public const string GETALLROLS = "rol"; //minuscula es el endpoint del API
        public const string GETROLBYID = "rol/{0}";

        //Url Reserva
        public const string GETALLRESERVASBYROL = "rol/{0}/reserva"; //minuscula es el endpoint del API
        public const string GETRESERVABYID = "reserva/{0}";

        //Url Sucursales
        public const string GETALLSUCURSALES = "sucursal"; //minuscula es el endpoint del API
        public const string GETSUCURSALBYID = "sucursal/{0}";


        //Url Servicos
        public const string GETALLSERVICIOS = "servicio"; //minuscula es el endpoint del API
        public const string GETSERVICIOBYID = "servicio/{0}";

        //Url Horarios
        public const string GETALLHORARIOS = "horario"; //minuscula es el endpoint del API
        public const string GETHORARIOBYID = "horario/{0}";

        //Url Facturas
        public const string GETALLFACTURAS = "factura"; //minuscula es el endpoint del API
        public const string GETFACTURABYID = "factura/{0}";

        //Url DetalleFactura
        public const string GETALLDETALLEFACTURAS = "factura/{0}/detallefactura"; //minuscula es el endpoint del API
        public const string GETDETALLEFACTURABYID = "factura/{0}/detallefactura/{1}";

        //Url ReservaPregunta
        public const string GETALLRESERVASPREGUNTAS = "reserva"; //minuscula es el endpoint del API
        public const string GETRESERVAPREGUNTABYID = "reserva/{0}"; 
        
        //Url UnidadMedida
        public const string GETALLUNIDAMEDIDAS = "unidadmedida"; //minuscula es el endpoint del API

        //Url Categoria
        public const string GETALLCATEGORIAS = "categoria"; //minuscula es el endpoint del API


    }
}
