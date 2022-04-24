using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new ContactRepository());

        public IActionResult Index()
        {
            TempData["Success"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            cm.Add(contact);
            TempData["Success"] = "Your message has sended successfully!";
            return View("Index");
        }
    }
}
