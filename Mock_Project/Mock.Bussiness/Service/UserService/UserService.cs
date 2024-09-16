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

        public bool CheckPasswordCorrect(string inputPassword, string hashedPassword)
        {
            return _unitOfWork.UserRepository.CheckPasswordCorrect(inputPassword, hashedPassword);
        }

        public User GetByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            
            return _unitOfWork.UserRepository.GetByUsername(username);
        }

        public string HashPassword(string passwordToHash)
        {
            if (passwordToHash == null)
            {
                throw new ArgumentNullException("Password to hash cannot be null");
            }

            return _unitOfWork.UserRepository.HashPassword(passwordToHash);
        }

        public string CreateToken(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            return _unitOfWork.UserRepository.CreateToken(user);
        }
    }
}
