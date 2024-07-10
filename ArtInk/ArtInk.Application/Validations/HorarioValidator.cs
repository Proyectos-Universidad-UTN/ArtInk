﻿using ArtInk.Infraestructure.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Validations;

public class HorarioValidator : AbstractValidator<Horario>
{
    public HorarioValidator() 
    {
        RuleFor(x => x.Dia)
            .IsInEnum();

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
