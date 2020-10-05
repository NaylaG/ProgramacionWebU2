using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Actividad_5_Services.Models;
using Actividad_5_Services.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Actividad_5_Services.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();
            var clasificaciones = context.Clase.OrderBy(x => x.Nombre);
            Random num = new Random();            
            ViewBag.Numero = num.Next(1, 6);

            return View(clasificaciones);
        }

        [Route("Clasificacion/{id}")]
        public IActionResult Clasificacion( string id)
        {
            animalesContext context = new animalesContext();
            var clasificacion = context.Clase.FirstOrDefault(x => x.Nombre.ToUpper() == id.ToUpper());
            var especies = context.Especies.Where(x => x.IdClaseNavigation.Nombre.ToUpper() == id.ToUpper()).OrderBy(x=>x.Especie);

            if(clasificacion==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ClaseViewModel vm = new ClaseViewModel();
                vm.NombreClasificacion = clasificacion.Nombre;
                vm.Especies = especies;
                return View(vm);
            }

            
        }
    }
}
