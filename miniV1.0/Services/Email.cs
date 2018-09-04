using Microsoft.Extensions.Options;
using miniV1.Core;
using miniV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace miniV1.Services
{
    public class Email : IEmail
    {
        private readonly IOptions<ManuelaIbiEmail> manuelaIbiEmail;

        public Email(IOptions<ManuelaIbiEmail> manuelaIbiEmail)
        {
            this.manuelaIbiEmail = manuelaIbiEmail;
        }

        public async Task SendAsync(Contato contato)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.sendgrid.net",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(manuelaIbiEmail.Value.Username, manuelaIbiEmail.Value.Password)
            };

            string corpo = contato.Comentario + "\n\r Telefone: " + contato.Telefone;

            using (var message = new MailMessage(contato.Email, "difiores@outlook.com")
            {
                Subject = "Email de Manuela Ibi Nutrição Integrada",
                Body = corpo
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
