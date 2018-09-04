using Microsoft.AspNetCore.Mvc;
using miniV1.Core;
using miniV1.Models;
using System.Threading.Tasks;

namespace miniV1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmail email;

        public ContactController(IEmail email)
        {
            this.email = email;
        }

        public IActionResult Contact()
        {
            if (ViewData["EmailEnviado"] == null)
                ViewData["EmailEnviado"] = "false";

            return View(new Contato());
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contato contato)
        {
            await email.SendAsync(contato);

            ViewData["EmailEnviado"] = true;

            return RedirectToAction("Contact");
        }
    }
}