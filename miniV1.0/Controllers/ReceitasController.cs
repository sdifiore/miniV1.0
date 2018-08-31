using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace miniV1.Controllers
{
    public class ReceitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Mais_receitas()
        {
            return View();
        }
    }
}