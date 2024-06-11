﻿using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDetalleFactura
    {
        Task<ICollection<DetalleFactura>> ListAsync();
        Task<DetalleFactura?> FindByIdAsync(int id);

    }
}