using Microsoft.Extensions.Configuration;
using Services;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new SendEmail();

            Console.WriteLine("Recipients: ");
            string recipients = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Subject: ");
            string subject = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Body: ");
            string body = Convert.ToString(Console.ReadLine());


            services.SendEmails(recipients, subject, body);
            
            
        }
    }
}
