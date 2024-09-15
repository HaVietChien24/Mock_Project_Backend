using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.UserService
{
    public interface IUserService : IBaseService<User>
    {
        void Login();
        void Register();
    }
}
