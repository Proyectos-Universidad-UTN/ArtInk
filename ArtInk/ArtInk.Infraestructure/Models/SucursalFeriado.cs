using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Models
{
    [Table(name: "SucursalFeriado")]
    public partial class SucursalFeriado
    {
        [Key]
        public short Id { get; set; }

        public byte IdFeriado { get; set; }

        public byte IdSucursal { get; set; }

        public DateOnly Fecha { get; set; }

        public short Anno { get; set; }

        public virtual Feriado IdFeriadoNavigation { get; set; } = null!;

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    }
}
