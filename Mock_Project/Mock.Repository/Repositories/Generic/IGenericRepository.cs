
namespace Mock.Repository.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByID(int id, string includeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll(string includeProperties = null);
    }
}
