using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.UserService
{
    public interface IUserService : IBaseService<User>
    {
        User GetByUsername(string username);
        public List<UserDTO> GetAllUser();
        bool BanAccount(int userId);
        string HashPassword(string passwordToHash);
        bool CheckPasswordCorrect(string inputPassword, string hashedPassword);
        string CreateToken(User user);

    }
}
