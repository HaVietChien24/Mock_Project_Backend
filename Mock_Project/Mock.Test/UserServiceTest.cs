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

        [Test]
        public void GetAllUser_ReturnAllUserList()
        {
            var allUserList = _userService.GetAll();
            Assert.That(allUserList.Count(), Is.EqualTo(SeedData.SeedUser().Count()));
        }

        [Test]
        public void GetUserByID_ReturnOneUser()
        {
            var user = _userService.GetByID(1);
            Assert.IsNotNull(user);
        }

        [Test]
        public void CreateToken_NewTokenCreated()
        {
            string token = _userService.CreateToken(SeedData.SeedUser().First());
            Assert.IsNotNull(token);
        }

        [Test]
        public void GetUserByID()
        {
            var user = _userService.GetByID(1);
            Assert.IsNotNull(user);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
