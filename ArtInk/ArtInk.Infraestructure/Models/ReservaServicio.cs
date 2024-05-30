using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class ReservaServicio
{
    [Key]
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public byte IdServicio { get; set; }

    [ForeignKey("IdReserva")]
    [InverseProperty("ReservaServicio")]
    public virtual Reserva IdReservaNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("ReservaServicio")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
