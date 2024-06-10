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

        //Url Rol
        public const string GETALLROLS = "rol"; //minuscula es el endpoint del API
        public const string GETROLBYID = "rol/{0}";

        //Url Reserva
        public const string GETALLRESERVAS = "reserva"; //minuscula es el endpoint del API
        public const string GETRESERVABYID = "reserva/{0}";

        //Url Sucursales
        public const string GETALLSUCURSALES = "sucursal"; //minuscula es el endpoint del API
        public const string GETSUCURSALBYID = "sucursal/{0}";

    }
}
