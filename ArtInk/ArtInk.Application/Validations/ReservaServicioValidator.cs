using ArtInk.Infraestructure.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Validations;

public class ReservaServicioValidator : AbstractValidator<ReservaServicio>
{
    public ReservaServicioValidator()
    {
        RuleFor(m => m.IdReserva)
          .NotEmpty().WithMessage("Debe especificar la reserva");

        RuleFor(m => m.IdServicio)
            .NotEmpty().WithMessage("Debe especificar el servicio");
    }
}
