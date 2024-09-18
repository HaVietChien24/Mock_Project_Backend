using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        List<Book> GetByGenreId(int id);
        List<Book> SearchByTitleOrAuthor(string search);
        Task AddBook(Book book, List<string> genreNames);
        Task UpdateBook(Book book, List<string> genreNames);


    }
}
