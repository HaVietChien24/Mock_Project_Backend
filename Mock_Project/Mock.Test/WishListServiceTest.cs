using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.WishListService;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Test
{
    public class WishListServiceTest
    {
        private LivebraryContext _context;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private WishListService _wishListService;
        [SetUp]
        public void SetUp()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            this._mapper = mappingConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<LivebraryContext>()
              .UseInMemoryDatabase(databaseName: "TestDb")
              .Options;

            _context = new LivebraryContext(options);
            _unitOfWork = new UnitOfWork(this._context, null);
            _wishListService = new WishListService(_unitOfWork, _mapper);

            _context.Books.Add(new Book
            {
                Id = 1,
                Title = "The Cat",
                Description = "book description",
                Author = "Martin King",
                Publisher = "John Bidden",
                PublishedYear = 2010,
                ISBN = "23942305",
                Amount = 20
            });

            _context.WishLists.Add(new WishList
            {
                Id = 1,
                UserId = 1,
                TotalQuantity = 4
            });
            _context.WishListDetails.Add(
                new WishListDetails
                {
                    Id = 1,
                    WishListId = 1,
                    BookId = 1,
                    Quantity = 4
                }
                );
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            this._context.Dispose();
        }

        [Test]
        public void GetDTOByUserId_UserIdExist_ReturnWishlistDTO()
        {
            var result = _wishListService.GetDTOByUserId(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("The Cat", result.WishListDetails[0].BookTitle);
        }

        [Test]
        public void GetDTOByUserId_UserIdNotExist_ReturnNull()
        {
            var result = _wishListService.GetDTOByUserId(0);
            Assert.IsNull(result);
        }

        [Test]
        public void AddBookToWishlist_BookIdExist_AddSuccess()
        {
            var result = _wishListService.AddBookToWishlist(1, 1);
            Assert.That(result.Equals(1));
        }


        [Test]
        public void UpdateDetailQuantity_WishlistDetailExist_UpdateSuccess()
        {
            var result = _wishListService.UpdateDetailQuantity(1, 6);
            var wishList = _wishListService.GetDTOByUserId(1);
            Assert.That(result.Equals(1));
            Assert.That(wishList.TotalQuantity.Equals(6));
        }

        [Test]
        public void UpdateDetailQuantity_WishlistDetailNotExist_UpdateFail()
        {
            var ex = Assert.Throws<Exception>(() => _wishListService.UpdateDetailQuantity(0, 6));
            Assert.That(ex.Message, Is.EqualTo("Not Found"));
        }

        [Test]
        public void DeleteWishlistDetail_WishlistDetailExist_DeleteSuccess()
        {
            var result = _wishListService.DeleteWishlistDetail(1);
            var wishList = _wishListService.GetDTOByUserId(1);
            Assert.That(result.Equals(1));
            Assert.That(wishList.TotalQuantity.Equals(0));
        }

        [Test]
        public void DeleteWishlistDetail_WishlistDetailNotExist_DeleteFail()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _wishListService.DeleteWishlistDetail(0));
        }
    }
}
