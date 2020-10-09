using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad1_Paso_de_Parametros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1_Paso_de_Parametros.Controllers
{
    public class NumerosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sumar(Numeros n)
        {
            return View(n);
        }
        public IActionResult Resultado(Numeros n)
        {
            int resultado = n.Num1 + n.Num2;
            return View(resultado);
        }
    }
}
