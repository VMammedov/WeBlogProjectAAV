using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T:class
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        List<T> GetList();
        T GetById(int id);
    }
}
