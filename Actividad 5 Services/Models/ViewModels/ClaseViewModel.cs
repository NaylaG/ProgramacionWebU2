using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad_5_Services.Models.ViewModels
{
    public class ClaseViewModel
    {
        public string NombreClasificacion { get; set; }
        public IEnumerable<Especies> Especies { get; set; }

    }
}
