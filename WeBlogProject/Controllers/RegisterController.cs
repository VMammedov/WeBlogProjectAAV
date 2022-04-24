using BusinessLayer.Concrete;
using BusinessLayer.Dto;
using BusinessLayer.Utilities;
using BusinessLayer.ViewModels;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new UserRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            EntityLayer.Concrete.User user = new EntityLayer.Concrete.User
            {
                UserNickName = registerDto.UserNickName,
                UserName = registerDto.UserName,
                UserSurName = registerDto.UserSurName,
                UserMail = registerDto.UserMail,
                UserPassword = registerDto.UserPassword1,
                UserStatus = false
            };
            um.Add(user);

            Random random = new Random();
            int number = random.Next(100000, 999999);
            SecurityCodeViewModel data = new SecurityCodeViewModel
            {
                Email = registerDto.UserMail,
                Number = number
            };

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Vusal Mammadli", "xxmixx25@gmail.com"));
            message.To.Add(new MailboxAddress("WeBlogUser", registerDto.UserMail));
            message.Subject = "Verify Your Account!";
            StreamReader reader = new StreamReader(@"./wwwroot/EmailTemp.html");
            string tmp = await reader.ReadToEndAsync();
            message.Body = new TextPart("html")
            {
                Text = tmp.Replace("000000", number.ToString())
            };

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("xxmixx25@gmail.com", "vusalavtos");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
            TempData["email"] = registerDto.UserMail;
            return RedirectToAction("VerifyPage", data);
        }

        public IActionResult VerifyPage(SecurityCodeViewModel securityCode)
        {
            return View(securityCode);
        }

        [HttpPost]
        public IActionResult ActivateUser(SecurityCodeViewModel securityCode)
        {
            bool stat = true;
            int i = 0;
            List<int> sc = new List<int>() { securityCode.Number1, securityCode.Number2, securityCode.Number3, securityCode.Number4, securityCode.Number5, securityCode.Number6 };

            foreach(var num in securityCode.Number.ToString())
            {
                if (num.ToString() != sc[i].ToString())
                {
                    stat = false;
                    break;
                }
                else
                    i++;
            }

            if (stat)
            {
                int userId = FunctionHelper.GetUserIdByEmail(securityCode.Email);
                User user = um.GetById(userId);
                user.UserStatus = true;
                um.Update(user);
                return View();
            }
            else
            {
                TempData["Error"] = "Invalid Security Code! Please, check code again!";
                return RedirectToAction("VerifyPage", securityCode);
            }
        }
    }
}