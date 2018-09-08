using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniV1.Core;
using miniV1.Models;
using System;
using System.Net.Mail;
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
            if (HttpContext.Request.Cookies["EmailEnviado"] == "true")
                ViewBag.Message = "<div class='alert alert-success' role='alert'>Mensagem enviada com sucesso!</div>";
            else
                ViewBag.Message = "";

            return View(new Contato());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "<div class='alert alert-danger' role='alert'>Os campos Nome, E-mail e Contato são obrigatórios</div>";

                return View(new Contato());
            }

            if (!IsValidEmail(contato.Email))
            {
                ViewBag.Message = "<div class='alert alert-danger' role='alert'>Forneça um endereço válido para o e-mail</div>";

                return View(new Contato());
            }

            try
            {
                await email.SendAsync(contato);
            }
            catch
            {
                ViewBag.Message = "<div class='alert alert-danger' role='alert'>Ocorreu um erro desconhecido. Tente novamente</div>";

                return View(new Contato());
            }

            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(30);
            Response.Cookies.Append("EmailEnviado", "true", option);
            var boh = Request.Cookies["EmailEnviado"];

            return RedirectToAction("Contact");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}