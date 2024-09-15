using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.UserService
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
