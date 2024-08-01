using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServicePedido(IRepositoryPedido repository, IMapper mapper, IValidator<Pedido> pedidoValidator) : IServicePedido
{
    public async Task<PedidoDto> CreatePedidoAsync(RequestPedidoDto pedidoDto)
    {
        var pedido = await ValidarPedido(pedidoDto);
        pedido.IdUsuarioSucursal = 1;

        var result = await repository.CreatePedidoAsync(pedido);
        if (result == null) throw new NotFoundException("Pedido no creado.");

        return mapper.Map<PedidoDto>(result);
    }

    public async Task<PedidoDto> FindByIdAsync(long id)
    {
        var pedido = await repository.FindByIdAsync(id);
        if (pedido == null) throw new NotFoundException("Proforma no creada.");

        return mapper.Map<PedidoDto>(pedido);
    }

    public async Task<ICollection<PedidoDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<PedidoDto>>(list);

        return collection;
    }

    private async Task<Pedido> ValidarPedido(RequestPedidoDto pedidoDto)
    {
        var pedido = mapper.Map<Pedido>(pedidoDto);
        await pedidoValidator.ValidateAndThrowAsync(pedido);
        return pedido;
    }
}