using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using miniV1.Models;

namespace miniV1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View(new Contato());
        }
    }
}