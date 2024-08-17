using System.Text;
using ArtInk.Site.Client;
using ArtInk.Site.Common;
using ArtInk.Site.Configuration;
using ArtInk.Site.Models;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalController(IApiArtInkClient cliente, IMapper mapper, ICurrentUserAccessor currentUserAccessor) : BaseArtInkController(currentUserAccessor)
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string ERRORMESSAGEPARTIAL = "ErrorMessagePartial";
    const string SUCCESSMESSAGE = "SuccessMessage";
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string SELECCIONEPROVINCIA = "Seleccione una provincia";
    const string INDEXVIEW = "Index";
    const string HOMECONTROLLER = "Home";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        if (collection == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEXVIEW, HOMECONTROLLER);
        }

        return View(collection);
    }

    public async Task<IActionResult> Details(byte id)
    {
        var url = string.Format(Constantes.GETSUCURSALBYID, id);
        var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursal == null || !ModelState.IsValid)
        {
            SetErrorMessage();
            return RedirectToAction(INDEXVIEW, HOMECONTROLLER);
        }

        return View(sucursal);
    }

    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<IActionResult> Create()
    {
        try
        {
            var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
            provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });

            if (provincias == null) return RedirectToAction(INDEXVIEW, HOMECONTROLLER);

            var sucursal = new SucursalRequestDto()
            {
                Provincias = provincias
            };
            return View(sucursal);
        }
        catch (Exception)
        {
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<IActionResult> Create(SucursalRequestDto sucursal)
    {
        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        if (provincias == null) return RedirectToAction(nameof(Index));

        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });
        sucursal.Provincias = provincias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return RedirectToAction(nameof(Index));
        }

        var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.POST, Constantes.POSTSUCURSAL, valoresConsumo: Serialization.Serialize(sucursal));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(sucursal);
        }

        TempData["SuccessMessage"] = "Sucursal creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<IActionResult> Edit(byte id)
    {
        var (falloEjecucion, sucursalExisting) = await ObtenerSucursalAsync(id);
        if (falloEjecucion || !ModelState.IsValid) return RedirectToAction(nameof(Index));

        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });

        var sucursal = mapper.Map<SucursalRequestDto>(sucursalExisting);
        sucursal.Provincias = provincias;
        sucursal.IdDistrito = sucursalExisting.IdDistrito;
        sucursal.IdCanton = sucursalExisting.Distrito.IdCanton;
        sucursal.IdProvincia = sucursalExisting.Distrito.Canton.IdProvincia;

        return View(sucursal);
    }

    [HttpPost]
    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<IActionResult> Edit(SucursalRequestDto sucursal)
    {
        var url = string.Format(Constantes.PUTSUCURSAL, sucursal.Id);
        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        if (provincias == null) return RedirectToAction(nameof(Index));

        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });
        sucursal.Provincias = provincias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(sucursal);
        }

        var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(sucursal));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(sucursal);
        }

        TempData["SuccessMessage"] = "Sucursal actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<ActionResult> AsociarEncargados(byte id)
    {
        var (falloEjecucion, sucursal) = await ObtenerSucursalAsync(id);
        if (falloEjecucion || !ModelState.IsValid) return RedirectToAction(nameof(Index));

        var (falloEjecucionUsuarios, usuarios) = await ObtenerUsuariosAsync();
        if (falloEjecucionUsuarios) return RedirectToAction(nameof(Index));

        var sucursalUsuario = new SucursalUsuario
        {
            Sucursal = sucursal,
            UsuariosSucursal = ObtenerEncargadosExistentes(sucursal),
        };
        sucursalUsuario.Usuarios = CargarUsuariosDisponibles(usuarios, sucursalUsuario);

        return View(sucursalUsuario);
    }

    [HttpPost]
    [RolAccess(Rol.ADMINISTRADOR)]
    public async Task<ActionResult> AsociarEncargados(SucursalUsuario sucursalUsuario)
    {
        var (falloEjecucion, sucursal) = await ObtenerSucursalAsync(sucursalUsuario.Sucursal.Id);
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var (falloEjecucionUsuarios, usuarios) = await ObtenerUsuariosAsync();
        if (falloEjecucionUsuarios) return RedirectToAction(nameof(Index));

        sucursalUsuario.Usuarios = CargarUsuariosDisponibles(usuarios, sucursalUsuario);

        RemoveValuesRequireModel(sucursalUsuario.UsuariosSucursal.Count);
        if(!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(sucursal);
        }

        var url = string.Format(Constantes.POSTUSUARIOSUCURSAL, sucursalUsuario.Sucursal.Id);
        var resultado = await cliente.ConsumirAPIAsync<bool?>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalUsuario.UsuariosSucursal));
        if (resultado != null && resultado.Value)
        {
            TempData[SUCCESSMESSAGE] = "Usuarios asignados correctamente";
            return RedirectToAction(INDEXVIEW);
        }

        SetErrorMessage();
        return View(sucursalUsuario);
    }

    [HttpPost]
    public async Task<ActionResult> AgregarEliminarUsuario(SucursalUsuario sucursalUsuario)
    {
        const string ENCARGADOSPARTIALVIEW = "~/Views/Sucursal/_Encargados.cshtml";
        var (falloEjecucionUsuarios, usuarios) = await ObtenerUsuariosAsync();
        if (falloEjecucionUsuarios)
        {
            TempData[ERRORMESSAGEPARTIAL] = "No se pudo procesar la solicitud";
            return PartialView(ENCARGADOSPARTIALVIEW, sucursalUsuario);
        }

        if (sucursalUsuario.Accion == 'A')
        {
            var libreAsignacion = await cliente.ConsumirAPIAsync<bool>(Constantes.GET, string.Format(Constantes.LIBREASIGNACIONSUCURSAL, sucursalUsuario.IdUsuario, sucursalUsuario.Sucursal.Id));
            if(cliente.Error || !libreAsignacion)
            {
                sucursalUsuario.Usuarios = CargarUsuariosDisponibles(usuarios, sucursalUsuario);
                TempData[ERRORMESSAGEPARTIAL] = cliente.Error ? cliente.MensajeError : "El usuario indicado ya fue asignado como encargado en otra sucursal";

                return PartialView(ENCARGADOSPARTIALVIEW, sucursalUsuario);
            }

            var usuarioSeleccionado = usuarios.Single(m => m.Id == sucursalUsuario.IdUsuario);
            var usuarioSucursal = new UsuarioSucursalRequestDto
            {
                IdUsuario = usuarioSeleccionado.Id,
                Usuario = usuarioSeleccionado
            };

            sucursalUsuario.AgregarUsuario(usuarioSucursal);
        }

        if (sucursalUsuario.Accion == 'R') sucursalUsuario.EliminarUsuario();

        sucursalUsuario.Usuarios = CargarUsuariosDisponibles(usuarios, sucursalUsuario);

        var mensajeSalida = sucursalUsuario.Accion == 'A' ? "agregado" : "eliminado";
        TempData[SUCCESSMESSAGEPARTIAL] = $"Usuario {mensajeSalida} de la lista preliminar";

        return PartialView(ENCARGADOSPARTIALVIEW, sucursalUsuario);
    }

    private IEnumerable<UsuarioResponseDto> CargarUsuariosDisponibles(List<UsuarioResponseDto> usuarios, SucursalUsuario sucursalUsuario)
    {
        var usuariosExistentes = usuarios.Where(m => sucursalUsuario.UsuariosSucursal.Exists(x => x.IdUsuario == m.Id)).ToList();
        return usuarios.Except(usuariosExistentes).ToList();
    }

    private List<UsuarioSucursalRequestDto> ObtenerEncargadosExistentes(SucursalResponseDto sucursal)
    {
        var usuariosencargadosExistentes = from a in sucursal.UsuarioSucursals
                                           select new UsuarioSucursalRequestDto
                                           {
                                               IdSucursal = a.IdSucursal,
                                               IdUsuario = a.IdUsuario,
                                               Usuario = a.Usuario
                                           };

        return usuariosencargadosExistentes.ToList();
    }

    private async Task<(bool fallo, SucursalResponseDto)> ObtenerSucursalAsync(byte id)
    {
        var url = string.Format(Constantes.GETSUCURSALBYID, id);
        var sucursalExisting = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursalExisting == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        return (false, sucursalExisting);
    }

    private async Task<(bool fallo, List<UsuarioResponseDto>)> ObtenerUsuariosAsync()
    {
        var url = string.Format(Constantes.GETALLUSUARIOSBYROL, Enum.GetName(typeof(Rol), Rol.MODERADOR));
        var usuarios = await cliente.ConsumirAPIAsync<List<UsuarioResponseDto>>(Constantes.GET, url);
        if (usuarios == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        usuarios.Insert(0, new UsuarioResponseDto() { Id = 0, NombreCompleto = "Seleccione un usuario" });

        return (false, usuarios);
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private void RemoveValuesRequireModel(int arrangeList = 0)
    {
        ModelState.Remove("Sucursal.Id");
        ModelState.Remove("Sucursal.Nombre");
        ModelState.Remove("Sucursal.Distrito");
        ModelState.Remove("Sucursal.Descripcion");
        ModelState.Remove("Sucursal.CorreoElectronico");

        if(arrangeList > 0)
        {
            for (int i = 0; i < arrangeList; i++)
            {
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.Cedula");
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.Genero");
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.Distrito");
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.Contrasenna");
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.CorreoElectronico");
                ModelState.Remove($"UsuariosSucursal[{i}].Usuario.Rol.Tipo");
            }
        }
    }
}