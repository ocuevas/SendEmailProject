using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Services
{
    public class SendEmail
    {

        public void SendEmails(string recipient, string subject, string body)
        {
            var builder = new ConfigurationBuilder()
                  .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(config["Smtp:Host"].ToString());

                mail.From = new MailAddress(config["Smtp:Username"].ToString());
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = body;


                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = config["Smtp:Host"].ToString();
                    client.Port = Convert.ToInt32(config["Smtp:Port"]);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(config["Smtp:Username"].ToString(), config["Smtp:Password"].ToString());
                    client.Send(mail);
                }
                Console.WriteLine("Email was send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    
        
    }
}
