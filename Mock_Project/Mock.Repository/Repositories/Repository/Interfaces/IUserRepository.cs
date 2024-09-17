using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);
        public List<User> GetAllUsers();

        string HashPassword(string passwordToHash);
        bool CheckPasswordCorrect(string inputPassword, string hashedPassword);
        string CreateToken(User user);

        // Thêm hàm BanAccount
        bool BanAccounts(int userId);
    }
}
