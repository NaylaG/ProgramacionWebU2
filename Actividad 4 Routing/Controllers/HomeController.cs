using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Actividad_4_Routing.Models;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Actividad_4_Routing.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Inicio = "selected";
            return View();
        }
        //PELICULAS
        [Route("Peliculas")]
        public IActionResult Peliculas()
        {
            pixarContext contexto = new pixarContext();
            ViewBag.Peliculas = "selected";
            //ViewBag.Nombre = "Peliculas";
            var peliculas = contexto.Pelicula.OrderBy(x => x.Nombre);

            if (peliculas==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(peliculas);
                
            }
           
        }

        [Route("Peliculas/{id}")]
        public IActionResult InformacionPelicula(string id)
        {
            pixarContext contexto = new pixarContext();
            var nombre = id.Replace("_", " ").ToLower();//para saber cual nombre se la pelicula es

            var pelicula = contexto.Pelicula.Include(x=>x.Apariciones).
                FirstOrDefault(x => x.Nombre.ToLower() == nombre);//sacar la pelicula

            var apariciones = contexto.Apariciones.Include(x => x.IdPeliculaNavigation)
                .Include(x => x.IdPersonajeNavigation).Where(x=>x.IdPelicula==pelicula.Id);
            ViewBag.Peliculas = "selected";
                
            if (pelicula==null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                PeliculaViewModel pvm = new PeliculaViewModel();
                pvm.Id = pelicula.Id;
                pvm.Nombre = pelicula.Nombre;
                pvm.NombreReal = pelicula.NombreOriginal;
                pvm.FechaEstreno = pelicula.FechaEstreno;
                pvm.Descripcion = pelicula.Descripción;

                pvm.Apariciones = apariciones;
  
                return View(pvm);
            }
        }

        //CORTOMETRAJES
        [Route("Cortometrajes")]
        public IActionResult Cortos()
        {
            pixarContext contexto = new pixarContext();
            CortoViewModel cvm = new CortoViewModel();
            cvm.Categorias = contexto.Categoria.Include(x => x.Cortometraje).OrderBy(x => x.Nombre);
            
            ViewBag.Cortos = "selected";
            if (cvm.Categorias==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cvm);
                
              
            }
           
            
        }



        [Route("Cortometrajes/{id}")]
        public IActionResult InformacionCortos(string id)
        {
            pixarContext contexto = new pixarContext();
            var nombre = id.Replace("_"," ").ToLower();
            var corto = contexto.Cortometraje.FirstOrDefault(x => x.Nombre.ToLower() == nombre);
            ViewBag.Cortos = "selected";
            if (corto==null)
            {
                return RedirectToAction("Cortos");
            }
            else
            {
                return View(corto);
            }
        }
    }
}
