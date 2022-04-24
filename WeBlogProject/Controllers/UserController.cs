using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ViewModels;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeBlogProject.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new UserRepository());

        public IActionResult EditProfile()
        {
            string email = User.Identity.Name;
            int id = FunctionHelper.GetUserIdByEmail(email);
            User user = um.GetById(id);
            EditProfileViewModel editProfile = new EditProfileViewModel
            {
                UserNickName = user.UserNickName,
                UserImage = user.UserImage,
                UserMail = user.UserMail,
                UserName = user.UserName,
                UserSurName = user.UserSurName
            };
            return View(editProfile);
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editUser)
        {
            string email = User.Identity.Name;
            int id = FunctionHelper.GetUserIdByEmail(email);
            User user = um.GetById(id);
            user.UserName = editUser.UserName;
            user.UserNickName = editUser.UserNickName;
            user.UserSurName = editUser.UserSurName;
            user.UserMail = editUser.UserMail;
            user.UserImage = editUser.UserImage;
            um.Update(user);
            return RedirectToAction("Index","Blog");
        }
    }
}