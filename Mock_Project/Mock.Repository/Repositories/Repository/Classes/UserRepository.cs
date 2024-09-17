using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly LivebraryContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(LivebraryContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration; 
        }

        public bool CheckPasswordCorrect(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public string HashPassword(string passwordToHash)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordToHash, salt);

            return hashedPassword;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("username", user.Username), 
                new Claim("imageURL", user.ImageUrl ?? ""),
                new Claim("email", user.Email ?? ""),
                new Claim("phone", user.Phone ?? ""),
                new Claim("isAdmin", user.IsAdmin.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Keys:JWT_Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool BanAccounts(int userId)
        {
            var personalInfor =  _context.Users.Find(userId);
            if (personalInfor == null)
            {
                return false; // Người dùng không tồn tại
            }
            personalInfor.IsActive = !personalInfor.IsActive;
            _context.Update(personalInfor);
            _context.SaveChanges();
            return true;
        }
    }
}
