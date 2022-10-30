using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepo<T> where T :class
    {
        bool Delete(T entity);
        bool Update(T entity);
        IEnumerable<T> GetList ();
        T GetById(int id);

    }
}
