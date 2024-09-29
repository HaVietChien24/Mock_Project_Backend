using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.BorrowingService;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Mock.Test
{
    [TestFixture]
    public class BorrowingServiceTest
    {
        private LivebraryContext _context;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private BorrowingService _service;

        [SetUp]
        public void SetUp()
        {
            
          
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<LivebraryContext>()
                .UseInMemoryDatabase(databaseName: "Test2Db")
                .Options;

            _context = new LivebraryContext(options);
            _unitOfWork = new UnitOfWork(_context, null);
            _service = new BorrowingService(_unitOfWork, _mapper);
            if (_context.Database.EnsureCreated())
            {
                var borrowing = new Borrowing
                {
                    Id = 1,
                    UserId = 1,

                    IsBookPickedUp = true,
                    BorrowingStatus = "Quá hạn",
                    BorrowingDetails = new List<BorrowingDetails>
                {
                    new BorrowingDetails { Id = 1, BorrowingId = 1, Quantity = 3, NumberReturnedBook = 3 }, // Đã trả hết
                    new BorrowingDetails { Id = 2, BorrowingId = 1, Quantity = 2, NumberReturnedBook = 0 }, // Chưa trả
                    new BorrowingDetails { Id = 3, BorrowingId = 1, Quantity = 1, NumberReturnedBook = 1 }  // Trả đủ 1 quyển
                }
                };

                _context.Borrowings.Add(borrowing);
                _context.SaveChanges();

            }

              
        }
        [TearDown]
        public void TearDown()
        {

            _context.Dispose();
           
        }




        [Test]
        public void CheckBorrowingStatus_AllBooksReturned_ReturnsReturned()
        {
            
            var borrowingId = 1;

           
            var result = _service.CheckBorrowingStatus(borrowingId);

         
            Assert.AreEqual("Not Returned Enough", result);
        }
        [Test]
        public void UpdateReturnedBook_ShouldUpdateReturnedBooksAndSaveChanges()
        {
          
            var borrowingDetailId = 1; 
            var numberBookReturned = 2; 

            // Act
            var result = _service.UpdateReturnedBook(borrowingDetailId, numberBookReturned);

            // Assert
            var updatedBorrowingDetail = _context.BorrowingDetails.FirstOrDefault(b => b.Id == borrowingDetailId);

            Assert.IsNotNull(updatedBorrowingDetail, "Borrowing detail should exist.");
            Assert.AreEqual(numberBookReturned, 2, "Number of books returned should be updated.");
           
        }



    }
}
