﻿using Microsoft.AspNetCore.Authentication.OAuth;

namespace ArtInk.Site.Configuration;

public static class Constantes
{
    public const string MEDIATYPEJSON = "application/json";

    public const string GET = "GET";
    public const string PUT = "PUT";
    public const string POST = "POST";
    public const string DELETE = "DELETE";

    //Url Usuarios
    public const string GETALLUSUARIOS = "usuario"; //minuscula es el endpoint del API
    public const string GETALLUSUARIOSBYROL = "usuario/ByRol/{0}";
    public const string LIBREASIGNACIONSUCURSAL = "usuario/{0}/sucursal/{1}/libre-asignacion";

    //Url Sucursal usuarios
    public const string POSTUSUARIOSUCURSAL = "sucursal/{0}/usuarios";

    //Url Productos
    public const string GETALLPRODUCTOS = "producto";
    public const string GETALLPRODUCTOSEXCLUDINGINVENTARIOPRODUCTO = "producto?excludeProductosInventario=true&idInventario={0}";
    public const string GETPRODUCTOBYID = "producto/{0}";
    public const string POSTPRODUCTO = "producto";
    public const string PUTPRODUCTO = "producto/{0}";

    //Url Clientes
    public const string GETALLCLIENTES = "cliente";
    public const string GETCLIENTEBYID = "cliente/{0}";

    //Url Rol
    public const string GETALLROLS = "rol";
    public const string GETROLBYID = "rol/{0}";

    //Url Sucursales
    public const string GETALLSUCURSALES = "sucursal";
    public const string GETALLSUCURSALESBYROL = "sucursal/ByRol";
    public const string GETSUCURSALBYID = "sucursal/{0}";
    public const string POSTSUCURSAL = "sucursal";
    public const string PUTSUCURSAL = "sucursal/{0}";


    //Url Servicos
    public const string GETALLSERVICIOS = "servicio";
    public const string GETSERVICIOBYID = "servicio/{0}";
    public const string POSTSERVICIO = "servicio";
    public const string PUTSERVICIO = "servicio/{0}";

    //Url Horarios
    public const string GETALLHORARIOS = "horario";
    public const string GETHORARIOBYID = "horario/{0}";
    public const string POSTHORARIO = "horario";
    public const string PUTHORARIO = "horario/{0}";
    public const string DELETEHORARIO = "horario/{0}";

    //Url Facturas
    public const string GETALLFACTURAS = "factura";
    public const string GETFACTURABYID = "factura/{0}";
    public const string POSTFACTURA = "factura";

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
    public const string GETDISTRITOBYID = "distrito/{0}";
    public const string GETALLDISTRITOSBYCANTON = "canton/{0}/distrito";

    //Url Canton
    public const string GETALLCANTONESBYPROVINCIA = "provincia/{0}/canton";
    public const string GETCANTONBYID = "canton/{0}";

    //Url TipoServicio
    public const string GETALLTIPOSERVICIOS = "tiposervicio"; //minuscula es el endpoint del API

    //Url TipoPago
    public const string GETALLTIPOPAGOS = "tipopago";

    // Url feriados
    public const string GETALLFERIADOS = "feriado";
    public const string GETFERIADOBYID = "feriado/{0}";
    public const string POSTFERIADO = "feriado";
    public const string PUTFERIADO = "feriado/{0}";
    public const string DELETEFERIADO = "feriado/{0}";

    // Url sucursal feriados
    public const string GETSUCURSALFERIADO = "Sucursal/{0}/Feriado?Anno={1}";
    public const string POSTSUCURSALFERIADO = "Sucursal/{0}/Feriado";

    // Url sucursal horarios
    public const string GETSUCURSALHORARIO = "SucursalHorario/{0}";
    public const string GETHORARIOBYSUCURSAL = "Sucursal/{0}/Horario";
    public const string POSTSUCURSALHORARIO = "Sucursal/{0}/Horario";

    // Url sucursal horario bloqueos

    public const string POSTSUCURSALHORARIOBLOQUEO = "SucursalHorario/{0}";

    // Url usuario Sucursales
    public const string GETALLUSUARIOSUCURSALES = "usuariosucursal";

    //Url Impuestos
    public const string GETALLIMPUESTOS = "impuesto";

    // Url inventario
    public const string GETINVENTARIOSBYSUCURSAL = "Sucursal/{0}/Inventario";
    public const string GETINVENTARIOBYID = "Inventario/{0}";
    public const string POSTINVENTARIO = "Sucursal/{0}/Inventario";
    public const string PUTINVENTARIO = "Sucursal/{0}/Inventario/{1}";
    public const string DELETEINVENTARIO = "Inventario/{0}";

    // Url Pedidos
    public const string GETALLPEDIDOS = "Pedido";
    public const string POSTPEDIDO = "Pedido";
    public const string GETPEDIDOYID = "pedido/{0}";

    //Url Reserva
    public const string GETALLRESERVAS = "reserva";
    public const string GETRESERVABYID = "reserva/{0}";
    public const string POSTRESERVA = "reserva";
    public const string PUTRESERVA = "reserva/{0}";
    public const string GETALLHORADISPONIBLE = "Sucursal/{0}/Disponibilidad-Dia/{1}";

    // Url ReservaServicio
    public const string GETRESERVASERVICIO = "ReservaServicio/{0}";
    public const string GETSERVICIOBYRESERVA = "Reserva/{0}/Servicio";
    public const string POSTRESERVASERVICIO = "Reserva/{0}/Servicio";

    // Url inventario producto
    public const string GETINVENTARIOPRODUCTO = "InventarioProducto/{0}";
    public const string POSTINVENTARIOPRODUCTO = "InventarioProducto";
    public const string PUTINVENTARIOPRODUCTO = "InventarioProducto/{0}";

    // Url inventario producto movimiento
    public const string POSTINVENTARIOPRODUCTOMOVIMIENTO = "InventarioProductoMovimiento";

    // Url proveedor
    public const string GETALLPROVEEDOR = "Proveedor";
    public const string GETPROVEEDORBYID = "Proveedor/{0}";
    public const string POSTPROVEEDOR = "Proveedor";
    public const string PUTPROVEEDOR = "Proveedor/{0}";
    public const string DELETEPROVEEDOR = "Proveedor/{0}";

    // Url authentication
    public const string GETAUTHTOKEN = "Authentication";
    public const string GETREFRESHTOKEN = "Authentication/refresh";
}