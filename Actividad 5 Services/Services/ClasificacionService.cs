using Actividad_5_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Actividad_5_Services.Services
{
    public class ClasificacionService
    {
        public List<Clase> Clasificacion { get; set; }

        public ClasificacionService()
        {
            using (animalesContext context = new animalesContext())
            {
                Clasificacion = context.Clase.OrderBy(x => x.Nombre).ToList();
            }
        }


    }
}
