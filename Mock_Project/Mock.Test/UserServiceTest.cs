using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.UserService;
using Mock.Core.Data;
using Mock.Repository.UnitOfWork;
using Moq;
using System.Xml.Linq;

namespace Mock.Test
{
    public class UserServiceTest
    {
        private LivebraryContext _context;
        private IUnitOfWork _unitOfWork;
        private IUserService _userService;
        private IConfiguration _configuration; // I need to inject this 
        private IMapper _mapper;

        public UserServiceTest()
        {
            
        }


        [SetUp]
        public void SetUp()
        {
            var option = new DbContextOptionsBuilder<LivebraryContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            _context = new LivebraryContext(option);

            if (_context.Database.EnsureCreated() && _context.Users.ToList().Count() == 0)
            {
                _context.Users.AddRange(SeedData.SeedUser());
                _context.SaveChanges();
            }

            var services = new ServiceCollection();

            // Create a mock configuration
            var mockConfiguration = new Mock<IConfiguration>();

            // Setup key-value pairs for the configuration
            mockConfiguration.Setup(config => config["Keys:JWT_Key"])
                .Returns("ma55qDYSJ65BEZpZBZZ6fzutTiMxzFdVLtq8PSRP13vratVbxGrEVSkdb7kiwTc0");

            // Assign the mock object to your private field
            _configuration = mockConfiguration.Object;

            services.AddAutoMapper(typeof(MappingProfile));

            var serviceProvider = services.BuildServiceProvider();

            // _configuration = serviceProvider.GetService<IConfiguration>()!;
            _mapper = serviceProvider.GetService<IMapper>()!;

            _unitOfWork = new UnitOfWork(_context, _configuration);
            _userService = new UserService(_unitOfWork, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }




        [Test]
        public void GetAllUser_ReturnAllUserList()
        {
            var allUserList = _userService.GetAll();
            Assert.That(allUserList.Count(), Is.EqualTo(SeedData.SeedUser().Count()));
        }

        [Test]
        public void CheckPassword_PasswordCorrect()
        {
            var userToCheckPassword = _userService.GetByID(1);

            var checkPassword = _userService.CheckPasswordCorrect("Ncs@14082011", userToCheckPassword.Password);
            Assert.That(checkPassword, Is.EqualTo(true));
        }

        [Test]
        public void CheckPassword_PasswordIncorrect()
        {
            var userToCheckPassword = _userService.GetByID(1);

            var checkPassword = _userService.CheckPasswordCorrect("Monstercat@2k11", userToCheckPassword.Password);
            Assert.That(checkPassword, Is.EqualTo(false));
        }

        [Test]
        public void HashPassword_PasswordHashed()
        {
            var hashedPassword = _userService.HashPassword("Ncs@14082011");

            Assert.NotNull(hashedPassword);
        }

        [Test]
        public void GetUserByID_ReturnOneUser()
        {
            var user = _userService.GetByID(1);
            Assert.IsNotNull(user);
        }

        [Test]
        public void GetUserByID_ReturnNull()
        {
            var user = _userService.GetByID(66);
            Assert.IsNull(user);
        }

        [Test]
        public void CreateToken_NewTokenCreated()
        {
            string token = _userService.CreateToken(SeedData.SeedUser().First());
            Assert.IsNotNull(token);
        }

        [Test]
        public void GetUserByUsername_ReturnOneUser()
        {
            var user = _userService.GetByUsername("josh_miller");
            Assert.IsNotNull(user);
        }

        [Test]
        public void GetUserByUsername_ReturnNull()
        {
            var user = _userService.GetByUsername("abc");
            Assert.IsNull(user);
        }

        [Test]
        public void BacAccount_AccountBanned()
        {
            _userService.BanAccount(1);

            var bannedUser = _userService.GetByID(1);
            Assert.That(bannedUser.IsActive, Is.EqualTo(false));
        }

        [Test]
        public void GetAllUserByDTO_ReturnAllUserDTOList()
        {
            var allUserList = _userService.GetAllUser();
            Assert.That(allUserList.Count(), Is.EqualTo(SeedData.SeedUser().Count()));
        }
    }
}
