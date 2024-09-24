using AutoMapper;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.BookService
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<BookDTO> GetAllDTO()
        {
            var list = _unitOfWork.BookRepository.GetAll("BookGenres.Genre");
            return _mapper.Map<List<BookDTO>>(list);
        }

        public BookDTO GetDTOById(int id)

        {
            var item = _unitOfWork.BookRepository.GetByID(id, "BookGenres.Genre");
            return _mapper.Map<BookDTO>(item);
        }
        public List<BookDTO> GetBookDTOByGenreId(int id)
        {
            var list = _unitOfWork.BookRepository.GetByGenreId(id);
            return _mapper.Map<List<BookDTO>>(list);
        }

        public List<BookDTO> SearchByTitleOrAuthor(string search)
        {
            var list = _unitOfWork.BookRepository.SearchByTitleOrAuthor(search);
            return _mapper.Map<List<BookDTO>>(list);
        }

        // Triển khai hàm AddBook
        public async Task<AddBookRequestDTO> AddBookAsync(AddBookRequestDTO request)
        {
            // Map DTO sang entity Book
            var newBook = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Publisher = request.Publisher,
                PublishedYear = request.PublishedYear,
                ISBN = request.ISBN,
                Amount = request.Amount,
                ImageUrl = request.ImageUrl
            };

            // Gọi đến repository để thêm sách và thể loại
            await _unitOfWork.BookRepository.AddBook(newBook, request.Genres);

            // Map từ Book sang AddBookRequestDTO
            var addedBookDTO = new AddBookRequestDTO
            {
                Title = newBook.Title,
                Description = newBook.Description,
                Author = newBook.Author,
                Publisher = newBook.Publisher,
                PublishedYear = newBook.PublishedYear,
                ISBN = newBook.ISBN,
                Amount = newBook.Amount,
                ImageUrl = newBook.ImageUrl,
                Genres = request.Genres // Trả về danh sách thể loại như trong request
            };

            // Trả về đối tượng AddBookRequestDTO sau khi đã thêm thành công
            return addedBookDTO;
        }

        public async Task<UpdateBookRequestDTO> UpdateBookAsync(UpdateBookRequestDTO request)
        {
            // Map DTO sang entity Book
            var bookToUpdate = new Book
            {
                Id= request.Id,
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Publisher = request.Publisher,
                PublishedYear = request.PublishedYear,
                ISBN = request.ISBN,
                Amount = request.Amount,
                ImageUrl = request.ImageUrl
            };

            // Gọi đến repository để cập nhật sách và thể loại
            await _unitOfWork.BookRepository.UpdateBook(bookToUpdate, request.Genres);

            // Map từ Book sang UpdateBookRequestDTO
            var updatedBookDTO = new UpdateBookRequestDTO
            {
                Id = bookToUpdate.Id, // Bao gồm Id
                Title = bookToUpdate.Title,
                Description = bookToUpdate.Description,
                Author = bookToUpdate.Author,
                Publisher = bookToUpdate.Publisher,
                PublishedYear = bookToUpdate.PublishedYear,
                ISBN = bookToUpdate.ISBN,
                Amount = bookToUpdate.Amount,
                ImageUrl = bookToUpdate.ImageUrl,
                Genres = request.Genres // Trả về danh sách thể loại như trong request
            };

            // Trả về đối tượng UpdateBookRequestDTO sau khi đã cập nhật thành công
            return updatedBookDTO;
        }

        public BookDTO GetById(int bookId)
        {
            var item = _unitOfWork.BookRepository.GetByID(bookId, "BookGenres.Genre");
            return _mapper.Map<BookDTO>(item);
          
        }
    }
}
