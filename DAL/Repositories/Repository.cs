using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Context;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<T>();
        }

        public bool Add(T value)
        {
            _dbSet.Add(value);
            return _dataContext.SaveChanges() > 0;
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToArrayAsync();
        }

        public bool Remove(T value)
        {
            _dbSet.Remove(value);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Update(T value)
        {
            _dataContext.Entry(value).State = EntityState.Modified;
            return _dataContext.SaveChanges() > 0;
        }
    }
}
