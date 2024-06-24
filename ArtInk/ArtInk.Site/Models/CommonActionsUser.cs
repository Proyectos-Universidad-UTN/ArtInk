using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Site.Models
{
    public class CommonActionsUser
    {
        public object Id { get; set; } = default!;

        public bool Editar { get; set; }

        public bool Detalles { get; set; }

        public bool Eliminar { get; set; }
    }
}