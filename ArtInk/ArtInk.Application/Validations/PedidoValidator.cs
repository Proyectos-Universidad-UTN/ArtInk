using ArtInk.Infraestructure.Models;
using FluentValidation;

namespace ArtInk.Application.Validations;

public class PedidoValidator: AbstractValidator<Pedido>
{
    public PedidoValidator()
    {
    }
}