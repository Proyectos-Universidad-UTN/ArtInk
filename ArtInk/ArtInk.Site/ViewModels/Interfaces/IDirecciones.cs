using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Site.ViewModels.Interfaces;

public interface IDirecciones
{
    public byte IdProvincia { get; set; }

    public byte IdCanton { get; set; }

    public short IdDistrito { get; set; }
}