using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad_4_Routing.Models
{
    public class PeliculaViewModel
    {
       public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreReal { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Apariciones> Apariciones { get; set; }
        //public int IdPersonaje { get; set; }
        //public string NombrePersonaje { get; set; }

    }
}
