using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace TobaccoStore.Web
{
    public class MailService
    {
        private const string SENDER_EMAIL = @"optobacco@gmail.com";
        private const string SENDER_EMAIL_PASSWORD = @"chavel4130";
        public void SendEmail(string subject, 
            string body,
            string sender,
            string receipient)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(SENDER_EMAIL);
            mail.To.Add(receipient);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(SENDER_EMAIL, SENDER_EMAIL_PASSWORD);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}