using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        bool Add(T value);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        bool Remove(T value);
        bool Update(T value);
    }
}
