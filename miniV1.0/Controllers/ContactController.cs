using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using miniV1.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace miniV1.Controllers
{
    public class ContactController : Controller
    {
        private readonly ManuelaIbiEmail manuelaIbiEmail;

        public ContactController(IOptions<ManuelaIbiEmail> manuelaIbiEmail)
        {
            this.manuelaIbiEmail.Username = manuelaIbiEmail.Value.Username;
            this.manuelaIbiEmail.Password = manuelaIbiEmail.Value.Password;
        }

        public IActionResult Contact()
        {
            return View(new Contato());
        }
    
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contato contato)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.sendgrid.net",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(manuelaIbiEmail.Username, manuelaIbiEmail.Password)
            };

            using (var message = new MailMessage(contato.Email, "manuelaibi66@gmail.com")
            {
                Subject = "Email de Manuela Ibi Nutrição Integrada",
                Body = $"{contato.Comentario}\nTelefone: {contato.Telefone}"
            })
            {
                await smtpClient.SendMailAsync(message);
            }

            return Ok();
        }
    }
}