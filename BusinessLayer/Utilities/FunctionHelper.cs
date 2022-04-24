using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public static class FunctionHelper
    {
        public static int GetUserIdByEmail(string email)
        {
            using(Context c = new Context())
            {
                return c.Users.Where(x => x.UserMail == email).FirstOrDefault().UserId;
            }
        }
    }
}
