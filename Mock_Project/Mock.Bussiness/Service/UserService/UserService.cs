using AutoMapper;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.UserService
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public List<UserDTO> GetAllUser()
        {

            var query = _unitOfWork.UserRepository.GetAllUsers().AsQueryable();
            List<UserDTO> userDTOList = _mapper.Map<List<UserDTO>>(query);

            return userDTOList;

        }

        public bool BanAccount(int userId)
        {
            var query = _unitOfWork.UserRepository.BanAccounts(userId);

            return query;
        }
    }
}
