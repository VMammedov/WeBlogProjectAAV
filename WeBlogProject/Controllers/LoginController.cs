using BusinessLayer.Dto;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginDto login)
        {
            Context c = new Context();
            var data = c.Users.FirstOrDefault(x => x.UserMail == login.Email && x.UserPassword == login.Password);
            if(data != null)
            {
                List<Claim> claims = new List<Claim>();
                Claim claim = new Claim(ClaimTypes.Name, login.Email);
                claims.Add(claim);
                var useridentity = new ClaimsIdentity(claims, "user");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Blog");
            }
            else
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
