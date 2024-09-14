using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class BookGenreRepository : GenericRepository<BookGenre>, IBookGenreRepository
    {
        private readonly LivebraryContext _context;
        public BookGenreRepository(LivebraryContext context) : base(context)
        {
            _context = context;
        }
    }
}
