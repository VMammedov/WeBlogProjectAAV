using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class EditProfileViewModel
    {
        public string UserNickName { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserImage { get; set; }
    }
}
