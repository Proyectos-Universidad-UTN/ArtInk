using ArtInk.Infraestructure.Models;
using FluentValidation;

namespace ArtInk.Application.Validations;

public class SucursalHorarioValidator : AbstractValidator<SucursalHorario>
{
    public SucursalHorarioValidator()
    {
        RuleFor(m => m.IdHorario)
           .NotEmpty().WithMessage("Debe especificar el horario");

        RuleFor(m => m.IdSucursal)
            .NotEmpty().WithMessage("Debe especificar la sucursal");
    }
}
