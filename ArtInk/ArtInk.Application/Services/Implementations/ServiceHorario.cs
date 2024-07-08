using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceHorario(IRepositoryHorario repository, IMapper mapper) : IServiceHorario
{
    public async Task<HorarioDTO> FindByIdAsync(short id)
    {
        var horario = await repository.FindByIdAsync(id);
        if (horario == null) throw new NotFoundException("Horario no encontrada.");

        return mapper.Map<HorarioDTO>(horario);
    }

    public async Task<ICollection<HorarioDTO>> GetHorariosBySucursalAsync(byte idSucursal)
    {
        var list = await repository.GetHorariosBySucursalAsync(idSucursal);
        var collection = mapper.Map<ICollection<HorarioDTO>>(list);

        return collection;
    }

    public async Task<ICollection<HorarioDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<HorarioDTO>>(list);

        return collection;
    }
}