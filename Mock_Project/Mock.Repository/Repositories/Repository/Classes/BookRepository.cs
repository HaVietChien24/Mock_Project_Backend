using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LivebraryContext _context;
        private readonly DbSet<Book> _entity;

        public BookRepository(LivebraryContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<Book>();
        }

        public List<Book> GetByGenreId(int id)
        {
            return _entity.Where(x => x.BookGenres.Any(bg => bg.GenreId == id))
                .Include(x => x.BookGenres).ThenInclude(bg => bg.Genre).ToList();
        }

        public List<Book> SearchByTitleOrAuthor(string search)
        {
            return _entity.Where(x =>
                (x.Title.ToLower().Contains(search.ToLower()))
                || (x.Author.ToLower().Contains(search.ToLower())))
                .Include(x => x.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .ToList();
        }
    }
}
