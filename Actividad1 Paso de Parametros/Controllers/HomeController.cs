using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad1_Paso_de_Parametros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1_Paso_de_Parametros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
