using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PapeleriaIPN.Models
{
    public class EnviarCorreos
    {
        private int numAccseso;

        public void EnviarCorreo(string email)
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("fdzk800@gmail.com", "POLIVAC", Encoding.UTF8);//Correo de salida
            correo.To.Add(email); //Correo destino?
            correo.Subject = "Recuperacion de contraseña"; //Asunto
            GenerarNumero();
            correo.Body = String.Format($"Codigo de recuperacion\n {numAccseso}"); //Mensaje del correo
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

        public void GenerarNumero()
        {
            Random random = new Random();
            numAccseso = random.Next(100000, 999999);
        }
    }
}
