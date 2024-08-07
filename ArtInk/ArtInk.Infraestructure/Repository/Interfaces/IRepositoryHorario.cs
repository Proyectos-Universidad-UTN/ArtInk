﻿using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryHorario
{
    Task<Horario> CreateHorarioAsync(Horario horario);

    Task<Horario> UpdateHorarioAsync(Horario horario);

    Task<ICollection<Horario>> ListAsync();

    Task<Horario?> FindByIdAsync(short id);

    Task<bool> ExisteHorario(short id);
}