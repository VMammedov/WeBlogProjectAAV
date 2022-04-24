using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
            return View();
        }
    }
}
