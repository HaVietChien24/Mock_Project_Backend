using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.BookService;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.Test
{
    public class BookServiceTest
    {
        private LivebraryContext _context;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private BookService _bookService;

        [SetUp]
        public void SetUp()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<LivebraryContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new LivebraryContext(options);
            _unitOfWork = new UnitOfWork(_context, null);
            _bookService = new BookService(_unitOfWork, _mapper);

            _context.Books.Add(new Book
            {
                Title = "The Cat",
                Description = "book description",
                Author = "Martin King",
                Publisher = "John Bidden",
                PublishedYear = 2010,
                ISBN = "23942305",
                Amount = 20
            });

            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        // Kiểm tra phương thức GetAllDTO()
        [Test]
        public void GetAllDTO_ShouldReturnListOfBookDTO()
        {
            var result = _bookService.GetAllDTO();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual("The Cat", result[0].Title);
        }

        // Kiểm tra phương thức GetDTOById()
        [Test]
        public void GetDTOById_ValidId_ShouldReturnBookDTO()
        {
            var result = _bookService.GetDTOById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("The Cat", result.Title);
        }

        [Test]
        public void GetDTOById_InvalidId_ShouldReturnNull()
        {
            var result = _bookService.GetDTOById(999); // ID không tồn tại
            Assert.IsNull(result);
        }

        [Test]
        public void GetBookDTOByGenreId_ValidId_ShouldReturnListOfBookDTO()
        {
            // Thêm sách với thể loại vào _context
            var genre = new Genre { Name = "Fantasy" };
            _context.Genres.Add(genre);
            _context.SaveChanges();  // Gọi SaveChanges để genre có Id

            _context.Books.Add(new Book
            {
                Title = "The Dog",
                Author = "Anna Smith",
                Description = "A story about a dog.",
                ISBN = "1234567890",
                Publisher = "ABC Publisher",
                PublishedYear = 2020,
                BookGenres = new List<BookGenre> { new BookGenre { GenreId = genre.Id } } // Sử dụng Id của genre
            });
            _context.SaveChanges();

            var result = _bookService.GetBookDTOByGenreId(genre.Id); // Sử dụng genre.Id thay vì 1
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("The Dog", result[0].Title);
        }


        [Test]
        public void GetBookDTOByGenreId_InvalidId_ShouldReturnEmptyList()
        {
            var result = _bookService.GetBookDTOByGenreId(999); // Genre ID không tồn tại
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void SearchByTitleOrAuthor_ValidSearch_ShouldReturnListOfBookDTO()
        {
            // Dọn dẹp dữ liệu trong bộ nhớ trước khi thêm sách mới
            _context.Books.RemoveRange(_context.Books);
            _context.SaveChanges();

            // Thêm sách với tiêu đề cần tìm kiếm
            _context.Books.Add(new Book
            {
                Title = "The Cat",
                Author = "Jane Doe",
                Description = "A tale about a cat.",
                ISBN = "9876543210",
                Publisher = "XYZ Publisher",
                PublishedYear = 2021
            });
            _context.SaveChanges();

            // Tìm kiếm sách với tiêu đề "The Cat"
            var result = _bookService.SearchByTitleOrAuthor("The Cat");

            // Kiểm tra kết quả tìm kiếm
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count); // Đảm bảo chỉ có 1 kết quả
            Assert.AreEqual("The Cat", result[0].Title); // Đảm bảo tiêu đề khớp
        }



        [Test]
        public void SearchByTitleOrAuthor_InvalidSearch_ShouldReturnEmptyList()
        {
            var result = _bookService.SearchByTitleOrAuthor("NonExistingTitle");
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        // Kiểm tra phương thức AddBookAsync()
        [Test]
        public async Task AddBookAsync_ValidRequest_ShouldAddBook()
        {
            var newBookRequest = new AddBookRequestDTO
            {
                Title = "New Book",
                Description = "New description",
                Author = "New Author",
                Publisher = "New Publisher",
                PublishedYear = 2021,
                ISBN = "123456789",
                Amount = 10,
                ImageUrl = "http://image.url",
                Genres = new List<string> { "Fiction", "Science" }
            };

            var result = await _bookService.AddBookAsync(newBookRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual("New Book", result.Title);

            var bookInDb = _context.Books.FirstOrDefault(b => b.Title == "New Book");
            Assert.IsNotNull(bookInDb);
        }

        // Kiểm tra phương thức UpdateBookAsync()
        [Test]
        public async Task UpdateBookAsync_ValidRequest_ShouldUpdateBook()
        {
            var updateRequest = new UpdateBookRequestDTO
            {
                Id = 1,
                Title = "Updated Title",
                Description = "Updated description",
                Author = "Updated Author",
                Publisher = "Updated Publisher",
                PublishedYear = 2022,
                ISBN = "987654321",
                Amount = 15,
                ImageUrl = "http://newimage.url",
                Genres = new List<string> { "Fiction", "Science" }
            };

            var result = await _bookService.UpdateBookAsync(updateRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Title", result.Title);

            var updatedBook = _context.Books.FirstOrDefault(b => b.Id == 1);
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual("Updated Title", updatedBook.Title);
        }
    }
}
