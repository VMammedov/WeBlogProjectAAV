using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    public class NewsLetterController : Controller
    {
        public IActionResult SubscribeToNewsLetter(string email)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Vusal Mammadli", "xxmixx25@gmail.com"));
            message.To.Add(new MailboxAddress("WeBlogUser", email));
            message.Subject = "Welcome to WeBlog Family!";
            message.Body = new TextPart("plain")
            {
                Text = "Hello, my dear!"
            };
            
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("xxmixx25@gmail.com", "vusalavtos");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
            return RedirectToAction("Index","About");
        }
    }
}
