using ArtInk.Infraestructure.Models;
using FluentValidation;

namespace ArtInk.Application.Validations
{
    public class SucursalHararioBloqueoValidator : AbstractValidator<SucursalHorarioBloqueo>
    {
        public SucursalHararioBloqueoValidator() 
        {
            RuleFor(m => m.IdSucursalHorario)
                    .NotEmpty().WithMessage("Debe especificar el horario de la sucursal");

            RuleFor(m => m.Fecha)
                .NotEmpty().WithMessage("Debe especificar la fecha")
                .WithMessage("La fecha debe ser válida");

            RuleFor(x => x.HoraInicio)
            .NotEmpty().WithMessage("La hora de inicio es requerida")
            .NotNull().WithMessage("La hora de inicio no puede ser nula");

            RuleFor(x => x.HoraFin)
                .NotEmpty().WithMessage("La hora de fin es requerida")
                .NotNull().WithMessage("La hora de fin no puede ser nula")
                .GreaterThan(x => x.HoraInicio)
                .WithMessage("La hora de fin debe ser mayor que la hora de inicio");
        }
    }
}
