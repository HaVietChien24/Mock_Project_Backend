using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;

namespace Mock.Repository.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LivebraryContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(LivebraryContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(int id)
        {
            return _dbSet.FirstOrDefault(item => EF.Property<int>(item, "Id") == id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
