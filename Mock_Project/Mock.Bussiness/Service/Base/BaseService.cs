

using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null entity isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Add(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null entity isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Delete(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }

        public T GetByID(int id, string includeProperties = null)
        {
            return _unitOfWork.GenericRepository<T>().GetByID(id, includeProperties);
        }

        public IList<T> GetAll(string includeProperties = null)
        {
            return _unitOfWork.GenericRepository<T>().GetAll(includeProperties);
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null entity isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Update(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }
    }
}
