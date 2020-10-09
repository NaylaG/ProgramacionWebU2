using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad_2_Conexion_a_BD.Models;

namespace Actividad_2_Conexion_a_BD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mexicoContext context = new mexicoContext();
            var estados = context.Estados.OrderBy(x => x.Nombre).ToList();

            return View(estados);
        }
    }
}
