using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PapeleriaIPN.Models
{
    public class SendEmail
    {
        public static void Send(string Nombre, string Correo, string Mensaje)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("fdzk800@gmail.com", "PAPELERIA IPN", Encoding.UTF8);//Correo de salida
            correo.To.Add("fdzk800@gmail.com"); //Correo destino?
            correo.Subject = "Peticion de contacto"; //Asunto
            correo.Body = String.Format($"<p>Nombre: {Nombre}</p> </br> <p>Correo de destion: {Correo}</p> </br>  <p>Mensaje: {Mensaje}</p>"); //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new NetworkCredential("fdzk800@gmail.com", "kopticx1020$");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            smtp.Dispose();
        }
    }
}
