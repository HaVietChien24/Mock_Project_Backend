

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
                throw new ArgumentNullException("Null entitly isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Add(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null entitly isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Delete(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }

        public T GetByID(int id)
        {
            return _unitOfWork.GenericRepository<T>().GetByID(id);
        }

        public IList<T> GetAll()
        {
            return _unitOfWork.GenericRepository<T>().GetAll();
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null entitly isn't allowed");
            }

            _unitOfWork.GenericRepository<T>().Update(entity);
            int result = _unitOfWork.SaveChanges();

            return result;
        }
    }
}
