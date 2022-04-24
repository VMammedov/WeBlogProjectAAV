using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserNickName { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserImage { get; set; }
        public bool UserStatus { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
