using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Models
{
    public partial class SucursalHorarioBloqueo
    {
        public long Id { get; set; }

        public short IdSucursalHorario { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public bool Activo { get; set; }

        public virtual SucursalHorario IdSucursalHorarioNavigation { get; set; } = null!;
    }
}