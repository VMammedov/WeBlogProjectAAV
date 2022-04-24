using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        public void Add(T obj);
        public void Delete(int id);
        public void Update(T obj);
        public List<T> GetList();
        public T GetById(int id);
    }
}
