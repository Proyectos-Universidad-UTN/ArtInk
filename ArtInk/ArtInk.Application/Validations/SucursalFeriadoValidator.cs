using ArtInk.Infraestructure.Models;
using FluentValidation;

namespace ArtInk.Application.Validations;

public class SucursalFeriadoValidator : AbstractValidator<SucursalFeriado>
{
    public SucursalFeriadoValidator()
    {
        RuleFor(m => m.IdFeriado)
            .NotEmpty().WithMessage("Debe especificar el feriado");

        RuleFor(m => m.IdSucursal)
            .NotEmpty().WithMessage("Debe especificar la sucursal");

        RuleFor(m => m.Ano)
            .GreaterThan((short)DateTime.Now.Year).WithMessage(m => $"Año({m.Ano}) no puede ser menor al actual");
    }
}