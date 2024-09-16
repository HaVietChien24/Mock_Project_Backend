using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly LivebraryContext _context;
        private readonly DbSet<Genre> _entity;
        public GenreRepository(LivebraryContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<Genre>();
        }


        //public Genre GetById(int id)
        //{
        //    return _entity.Include(x=>x.BookGenres).ThenInclude(x=>x.Book).FirstOrDefault(x=>x.Id==id);
        //}
    }
}
