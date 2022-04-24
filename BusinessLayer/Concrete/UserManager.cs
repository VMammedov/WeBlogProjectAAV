using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User obj)
        {
            _userDal.Add(obj);
        }

        public void Delete(User obj)
        {
            obj.UserStatus = false;
            _userDal.Update(obj);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public void Update(User obj)
        {
            _userDal.Update(obj);
        }
    }
}
