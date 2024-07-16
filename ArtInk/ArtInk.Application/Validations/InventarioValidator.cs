using ArtInk.Infraestructure.Models;
using FluentValidation;

namespace ArtInk.Application.Validations;

public class InventarioValidator: AbstractValidator<Inventario>
{
    public InventarioValidator()
    {
    }
}