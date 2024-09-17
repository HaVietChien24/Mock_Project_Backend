using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public T GetByID(int id, string includeProperties = null)
        {
            IQueryable<T> list = _dbSet;

            if (string.IsNullOrEmpty(includeProperties) == false)
            {
                foreach (var props in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    list = list.Include(props);
                }
            }

            var item = list.FirstOrDefault(item => EF.Property<int>(item, "Id") == id);

            return item;
        }

        public IList<T> GetAll(string includeProperties = null)
        {
            IQueryable<T> list = _dbSet;

            if (string.IsNullOrEmpty(includeProperties) == false)
            {
                foreach (var props in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    list = list.Include(props);
                }
            }

            IList<T> result = list.ToList();

            return result;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
