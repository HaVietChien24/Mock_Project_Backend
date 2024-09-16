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
    }
}
