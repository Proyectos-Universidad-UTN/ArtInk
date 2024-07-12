using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceSucursalFeriado(IRepositorySucursalFeriado repository, IMapper mapper, 
                                    IValidator<SucursalFeriado> sucursalFeriadoValidator) : IServiceSucursalFeriado
{
    public async Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<RequestSucursalFeriadoDto> sucursalFeriados)
    {
        var feriados = await ValidateFeriados(idSucursal, sucursalFeriados);

        var result = await repository.CreateSucursalFeriadosAsync(idSucursal, feriados);
        if (!result) throw new ListNotAddedException("Error al guardar feriados");

        return result;
    }

    public async Task<ICollection<SucursalFeriadoDto>> GetFeriadosBySucursalAsync(byte idSucursal, short? anno)
    {
        var list = anno == null ? await repository.GetFeriadosBySucursalAsync(idSucursal) :
                                await repository.GetFeriadosBySucursalAsync(idSucursal, anno.Value);
        var collection = mapper.Map<ICollection<SucursalFeriadoDto>>(list);

        return collection;
    }

    public async Task<SucursalFeriadoDto?> GetSucursalFeriadoByIdAsync(short id)
    {
        var sucursalFeriado = await repository.GetSucursalFeriadoByIdAsync(id);
        if (sucursalFeriado == null) throw new NotFoundException("Feriado en sucursal no encontrado.");

        return mapper.Map<SucursalFeriadoDto>(sucursalFeriado);
    }

    private async Task<IEnumerable<SucursalFeriado>> ValidateFeriados(byte idSucursal, IEnumerable<RequestSucursalFeriadoDto> sucursalFeriados)
    {
        var feriados = mapper.Map<List<SucursalFeriado>>(sucursalFeriados);
        foreach (var item in feriados)
        {
            item.IdSucursal = idSucursal;
            await sucursalFeriadoValidator.ValidateAndThrowAsync(item);
        }
        return feriados;
    }
}