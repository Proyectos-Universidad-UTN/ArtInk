using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.Validations;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceFeriado(IRepositoryFeriado repository, IMapper mapper,
                            IValidator<Feriado> feriadoValidator) : IServiceFeriado
{
    public async Task<FeriadoDto> CreateFeriadoAsync(RequestFeriadoDto feriadoDTO)
    {
        var feriado = await ValidarFeriado(feriadoDTO);

        var result = await repository.CreateFeriadoAsync(feriado);
        if (result == null) throw new NotFoundException("Feriado no creado.");

        return mapper.Map<FeriadoDto>(result);
    }

    public async Task<bool> DeleteFeriadoAsync(byte id)
    {
        if (!await repository.ExisteFeriadoAsync(id)) throw new NotFoundException("Feriado no encontrada.");
        return await repository.DeleteFeriadoAsync(id);
    }

    public async Task<FeriadoDto> FindByIdAsync(byte id)
    {
        var feriado = await repository.FindByIdAsync(id);
        if (feriado == null) throw new NotFoundException("Feriado no encontrado.");

        return mapper.Map<FeriadoDto>(feriado);
    }

    public async Task<ICollection<FeriadoDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<FeriadoDto>>(list);

        return collection;
    }

    public async Task<FeriadoDto> UpdateFeriadoAsync(byte id, RequestFeriadoDto feriadoDTO)
    {
        if (!await repository.ExisteFeriadoAsync(id)) throw new NotFoundException("Feriado no encontrada.");

        var producto = await ValidarFeriado(feriadoDTO);
        producto.Id = id;
        var result = await repository.UpdateFeriadoAsync(producto);

        return mapper.Map<FeriadoDto>(result);
    }

    private async Task<Feriado> ValidarFeriado(RequestFeriadoDto feriadoDTO)
    {
        var feriado = mapper.Map<Feriado>(feriadoDTO);
        await feriadoValidator.ValidateAndThrowAsync(feriado);
        return feriado;
    }
}