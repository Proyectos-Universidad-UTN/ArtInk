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
    public async Task<FeriadoDTO> CreateFeriadoAsync(RequestFeriadoDTO feriadoDTO)
    {
        var feriado = await ValidarFeriado(feriadoDTO);

        var result = await repository.CreateFeriadoAsync(feriado);
        if (result == null) throw new NotFoundException("Feriado no creado.");

        return mapper.Map<FeriadoDTO>(result);
    }

    public async Task<bool> DeleteFeriadoAsync(byte id)
    {
        if (!await repository.ExisteFeriadoAsync(id)) throw new NotFoundException("Feriado no encontrada.");
        return await repository.DeleteFeriadoAsync(id);
    }

    public async Task<FeriadoDTO> FindByIdAsync(byte id)
    {
        var feriado = await repository.FindByIdAsync(id);
        if (feriado == null) throw new NotFoundException("Feriado no encontrado.");

        return mapper.Map<FeriadoDTO>(feriado);
    }

    public async Task<ICollection<FeriadoDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<FeriadoDTO>>(list);

        return collection;
    }

    public async Task<FeriadoDTO> UpdateFeriadoAsync(byte id, RequestFeriadoDTO feriadoDTO)
    {
        if (!await repository.ExisteFeriadoAsync(id)) throw new NotFoundException("Feriado no encontrada.");

        var producto = await ValidarFeriado(feriadoDTO);
        producto.Id = id;
        var result = await repository.UpdateFeriadoAsync(producto);

        return mapper.Map<FeriadoDTO>(result);
    }

    private async Task<Feriado> ValidarFeriado(RequestFeriadoDTO feriadoDTO)
    {
        var feriado = mapper.Map<Feriado>(feriadoDTO);
        await feriadoValidator.ValidateAndThrowAsync(feriado);
        return feriado;
    }
}