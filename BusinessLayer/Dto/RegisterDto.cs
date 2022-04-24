using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class RegisterDto
    {
        public string UserNickName { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword1 { get; set; }
        public string UserPassword2 { get; set; }
    }
}
