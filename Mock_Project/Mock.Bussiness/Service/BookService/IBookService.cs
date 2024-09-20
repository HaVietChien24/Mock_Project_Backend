using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.Service.BookService
{
    public interface IBookService: IBaseService<Book>
    {
        List<BookDTO> GetAllDTO();
        BookDTO GetDTOById(int id);
        List<BookDTO> GetBookDTOByGenreId(int id);
        List<BookDTO> SearchByTitleOrAuthor(string search);

       
        // Sửa kiểu trả về thành Task<AddBookRequestDTO>
        Task<AddBookRequestDTO> AddBookAsync(AddBookRequestDTO request);
        Task<UpdateBookRequestDTO> UpdateBookAsync(UpdateBookRequestDTO request);
        BookDTO GetById(int bookId);
    }
}
