using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace PapeleriaIPN.Models
{
    public class SendEmail
    {
        private readonly IConfiguration configuration;

        public SendEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Contacto(string Nombre, string Correo, string Mensaje)
        {
            MimeMessage message = new();
            message.From.Add(new MailboxAddress("Papeleria IPN", configuration["gmailAcount:GmailUser"]));
            message.To.Add(new MailboxAddress("Destino", configuration["gmailAcount:GmailUser"]));
            message.Subject = "Peticion de contacto";

            BodyBuilder cuerpo = new();

            cuerpo.HtmlBody = String.Format($"<p>Nombre: {Nombre}</p> </br> <p>Correo de destion: {Correo}</p> </br>  <p>Mensaje: {Mensaje}</p>");

            message.Body = cuerpo.ToMessageBody();

            SmtpClient client = new();
            client.CheckCertificateRevocation = false;
            client.Connect(configuration["gmailAcount:Servidor"], Int32.Parse(configuration["gmailAcount:Puerto"]), MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(configuration["gmailAcount:GmailUser"], configuration["gmailAcount:GmailPassword"]);
            client.Send(message);
            client.Disconnect(true);
        }

        public void RecuperarContraseña(string Correo)
        {
            MimeMessage message = new();
            message.From.Add(new MailboxAddress("Papeleria IPN", configuration["gmailAcount:GmailUser"]));
            message.To.Add(new MailboxAddress("Destino", Correo));
            message.Subject = "Codigo de recuperacion";

            BodyBuilder cuerpo = new();

            cuerpo.HtmlBody = String.Format($"<p>Codigo: {GenerarNumero()}</p> </br> <p>: No compartas este codigo con nadie</p>");

            message.Body = cuerpo.ToMessageBody();

            SmtpClient client = new();
            client.CheckCertificateRevocation = false;
            client.Connect(configuration["gmailAcount:Servidor"], Int32.Parse(configuration["gmailAcount:Puerto"]), MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(configuration["gmailAcount:GmailUser"], configuration["gmailAcount:GmailPassword"]);
            client.Send(message);
            client.Disconnect(true);
        }

        public int GenerarNumero()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
